
using FLY_India_Tours_API.Extensions;
using Microsoft.OpenApi.Models;



var builder = WebApplication.CreateBuilder(args);
// Add services to the container

builder.Host.ConfigureDefaults(args).ConfigureAppConfiguration((app, config) =>
{
    string _Environment = builder.Configuration.GetValue<string>("Environment:Name");
    _Environment = !string.IsNullOrEmpty(_Environment) ? _Environment : "Development";
    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).
    AddJsonFile($"appsettings.{_Environment}.json", optional: false, reloadOnChange: true);
    config.AddEnvironmentVariables();
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpClient();

builder.Services
    .AddDatabase(builder.Configuration)
    .AddAuthentication(builder.Configuration)
    .AddSingletonService(builder.Configuration)
    .AddService()
    .AddSessionWithOptions()
                    ;
builder.Services.Configure<IISOptions>(options =>
{
    options.AutomaticAuthentication = false;
}
);
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                 Reference=new OpenApiReference
                 {
                     Type=ReferenceType.SecurityScheme,
                     Id="Bearer"
                 }
            },
            new string[]{ }
        }

    }); ;

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(o =>
    {
        o.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.UseCookiePolicy();
app.UseSession();
app.MapControllers();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
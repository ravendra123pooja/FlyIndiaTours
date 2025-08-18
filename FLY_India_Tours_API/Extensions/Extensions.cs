using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections;
using System.Text.Json;

namespace FLY_India_Tours_API.Extensions
{
    public static class Extensions
    {
        public static string StringifyModeErrors(this ModelStateDictionary modelstate)
        {
            Hashtable errors=new Hashtable();
            foreach (var pair in modelstate)
            {
                if(pair.Value.Errors.Count>0)
                {
                    errors[pair.Key]=pair.Value.Errors.Select(error=>error.ErrorMessage).ToList();

                }
            }
            return JsonSerializer.Serialize(errors);
        }
    }
}

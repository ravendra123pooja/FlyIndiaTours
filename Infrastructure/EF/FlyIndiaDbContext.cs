using System;
using System.Collections.Generic;
using Infrastructure.EF.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.EF;

public partial class FlyIndiaDbContext : DbContext
{
    private readonly IConfiguration _configuration;
   
    public FlyIndiaDbContext(IConfiguration configuration,DbContextOptions<FlyIndiaDbContext> options)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<BookingAgent> BookingAgents { get; set; }

    public virtual DbSet<BookingAgentEmail> BookingAgentEmails { get; set; }

    public virtual DbSet<BookingAgentMobile> BookingAgentMobiles { get; set; }

    public virtual DbSet<BookingAgentPhone> BookingAgentPhones { get; set; }

    public virtual DbSet<BookingAgentStatus> BookingAgentStatuses { get; set; }

    public virtual DbSet<CityAttraction> CityAttractions { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<HotelCreation> HotelCreations { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<SameDayTour> SameDayTours { get; set; }

    public virtual DbSet<TblAttractionTime> TblAttractionTimes { get; set; }

    public virtual DbSet<TblBillToCompany> TblBillToCompanies { get; set; }

    public virtual DbSet<TblBooking> TblBookings { get; set; }

    public virtual DbSet<TblCancellationPolicy> TblCancellationPolicies { get; set; }

    public virtual DbSet<TblCity> TblCities { get; set; }

    public virtual DbSet<TblCompany> TblCompanies { get; set; }

    public virtual DbSet<TblCorporate> TblCorporates { get; set; }

    public virtual DbSet<TblCurrency> TblCurrencies { get; set; }

    public virtual DbSet<TblDuration> TblDurations { get; set; }

    public virtual DbSet<TblHoldBooking> TblHoldBookings { get; set; }

    public virtual DbSet<TblInvoiceAgent> TblInvoiceAgents { get; set; }

    public virtual DbSet<TblInvoiceBill> TblInvoiceBills { get; set; }

    public virtual DbSet<TblInvoiceDetail> TblInvoiceDetails { get; set; }

    public virtual DbSet<TblInvoiceHotel> TblInvoiceHotels { get; set; }

    public virtual DbSet<TblMenu> TblMenus { get; set; }

    public virtual DbSet<TblMenuGroup> TblMenuGroups { get; set; }

    public virtual DbSet<TblMenuPerMision> TblMenuPerMisions { get; set; }

    public virtual DbSet<TblMetaTag> TblMetaTags { get; set; }

    public virtual DbSet<TblMultiDayCityAttraction> TblMultiDayCityAttractions { get; set; }

    public virtual DbSet<TblMultiDayDestination> TblMultiDayDestinations { get; set; }

    public virtual DbSet<TblMultiDayHotel> TblMultiDayHotels { get; set; }

    public virtual DbSet<TblMultiDayPackageDate> TblMultiDayPackageDates { get; set; }

    public virtual DbSet<TblOtp> TblOtps { get; set; }

    public virtual DbSet<TblRoleMaster> TblRoleMasters { get; set; }

    public virtual DbSet<TblSameDayImage> TblSameDayImages { get; set; }

    public virtual DbSet<TblSameDayVideo> TblSameDayVideos { get; set; }

    public virtual DbSet<TblSessionLog> TblSessionLogs { get; set; }

    public virtual DbSet<Usermaster> Usermasters { get; set; }

    public virtual DbSet<UsermasterEmail> UsermasterEmails { get; set; }

    public virtual DbSet<UsermasterMobile> UsermasterMobiles { get; set; }

    public virtual DbSet<UsermasterPhone> UsermasterPhones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("flyinizz_FlyIndiaTours"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookingAgent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BOOKING_AGENT");

            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("address");
            entity.Property(e => e.AgentCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("agentCode");
            entity.Property(e => e.Approval).HasMaxLength(25);
            entity.Property(e => e.BookingAgentName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("bookingAgentName");
            entity.Property(e => e.BusinessName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("businessName");
            entity.Property(e => e.City)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("city");
            entity.Property(e => e.CountryCode).HasMaxLength(10);
            entity.Property(e => e.CountryId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("countryId");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.EnableDisable)
                .HasMaxLength(25)
                .HasColumnName("Enable_Disable");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.NatureOfBusinesss)
                .HasMaxLength(50)
                .HasColumnName("natureOfBusinesss");
            entity.Property(e => e.PassWord).HasMaxLength(25);
            entity.Property(e => e.Photopath).HasColumnName("photopath");
            entity.Property(e => e.Status).HasDefaultValue(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(25)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Website).HasColumnName("website");
        });

        modelBuilder.Entity<BookingAgentEmail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BOOKING_AGENT_EMAIL");

            entity.Property(e => e.AgentCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("agentCode");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<BookingAgentMobile>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BOOKING_AGENT_MOBILE");

            entity.Property(e => e.AgentCode)
                .HasMaxLength(20)
                .HasColumnName("agentCode");
            entity.Property(e => e.CountryCode).HasMaxLength(5);
            entity.Property(e => e.MobileNo).HasMaxLength(20);
        });

        modelBuilder.Entity<BookingAgentPhone>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BOOKING_AGENT_PHONE");

            entity.Property(e => e.AgentCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("agentCode");
            entity.Property(e => e.CityCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<BookingAgentStatus>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BOOKING_AGENT_STATUS");

            entity.Property(e => e.BookingAgentId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("bookingAgentId");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.StatusChangeDateTime)
                .HasPrecision(0)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("statusChangeDateTime");
            entity.Property(e => e.StatusChangeReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("statusChangeReason");
        });

        modelBuilder.Entity<CityAttraction>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CITY_ATTRACTION");

            entity.Property(e => e.ActivityMaxDurationHours).HasColumnName("activityMaxDurationHours");
            entity.Property(e => e.ActivityMinDurationHours).HasColumnName("activityMinDurationHours");
            entity.Property(e => e.AtractionAmpmfrom)
                .HasMaxLength(50)
                .HasColumnName("AtractionAMPMFrom");
            entity.Property(e => e.AtractionAmpmto)
                .HasMaxLength(50)
                .HasColumnName("AtractionAMPMTo");
            entity.Property(e => e.AtractionSecondFrom).HasMaxLength(50);
            entity.Property(e => e.AtractionSecondTo).HasMaxLength(50);
            entity.Property(e => e.AtractionTimeFrom).HasMaxLength(50);
            entity.Property(e => e.AtractionTimeTo).HasMaxLength(50);
            entity.Property(e => e.AttractionBanner).HasColumnName("attractionBanner");
            entity.Property(e => e.AttractionCity)
                .IsUnicode(false)
                .HasColumnName("attractionCity");
            entity.Property(e => e.AttractionName)
                .IsUnicode(false)
                .HasColumnName("attractionName");
            entity.Property(e => e.AttractionPicture).HasColumnName("attractionPicture");
            entity.Property(e => e.CostExcludes)
                .IsUnicode(false)
                .HasColumnName("costExcludes");
            entity.Property(e => e.CostIncludes)
                .IsUnicode(false)
                .HasColumnName("costIncludes");
            entity.Property(e => e.CostPerPerson)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costPerPerson");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Currency)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("currency");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Itinerary)
                .IsUnicode(false)
                .HasColumnName("itinerary");
            entity.Property(e => e.Overview)
                .IsUnicode(false)
                .HasColumnName("overview");
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Country");

            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CountryCode).HasMaxLength(100);
            entity.Property(e => e.CountryName).HasMaxLength(100);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<HotelCreation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Hotel_Creation");

            entity.Property(e => e.CityName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.HotelCategory)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.HotelLocation)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.HotelName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.ToTable("RefreshToken");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ExpiredOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("userName");
        });

        modelBuilder.Entity<SameDayTour>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SameDayTour");

            entity.Property(e => e.AirPortCurrency).HasMaxLength(50);
            entity.Property(e => e.AirPortPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CostOfAdultOneTripAgent)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costOfAdultOneTripAgent");
            entity.Property(e => e.CostOfAdultOneTripDirect)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costOfAdultOneTripDirect");
            entity.Property(e => e.CostOfAdultThreeTripAgent)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costOfAdultThreeTripAgent");
            entity.Property(e => e.CostOfAdultThreeTripDirect)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costOfAdultThreeTripDirect");
            entity.Property(e => e.CostOfAdultTripAgent)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costOfAdultTripAgent");
            entity.Property(e => e.CostOfAdultTripDirect)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costOfAdultTripDirect");
            entity.Property(e => e.CostOfAdultTwoTripAgent)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costOfAdultTwoTripAgent");
            entity.Property(e => e.CostOfAdultTwoTripDirect)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costOfAdultTwoTripDirect");
            entity.Property(e => e.CostOfChildTripAgent)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costOfChildTripAgent");
            entity.Property(e => e.CostOfChildTripDirect)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costOfChildTripDirect");
            entity.Property(e => e.CostOfChildTripWithBedAgent)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costOfChildTripWithBedAgent");
            entity.Property(e => e.CostOfChildTripWithBedDirect)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costOfChildTripWithBedDirect");
            entity.Property(e => e.CostOfChildTripWithoutBedAgent)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costOfChildTripWithoutBedAgent");
            entity.Property(e => e.CostOfChildTripWithoutBedDirect)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costOfChildTripWithoutBedDirect");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CurrencyofDayTourPackageCost).HasMaxLength(10);
            entity.Property(e => e.DateFrom)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateTo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DefaultBlockedSeatsEachTrip).HasColumnName("defaultBlockedSeatsEachTrip");
            entity.Property(e => e.HotelCurrency).HasMaxLength(50);
            entity.Property(e => e.HotelPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.MaxAgeOfDiscountedChild).HasColumnName("maxAgeOfDiscountedChild");
            entity.Property(e => e.MaxAgeOfFreeChild).HasColumnName("maxAgeOfFreeChild");
            entity.Property(e => e.OnePlusBookingDiscountPercentAdultAgent)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("onePlusBookingDiscountPercentAdultAgent");
            entity.Property(e => e.OnePlusBookingDiscountPercentAdultDirect)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("onePlusBookingDiscountPercentAdultDirect");
            entity.Property(e => e.SerialCode).HasMaxLength(50);
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.TotalSeatsEachTrip).HasColumnName("totalSeatsEachTrip");
            entity.Property(e => e.TourCategory).HasMaxLength(50);
            entity.Property(e => e.TourDepartureAmpm)
                .HasMaxLength(50)
                .HasColumnName("TourDepartureAMPM");
            entity.Property(e => e.TourDepartureSecond).HasMaxLength(50);
            entity.Property(e => e.TourDepartureTime).HasMaxLength(50);
            entity.Property(e => e.TourDestination).HasMaxLength(200);
            entity.Property(e => e.TourPackageName).HasMaxLength(200);
            entity.Property(e => e.TourTitle).HasMaxLength(50);
            entity.Property(e => e.TourType).HasMaxLength(50);
            entity.Property(e => e.TourValidityPeriodFromDate).HasColumnType("datetime");
            entity.Property(e => e.TourValidityPeriodTodate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblAttractionTime>(entity =>
        {
            entity.ToTable("TBL_AttractionTime");

            entity.Property(e => e.ShowsAtractionTimeFrom).HasMaxLength(50);
            entity.Property(e => e.ShowsAtractionTimeTo).HasMaxLength(50);
        });

        modelBuilder.Entity<TblBillToCompany>(entity =>
        {
            entity.ToTable("TBL_BillToCompany");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CountryId).HasColumnName("Country_id");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MobileNo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Pincode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.State).HasMaxLength(100);
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<TblBooking>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TBL_Booking");

            entity.Property(e => e.AirPickupDate)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AitArrivalMinut)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ArrivalDate).HasColumnType("datetime");
            entity.Property(e => e.ArrivalTime).HasMaxLength(50);
            entity.Property(e => e.AverageCost)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BookingBy).HasMaxLength(50);
            entity.Property(e => e.BookingId).HasMaxLength(50);
            entity.Property(e => e.BookingStatus).HasMaxLength(50);
            entity.Property(e => e.CancelDate).HasColumnType("datetime");
            entity.Property(e => e.CancelPerCentage).HasDefaultValue(0);
            entity.Property(e => e.CancelTerms).HasDefaultValue(false);
            entity.Property(e => e.ChangesAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ChildAge1).HasDefaultValue(0);
            entity.Property(e => e.ChildAge10).HasDefaultValue(0);
            entity.Property(e => e.ChildAge11).HasDefaultValue(0);
            entity.Property(e => e.ChildAge12).HasDefaultValue(0);
            entity.Property(e => e.ChildAge2).HasDefaultValue(0);
            entity.Property(e => e.ChildAge3).HasDefaultValue(0);
            entity.Property(e => e.ChildAge4).HasDefaultValue(0);
            entity.Property(e => e.ChildAge5).HasDefaultValue(0);
            entity.Property(e => e.ChildAge6).HasDefaultValue(0);
            entity.Property(e => e.ChildAge7).HasDefaultValue(0);
            entity.Property(e => e.ChildAge8).HasDefaultValue(0);
            entity.Property(e => e.ChildAge9).HasDefaultValue(0);
            entity.Property(e => e.ConfirmTime).HasDefaultValue(0);
            entity.Property(e => e.CostOfAdultOneTripDirect)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costOfAdultOneTripDirect");
            entity.Property(e => e.CostOfAdultThreeTripDirect)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costOfAdultThreeTripDirect");
            entity.Property(e => e.CostOfAdultTwoTripDirect)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costOfAdultTwoTripDirect");
            entity.Property(e => e.CostOfChildTripDirect)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costOfChildTripDirect");
            entity.Property(e => e.CostOfChildTripWithBedDirect)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costOfChildTripWithBedDirect");
            entity.Property(e => e.CostOfChildTripWithoutBedDirect)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costOfChildTripWithoutBedDirect");
            entity.Property(e => e.CounteryCode).HasMaxLength(50);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateStatus).HasMaxLength(50);
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.DepartureTime).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.ExtraBed1).HasMaxLength(50);
            entity.Property(e => e.ExtraBed2).HasMaxLength(50);
            entity.Property(e => e.ExtraBed3).HasMaxLength(50);
            entity.Property(e => e.ExtraBed4).HasMaxLength(50);
            entity.Property(e => e.GroupTourEndDate)
                .HasColumnType("datetime")
                .HasColumnName("groupTourEndDate");
            entity.Property(e => e.GuestName).HasMaxLength(100);
            entity.Property(e => e.HoldingStatus)
                .HasMaxLength(50)
                .HasDefaultValue("NotHolding");
            entity.Property(e => e.HotelLocation)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.HotelName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.MaxAgeOfDiscountedChild).HasColumnName("maxAgeOfDiscountedChild");
            entity.Property(e => e.MaxAgeOfFreeChild).HasColumnName("maxAgeOfFreeChild");
            entity.Property(e => e.MobileNo).HasMaxLength(50);
            entity.Property(e => e.OnePlusBookingDiscountPercentAdultDirect)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("onePlusBookingDiscountPercentAdultDirect");
            entity.Property(e => e.OptinalPrice)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OptionService).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Payment).HasMaxLength(50);
            entity.Property(e => e.RoomAdult1).HasDefaultValue(0);
            entity.Property(e => e.RoomAdult2).HasDefaultValue(0);
            entity.Property(e => e.RoomAdult3).HasDefaultValue(0);
            entity.Property(e => e.RoomAdult4).HasDefaultValue(0);
            entity.Property(e => e.RoomChildren1).HasDefaultValue(0);
            entity.Property(e => e.RoomChildren2).HasDefaultValue(0);
            entity.Property(e => e.RoomChildren3).HasDefaultValue(0);
            entity.Property(e => e.RoomChildren4).HasDefaultValue(0);
            entity.Property(e => e.SerialCode).HasMaxLength(50);
            entity.Property(e => e.TotalAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalRooms)
                .HasDefaultValue(0)
                .HasColumnName("totalRooms");
            entity.Property(e => e.TourCost)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TourDate).HasColumnType("datetime");
            entity.Property(e => e.TourPackageName).HasMaxLength(100);
        });

        modelBuilder.Entity<TblCancellationPolicy>(entity =>
        {
            entity.ToTable("TBL_CancellationPolicy");

            entity.Property(e => e.PerFifty).HasDefaultValue(0);
            entity.Property(e => e.PerHundred).HasDefaultValue(0);
            entity.Property(e => e.PerTwentyfive).HasDefaultValue(0);
        });

        modelBuilder.Entity<TblCity>(entity =>
        {
            entity.ToTable("TBL_City");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CityName).HasMaxLength(100);
            entity.Property(e => e.CountryId).HasColumnName("Country_id");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<TblCompany>(entity =>
        {
            entity.ToTable("TBL_Company");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CountryId).HasColumnName("Country_id");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gst)
                .HasMaxLength(50)
                .HasColumnName("GST");
            entity.Property(e => e.MobileNo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PaymentEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Pincode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ShortName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.State).HasMaxLength(100);
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.Website)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblCorporate>(entity =>
        {
            entity.ToTable("TBL_Corporate");

            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("address");
            entity.Property(e => e.CityId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("city_id");
            entity.Property(e => e.CountryId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("countryId");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.OfficeName)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.PrimaryEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Primary_Email");
            entity.Property(e => e.PrimaryMobile)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Primary_Mobile");
            entity.Property(e => e.SecondaryEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Secondary_Email");
            entity.Property(e => e.SecondaryMobile)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Secondary_Mobile");
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<TblCurrency>(entity =>
        {
            entity.ToTable("TBL_Currency");

            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<TblDuration>(entity =>
        {
            entity.ToTable("TBL_Duration");

            entity.Property(e => e.DurationDays).HasMaxLength(50);
        });

        modelBuilder.Entity<TblHoldBooking>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TBL_HoldBooking");

            entity.Property(e => e.AirPickupDate)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AitArrivalMinut)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ArrivalDate).HasColumnType("datetime");
            entity.Property(e => e.ArrivalTime).HasMaxLength(50);
            entity.Property(e => e.AverageCost)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BookingBy).HasMaxLength(50);
            entity.Property(e => e.BookingId).HasMaxLength(50);
            entity.Property(e => e.BookingStatus).HasMaxLength(50);
            entity.Property(e => e.CancelDate).HasColumnType("datetime");
            entity.Property(e => e.CancelPerCentage).HasDefaultValue(0);
            entity.Property(e => e.CancelTerms).HasDefaultValue(false);
            entity.Property(e => e.ChangesAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ChildAge1).HasDefaultValue(0);
            entity.Property(e => e.ChildAge10).HasDefaultValue(0);
            entity.Property(e => e.ChildAge11).HasDefaultValue(0);
            entity.Property(e => e.ChildAge12).HasDefaultValue(0);
            entity.Property(e => e.ChildAge2).HasDefaultValue(0);
            entity.Property(e => e.ChildAge3).HasDefaultValue(0);
            entity.Property(e => e.ChildAge4).HasDefaultValue(0);
            entity.Property(e => e.ChildAge5).HasDefaultValue(0);
            entity.Property(e => e.ChildAge6).HasDefaultValue(0);
            entity.Property(e => e.ChildAge7).HasDefaultValue(0);
            entity.Property(e => e.ChildAge8).HasDefaultValue(0);
            entity.Property(e => e.ChildAge9).HasDefaultValue(0);
            entity.Property(e => e.ConfirmTime).HasDefaultValue(0);
            entity.Property(e => e.CostOfAdultOneTripDirect)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costOfAdultOneTripDirect");
            entity.Property(e => e.CostOfAdultThreeTripDirect)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costOfAdultThreeTripDirect");
            entity.Property(e => e.CostOfAdultTwoTripDirect)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costOfAdultTwoTripDirect");
            entity.Property(e => e.CostOfChildTripDirect)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costOfChildTripDirect");
            entity.Property(e => e.CostOfChildTripWithBedDirect)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costOfChildTripWithBedDirect");
            entity.Property(e => e.CostOfChildTripWithoutBedDirect)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costOfChildTripWithoutBedDirect");
            entity.Property(e => e.CounteryCode).HasMaxLength(50);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreateStatus).HasMaxLength(50);
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.DepartureTime).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.ExtraBed1).HasMaxLength(50);
            entity.Property(e => e.ExtraBed2).HasMaxLength(50);
            entity.Property(e => e.ExtraBed3).HasMaxLength(50);
            entity.Property(e => e.ExtraBed4).HasMaxLength(50);
            entity.Property(e => e.GroupTourEndDate)
                .HasColumnType("datetime")
                .HasColumnName("groupTourEndDate");
            entity.Property(e => e.GuestName).HasMaxLength(100);
            entity.Property(e => e.HoldingStatus)
                .HasMaxLength(50)
                .HasDefaultValue("NotHolding");
            entity.Property(e => e.HotelLocation)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.HotelName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.MaxAgeOfDiscountedChild).HasColumnName("maxAgeOfDiscountedChild");
            entity.Property(e => e.MaxAgeOfFreeChild).HasColumnName("maxAgeOfFreeChild");
            entity.Property(e => e.MobileNo).HasMaxLength(50);
            entity.Property(e => e.OnePlusBookingDiscountPercentAdultDirect)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("onePlusBookingDiscountPercentAdultDirect");
            entity.Property(e => e.OptinalPrice)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OptionService).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Payment).HasMaxLength(50);
            entity.Property(e => e.RoomAdult1).HasDefaultValue(0);
            entity.Property(e => e.RoomAdult2).HasDefaultValue(0);
            entity.Property(e => e.RoomAdult3).HasDefaultValue(0);
            entity.Property(e => e.RoomAdult4).HasDefaultValue(0);
            entity.Property(e => e.RoomChildren1).HasDefaultValue(0);
            entity.Property(e => e.RoomChildren2).HasDefaultValue(0);
            entity.Property(e => e.RoomChildren3).HasDefaultValue(0);
            entity.Property(e => e.RoomChildren4).HasDefaultValue(0);
            entity.Property(e => e.SerialCode).HasMaxLength(50);
            entity.Property(e => e.TotalAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalRooms)
                .HasDefaultValue(0)
                .HasColumnName("totalRooms");
            entity.Property(e => e.TourCost)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TourDate).HasColumnType("datetime");
            entity.Property(e => e.TourPackageName).HasMaxLength(100);
        });

        modelBuilder.Entity<TblInvoiceAgent>(entity =>
        {
            entity.ToTable("TBL_InvoiceAgent");

            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("address");
            entity.Property(e => e.AgentName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.CityId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("city_id");
            entity.Property(e => e.CountryId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("countryId");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PrimaryEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Primary_Email");
            entity.Property(e => e.PrimaryMobile)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Primary_Mobile");
            entity.Property(e => e.SecondaryEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Secondary_Email");
            entity.Property(e => e.SecondaryMobile)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Secondary_Mobile");
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.Website).HasColumnName("website");
        });

        modelBuilder.Entity<TblInvoiceBill>(entity =>
        {
            entity.ToTable("TBL_InvoiceBill");

            entity.Property(e => e.AdvanceAmt).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BalanceAmt).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BillToType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BillTotalAmt).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CgstAmt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CGST_Amt");
            entity.Property(e => e.CgstPer)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CGST_PER");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.ClientEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ClientMobile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ClientName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Clientaddress).HasColumnName("CLIENTAddress");
            entity.Property(e => e.CoCompanyId).HasColumnName("Co_Company_Id");
            entity.Property(e => e.CountryId).HasColumnName("countryId");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");
            entity.Property(e => e.FileNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HotelInvoiceId).HasColumnName("Hotel_Invoice_ID");
            entity.Property(e => e.IgstAmt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IGST_Amt");
            entity.Property(e => e.IgstPer)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IGST_PER");
            entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
            entity.Property(e => e.InvoiceNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InvoiceTravelAgentId).HasColumnName("Invoice_Travel_AgentId");
            entity.Property(e => e.Nationaliy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceMobile)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Reference_Mobile");
            entity.Property(e => e.ReferenceName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Reference__Name");
            entity.Property(e => e.SgstAmt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SGST_Amt");
            entity.Property(e => e.SgstPer)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SGST_PER");
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.TypeOfInvoice)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblInvoiceDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TBL_InvoiceDetail");

            entity.Property(e => e.InvoiceNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TblInvoiceHotel>(entity =>
        {
            entity.ToTable("TBL_InvoiceHotel");

            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("address");
            entity.Property(e => e.CityId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("city_id");
            entity.Property(e => e.CountryId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("countryId");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.HotelName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<TblMenu>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tbl_Menu");

            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.ManuName).HasColumnName("Manu_Name");
            entity.Property(e => e.MenuGroupId).HasColumnName("MenuGroup_Id");
            entity.Property(e => e.MenuId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Menu_Id");
            entity.Property(e => e.SrNo).HasColumnName("SrNO");
        });

        modelBuilder.Entity<TblMenuGroup>(entity =>
        {
            entity.HasKey(e => e.MenuGroupId).HasName("PK_TBL_MenuGroup");

            entity.ToTable("Tbl_MenuGroup");

            entity.Property(e => e.MenuGroupId).HasColumnName("MenuGroup_Id");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ManuGroupName).HasColumnName("ManuGroup_Name");
            entity.Property(e => e.ParantGroupId).HasColumnName("ParantGroup_Id");
        });

        modelBuilder.Entity<TblMenuPerMision>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TBL_RoleMaster");

            entity.ToTable("Tbl_MenuPerMision");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Create).HasDefaultValue(false);
            entity.Property(e => e.Delete).HasDefaultValue(false);
            entity.Property(e => e.Details).HasDefaultValue(false);
            entity.Property(e => e.Download).HasDefaultValue(false);
            entity.Property(e => e.MenuId).HasColumnName("Menu_id");
            entity.Property(e => e.Print).HasDefaultValue(false);
            entity.Property(e => e.RoleId).HasColumnName("Role_Id");
            entity.Property(e => e.Update).HasDefaultValue(false);
            entity.Property(e => e.View).HasDefaultValue(false);
        });

        modelBuilder.Entity<TblMetaTag>(entity =>
        {
            entity.ToTable("TBL_MetaTag");

            entity.Property(e => e.SerialCode).HasMaxLength(50);
        });

        modelBuilder.Entity<TblMultiDayCityAttraction>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TBL_MultiDayCityAttraction");

            entity.Property(e => e.AttractionCostPerPerson)
                .HasMaxLength(50)
                .HasColumnName("attractionCostPerPerson");
            entity.Property(e => e.AttractionDayDuringTour).HasColumnName("attractionDayDuringTour");
            entity.Property(e => e.GroupTourAttractionCity)
                .HasMaxLength(500)
                .HasColumnName("groupTourAttractionCity");
            entity.Property(e => e.GroupTourAttractionId).HasColumnName("groupTourAttractionId");
            entity.Property(e => e.SerialCode).HasMaxLength(50);
        });

        modelBuilder.Entity<TblMultiDayDestination>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TBL_MultiDayDestination");

            entity.Property(e => e.GroupTourDestination)
                .HasMaxLength(500)
                .HasColumnName("groupTourDestination");
            entity.Property(e => e.SerialCode).HasMaxLength(50);
        });

        modelBuilder.Entity<TblMultiDayHotel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TBL_MultiDayHotel");

            entity.Property(e => e.GroupTourHotelCategory)
                .HasMaxLength(50)
                .HasColumnName("groupTourHotelCategory");
            entity.Property(e => e.GroupTourHotelCity)
                .HasMaxLength(500)
                .HasColumnName("groupTourHotelCity");
            entity.Property(e => e.GroupTourHotelId).HasColumnName("groupTourHotelId");
            entity.Property(e => e.SerialCode).HasMaxLength(50);
        });

        modelBuilder.Entity<TblMultiDayPackageDate>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TBL_MultiDayPackageDate");

            entity.Property(e => e.DefaultBlockedSeatsEachTrip).HasColumnName("defaultBlockedSeatsEachTrip");
            entity.Property(e => e.GroupTourEndDate)
                .HasMaxLength(50)
                .HasColumnName("groupTourEndDate");
            entity.Property(e => e.GroupTourStartDate)
                .HasMaxLength(50)
                .HasColumnName("groupTourStartDate");
            entity.Property(e => e.SerialCode).HasMaxLength(50);
        });

        modelBuilder.Entity<TblOtp>(entity =>
        {
            entity.ToTable("TBL_OTP");

            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EmailID");
            entity.Property(e => e.LoginFrom)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Otp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OTP");
        });

        modelBuilder.Entity<TblRoleMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TBL_RoleMasters");

            entity.ToTable("Tbl_RoleMasters");

            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<TblSameDayImage>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TBL_SameDayImages");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ImageTitle).HasMaxLength(200);
            entity.Property(e => e.SerialCode).HasMaxLength(50);
        });

        modelBuilder.Entity<TblSameDayVideo>(entity =>
        {
            entity.ToTable("TBL_SameDayVideo");

            entity.Property(e => e.SerialCode).HasMaxLength(50);
            entity.Property(e => e.VideoUrl).HasColumnName("VideoURL");
        });

        modelBuilder.Entity<TblSessionLog>(entity =>
        {
            entity.ToTable("tbl_SessionLog");

            entity.Property(e => e.LoginTime).HasColumnType("datetime");
            entity.Property(e => e.LogoutTime).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<Usermaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_UserMasters");

            entity.ToTable("USERMASTER");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.CountryId).HasColumnName("Country_id");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Designation).HasMaxLength(100);
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.FatherName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Pincode).HasMaxLength(10);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.State).HasMaxLength(100);
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.UserCode).HasMaxLength(20);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<UsermasterEmail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("USERMASTER_EMAIL");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.UserCode).HasMaxLength(20);
        });

        modelBuilder.Entity<UsermasterMobile>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("USERMASTER_MOBILE");

            entity.Property(e => e.CountryCode).HasMaxLength(5);
            entity.Property(e => e.MobileNo).HasMaxLength(20);
            entity.Property(e => e.UserCode).HasMaxLength(20);
        });

        modelBuilder.Entity<UsermasterPhone>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("USERMASTER_PHONE");

            entity.Property(e => e.CityCode).HasMaxLength(10);
            entity.Property(e => e.CountryCode).HasMaxLength(5);
            entity.Property(e => e.PhoneNo).HasMaxLength(20);
            entity.Property(e => e.UserCode).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

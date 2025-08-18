using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class SameDayTour
{
    public int Id { get; set; }

    public int? Srno { get; set; }

    public string? SerialCode { get; set; }

    public string? TourCategory { get; set; }

    public string? TourType { get; set; }

    public string? TourTitle { get; set; }

    public string? Images { get; set; }

    public string? TourPackageName { get; set; }

    public string? TourDestination { get; set; }

    public string? TourHighlightInclusion { get; set; }

    public string? TourItinerary { get; set; }

    public string? TourDepartureDestinationAddress { get; set; }

    public string? YoutubeMainVideoLink { get; set; }

    public bool? WeekDays { get; set; }

    public bool? WeekEnd { get; set; }

    public bool? TourActiveMonDay { get; set; }

    public bool? TourActiveTuesDay { get; set; }

    public bool? TourActiveWednesDay { get; set; }

    public bool? TourActiveThursDay { get; set; }

    public bool? TourActiveFriDay { get; set; }

    public bool? TourActiveSaturDay { get; set; }

    public bool? TourActiveSunDay { get; set; }

    public int? TotalSeatsEachTrip { get; set; }

    public int? DefaultBlockedSeatsEachTrip { get; set; }

    public DateTime? TourValidityPeriodFromDate { get; set; }

    public DateTime? TourValidityPeriodTodate { get; set; }

    public string? TourDepartureAmpm { get; set; }

    public string? TourDepartureSecond { get; set; }

    public string? TourDepartureTime { get; set; }

    public int? Bookingclosedtime { get; set; }

    public string? CurrencyofDayTourPackageCost { get; set; }

    public decimal? OnePlusBookingDiscountPercentAdultDirect { get; set; }

    public decimal? CostOfAdultTripDirect { get; set; }

    public decimal? CostOfChildTripDirect { get; set; }

    public decimal? OnePlusBookingDiscountPercentAdultAgent { get; set; }

    public decimal? CostOfAdultTripAgent { get; set; }

    public decimal? CostOfChildTripAgent { get; set; }

    public int? MaxAgeOfFreeChild { get; set; }

    public int? MaxAgeOfDiscountedChild { get; set; }

    public decimal? AirPortPrice { get; set; }

    public string? AirPortCurrency { get; set; }

    public decimal? HotelPrice { get; set; }

    public string? HotelCurrency { get; set; }

    public decimal? CostOfAdultOneTripDirect { get; set; }

    public decimal? CostOfAdultTwoTripDirect { get; set; }

    public decimal? CostOfAdultThreeTripDirect { get; set; }

    public decimal? CostOfChildTripWithoutBedDirect { get; set; }

    public decimal? CostOfChildTripWithBedDirect { get; set; }

    public decimal? CostOfAdultOneTripAgent { get; set; }

    public decimal? CostOfAdultTwoTripAgent { get; set; }

    public decimal? CostOfAdultThreeTripAgent { get; set; }

    public decimal? CostOfChildTripWithoutBedAgent { get; set; }

    public decimal? CostOfChildTripWithBedAgent { get; set; }

    public string? DateFrom { get; set; }

    public string? DateTo { get; set; }

    public int? Duration { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreateDate { get; set; }
}

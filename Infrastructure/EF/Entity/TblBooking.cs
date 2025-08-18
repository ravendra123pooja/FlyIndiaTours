using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class TblBooking
{
    public int Id { get; set; }

    public int? Srno { get; set; }

    public string? BookingId { get; set; }

    public string? SerialCode { get; set; }

    public DateTime? TourDate { get; set; }

    public string? TourPackageName { get; set; }

    public decimal? TourCost { get; set; }

    public string? Currency { get; set; }

    public decimal? AverageCost { get; set; }

    public int? MaxAgeOfFreeChild { get; set; }

    public int? MaxAgeOfDiscountedChild { get; set; }

    public decimal? CostOfChildTripDirect { get; set; }

    public decimal? CostOfChildTripWithoutBedDirect { get; set; }

    public decimal? CostOfChildTripWithBedDirect { get; set; }

    public decimal? CostOfAdultOneTripDirect { get; set; }

    public decimal? CostOfAdultTwoTripDirect { get; set; }

    public decimal? CostOfAdultThreeTripDirect { get; set; }

    public decimal? OptinalPrice { get; set; }

    public decimal? TotalAmount { get; set; }

    public decimal? OnePlusBookingDiscountPercentAdultDirect { get; set; }

    public int? Adult { get; set; }

    public int? Children { get; set; }

    public int? TotalRooms { get; set; }

    public int? RoomAdult1 { get; set; }

    public int? RoomChildren1 { get; set; }

    public string? ExtraBed1 { get; set; }

    public int? ChildAge1 { get; set; }

    public int? ChildAge2 { get; set; }

    public int? ChildAge3 { get; set; }

    public int? RoomAdult2 { get; set; }

    public int? RoomChildren2 { get; set; }

    public string? ExtraBed2 { get; set; }

    public int? ChildAge4 { get; set; }

    public int? ChildAge5 { get; set; }

    public int? ChildAge6 { get; set; }

    public int? RoomAdult3 { get; set; }

    public int? RoomChildren3 { get; set; }

    public string? ExtraBed3 { get; set; }

    public int? ChildAge7 { get; set; }

    public int? ChildAge8 { get; set; }

    public int? ChildAge9 { get; set; }

    public int? RoomAdult4 { get; set; }

    public int? RoomChildren4 { get; set; }

    public string? ExtraBed4 { get; set; }

    public int? ChildAge10 { get; set; }

    public int? ChildAge11 { get; set; }

    public int? ChildAge12 { get; set; }

    public string? GuestName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? Country { get; set; }

    public string? CounteryCode { get; set; }

    public string? MobileNo { get; set; }

    public string? OptionService { get; set; }

    public string? DepartureTime { get; set; }

    public string? Description { get; set; }

    public string? Destination { get; set; }

    public string? BookingBy { get; set; }

    public string? BookingStatus { get; set; }

    public string? Payment { get; set; }

    public decimal? ChangesAmount { get; set; }

    public string? CreateStatus { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? ArrivalDate { get; set; }

    public string? FlightNo { get; set; }

    public string? ArrivalTime { get; set; }

    public string? AitArrivalMinut { get; set; }

    public string? AirPickupDate { get; set; }

    public string? HotelName { get; set; }

    public string? HotelLocation { get; set; }

    public DateTime? GroupTourEndDate { get; set; }

    public DateTime? CancelDate { get; set; }

    public bool? CancelTerms { get; set; }

    public int? CancelPerCentage { get; set; }

    public int? ConfirmTime { get; set; }

    public string? HoldingStatus { get; set; }
}

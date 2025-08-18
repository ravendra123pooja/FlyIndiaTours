using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class CityAttraction
{
    public int Id { get; set; }

    public string? AttractionName { get; set; }

    public string? AttractionCity { get; set; }

    public int? ActivityMinDurationHours { get; set; }

    public int? ActivityMaxDurationHours { get; set; }

    public string? Overview { get; set; }

    public string? Itinerary { get; set; }

    public decimal? CostPerPerson { get; set; }

    public string? Currency { get; set; }

    public string? CostIncludes { get; set; }

    public string? CostExcludes { get; set; }

    public string? AttractionPicture { get; set; }

    public string? AtractionAmpmfrom { get; set; }

    public string? AtractionSecondFrom { get; set; }

    public string? AtractionTimeFrom { get; set; }

    public string? AtractionAmpmto { get; set; }

    public string? AtractionSecondTo { get; set; }

    public string? AtractionTimeTo { get; set; }

    public string? AttractionBanner { get; set; }

    public string? SlugName { get; set; }

    public int? DiscountedChild { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? Title { get; set; }

    public string? Keyword { get; set; }

    public string? Descriptiondata { get; set; }
}

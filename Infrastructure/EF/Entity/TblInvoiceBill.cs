using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class TblInvoiceBill
{
    public int Id { get; set; }

    public string? InvoiceNo { get; set; }

    public int? SrNo { get; set; }

    public DateTime? InvoiceDate { get; set; }

    public int? CompanyId { get; set; }

    public string? FileNo { get; set; }

    public string? TypeOfInvoice { get; set; }

    public string? BillToType { get; set; }

    public decimal? BillTotalAmt { get; set; }

    public decimal? CgstPer { get; set; }

    public decimal? SgstPer { get; set; }

    public decimal? IgstPer { get; set; }

    public decimal? CgstAmt { get; set; }

    public decimal? SgstAmt { get; set; }

    public decimal? IgstAmt { get; set; }

    public decimal? AdvanceAmt { get; set; }

    public decimal? BalanceAmt { get; set; }

    public bool? ConfirmInvoice { get; set; }

    public int? InvoiceTravelAgentId { get; set; }

    public int? HotelInvoiceId { get; set; }

    public string? ReferenceName { get; set; }

    public string? ReferenceMobile { get; set; }

    public int? CoCompanyId { get; set; }

    public string? Nationaliy { get; set; }

    public string? ClientName { get; set; }

    public string? ClientMobile { get; set; }

    public string? ClientEmail { get; set; }

    public int? CurrencyId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? Clientaddress { get; set; }

    public int? CityId { get; set; }

    public int? CountryId { get; set; }

    public bool? Status { get; set; }
}

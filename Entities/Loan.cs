using System;
using System.Collections.Generic;

namespace DizonCoop.Entities;

public partial class Loan
{
    public int Id { get; set; }

    public int? ClientId { get; set; }

    public string? Type { get; set; }

    public int? Amount { get; set; }

    public int? Interest { get; set; }

    public int? NoPayment { get; set; }

    public int? Deduction { get; set; }

    public string? Status { get; set; }

    public DateTime? DueDate { get; set; }

    public int? Penalty { get; set; }

    public int? RecievableAmount { get; set; }

    public DateTime? DateCreated { get; set; }
}

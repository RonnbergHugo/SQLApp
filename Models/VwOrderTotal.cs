using System;
using System.Collections.Generic;

namespace SQLapp.Models;

public partial class VwOrderTotal
{
    public int OrderId { get; set; }

    public string CustomerName { get; set; } = null!;

    public decimal? TotalAmount { get; set; }
}

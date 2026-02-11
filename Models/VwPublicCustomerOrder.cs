using System;
using System.Collections.Generic;

namespace SQLapp.Models;

public partial class VwPublicCustomerOrder
{
    public int CustomerId { get; set; }

    public string Name { get; set; } = null!;

    public int OrderId { get; set; }

    public DateTime? OrderDate { get; set; }
}

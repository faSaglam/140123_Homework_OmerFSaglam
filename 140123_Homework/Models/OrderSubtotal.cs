using System;
using System.Collections.Generic;

namespace _140123_Homework.Models;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}

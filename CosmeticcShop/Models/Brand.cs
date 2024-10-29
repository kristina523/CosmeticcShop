using System;
using System.Collections.Generic;

namespace CosmeticcShop.Models;

public partial class Brand
{
    public int BrandsId { get; set; }

    public string Names { get; set; } = null!;

    public string? Country { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

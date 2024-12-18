using System;
using System.Collections.Generic;

namespace API.Model;

public partial class Item
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public int ItemCount { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}

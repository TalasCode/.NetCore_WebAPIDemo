using System;
using System.Collections.Generic;

namespace WebAPIDemo.Core.Models;

public partial class EventGuide
{
    public int Id { get; set; }

    public int? GuidId { get; set; }

    public int? EventId { get; set; }

    public virtual Event? Event { get; set; }

    public virtual Guide? Guid { get; set; }
}

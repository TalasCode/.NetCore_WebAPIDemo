using System;
using System.Collections.Generic;

namespace WebAPIDemo.Core.Models;

public partial class Event
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateOnly? EventDate { get; set; }

    public int? CategoryId { get; set; }

    public string? Destination { get; set; }

    public decimal? Cost { get; set; }

    public string? Status { get; set; }

    public int? UserId { get; set; }

    public virtual Lookup? Category { get; set; }

    public virtual ICollection<EventGuide> EventGuides { get; set; } = new List<EventGuide>();

    public virtual ICollection<EventMember> EventMembers { get; set; } = new List<EventMember>();

    public virtual User? User { get; set; }
}

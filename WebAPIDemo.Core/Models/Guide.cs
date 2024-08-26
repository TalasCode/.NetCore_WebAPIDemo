using System;
using System.Collections.Generic;

namespace WebAPIDemo.Core.Models;

public partial class Guide
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? PasswordHash { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public DateOnly? JoiningDate { get; set; }

    public string? Photo { get; set; }

    public string? Profession { get; set; }

    public virtual ICollection<EventGuide> EventGuides { get; set; } = new List<EventGuide>();
}

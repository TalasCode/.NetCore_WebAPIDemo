using System;
using System.Collections.Generic;

namespace WebAPIDemo.Core.Models;

public partial class Member
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public DateOnly? JoiningDate { get; set; }

    public string? Photo { get; set; }

    public string? MobileNumber { get; set; }

    public string? EmergencyNumber { get; set; }

    public string? Profession { get; set; }

    public string? Nationality { get; set; }

    public virtual ICollection<EventMember> EventMembers { get; set; } = new List<EventMember>();
}

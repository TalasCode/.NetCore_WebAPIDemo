using System;
using System.Collections.Generic;

namespace WebAPIDemo.Core.Models;


public partial class User
{
    
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string? Fullname { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? PasswordHash { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}

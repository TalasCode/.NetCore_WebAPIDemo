﻿using System;
using System.Collections.Generic;

namespace WebAPIDemo.Core.Models;

public partial class EventMember
{
    public int Id { get; set; }

    public int? EventId { get; set; }

    public int? MemberId { get; set; }

    public virtual Event? Event { get; set; }

    public virtual Member? Member { get; set; }
}

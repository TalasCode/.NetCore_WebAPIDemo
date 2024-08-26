using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIDemo.Core.DTO
{
    public class RoleDTO
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }

        public string? Role { get; set; }
    }
}

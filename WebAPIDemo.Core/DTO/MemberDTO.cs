using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIDemo.Core.DTO
{
    public class MemberDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public DateOnly? DateOfBirth { get; set; }

        public string? Gender { get; set; }

        public DateOnly? JoiningDate { get; set; }


        public string? Profession { get; set; }

        public string? Nationality { get; set; }
    }
}

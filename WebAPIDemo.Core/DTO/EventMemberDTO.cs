using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIDemo.Core.DTO
{
    public class EventMemberDTO
    {
        public int Id { get; set; }

        public int? EventId { get; set; }

        public int? MemberId { get; set; }
    }
}

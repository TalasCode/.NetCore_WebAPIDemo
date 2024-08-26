using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIDemo.Core.DTO
{
    public class EventGuideDTO
    {
        public int Id { get; set; }

        public int? GuidId { get; set; }

        public int? EventId { get; set; }
    }
}

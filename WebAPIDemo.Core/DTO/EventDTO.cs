using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIDemo.Core.DTO
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string? name { get; set; }
        public int? CategoryId { get; set; }
        public string? Destination { get; set; }

        public decimal? Cost { get; set; }

        public string? Status { get; set; }

        public int? UserId { get; set; }


    }
}

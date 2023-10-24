using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Dtos.Hotel
{
    public class RegisterHotelRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int StarsCount { get; set; }
    }
}

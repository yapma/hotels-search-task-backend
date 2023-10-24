using Core.Domain.Common;
using Core.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Hotel : BaseEntity<int>
    {
        private int _starsCount;

        public string Name { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public int StarsCount
        {
            get { return _starsCount; }
            set
            {
                if (value > 5)
                    throw new ArgumentException("Invalid Star Count.");
                _starsCount = value;
            }
        }
    }
}

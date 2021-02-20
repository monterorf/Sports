using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Domain
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
    }
}

using System.Collections.Generic;

namespace DMDB.Models
{
    public class Location
    {
        public int locationId { get; set; }

        public string locationName { get; set; }

        public string locationAddress { get; set; }

        public string locationCity { get; set; }

        public string locationState { get; set; }

        public int zipCode { get; set; }

        public List<Product> Product { get; set; }

        public List<Employee> Employee { get; set; }
    }
}
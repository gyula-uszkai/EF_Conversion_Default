using System.Collections.Generic;

namespace EF_Conversion_Default
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Location> Locations { get; set; } = new List<Location>();
    }
}

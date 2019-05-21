using System.Collections.Generic;
using System;

namespace NginxDashCore.Data.Entities
{
    public class Subdomain : Config
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDomainRoot { get; set; }
        public bool ForceHttps { get; set; }
        public ICollection<Location> Locations { get; set; }

        public Subdomain()
        {
            Locations = new List<Location>();
        }
    }
}
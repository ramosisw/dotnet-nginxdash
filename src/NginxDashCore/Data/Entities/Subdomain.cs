using System;
using System.Collections.Generic;

namespace NginxDashCore.Data.Entities
{
    public class Subdomain : Config
    {
        public Subdomain()
        {
            Locations = new List<Location>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDomainRoot { get; set; }
        public bool ForceHttps { get; set; }
        public ICollection<Location> Locations { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace NginxDashCore.Data.Entities
{
    public class Domain : Config
    {
        public Domain()
        {
            Subdomains = new List<Subdomain>();
        }

        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public bool ForceHttps { get; set; }
        public ICollection<Subdomain> Subdomains { get; set; }
    }
}
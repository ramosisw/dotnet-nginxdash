using System.ComponentModel.DataAnnotations;
using NginxDashCommon.Models.Location;
using System.Collections.Generic;

namespace NginxDashCommon.Models.Subdomain
{
    public class SubdomainModel
    {
        [Required(ErrorMessage = "Put a subdomain name")]
        [RegularExpression("[a-z0-9][a-z0-9-]{0,61}[a-z0-9]", ErrorMessage = "Put name like sub-domain or subdomain")]
        public string Name { get; set; }
        public bool IsDomainRoot { get; set; }
        public bool ForceHttps { get; set; }

        [Required(ErrorMessage = "You need at least one location.")]
        public ICollection<LocationModel> Locations { get; set; }
    }
}
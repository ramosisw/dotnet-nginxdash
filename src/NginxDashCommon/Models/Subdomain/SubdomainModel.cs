using System.ComponentModel.DataAnnotations;

namespace NginxDashCommon.Models.Subdomain
{
    public class SubdomainModel
    {
        [Required]
        public string Name { get; set; }
    }
}
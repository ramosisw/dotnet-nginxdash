using System.ComponentModel.DataAnnotations;
using NginxDashCore.Enum;

namespace NginxDashCommon.Models.Location
{
    public class LocationSettingModel
    {
        [Required]
        public NginxDirective Directive { get; set; }

        [Required]
        [StringLength(512)]
        public string Value { get; set; }
    }
}
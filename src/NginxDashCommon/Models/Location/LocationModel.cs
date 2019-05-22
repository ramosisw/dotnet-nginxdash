using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using NginxDashCore.Enum;

namespace NginxDashCommon.Models.Location
{
    public class LocationModel
    {
        [Required]
        public LocationModifier Modifier { get; set; }
        public string Match { get; set; }
        public ICollection<LocationSettingModel> Settings { get; set; }
    }
}
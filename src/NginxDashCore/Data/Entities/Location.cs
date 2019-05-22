using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using NginxDashCore.Enum;
using System;

namespace NginxDashCore.Data.Entities
{
    public class Location : Config
    {
        [Key]
        [Required]
        [StringLength(36)]
        public Guid Id { get; set; }

        public LocationModifier Modifier { get; set; }

        [Required]
        [StringLength(100)]
        public string Match { get; set; }

        public ICollection<LocationSetting> Settings { get; set; }

        public Location()
        {
            Settings = new List<LocationSetting>();
        }

    }
}
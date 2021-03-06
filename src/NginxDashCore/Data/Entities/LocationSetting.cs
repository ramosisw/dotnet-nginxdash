﻿using System.ComponentModel.DataAnnotations;
using NginxDashCore.Enum;
using System;

namespace NginxDashCore.Data.Entities
{
    public class LocationSetting
    {
        public Guid Id { get; set; }

        [Required]
        public NginxDirective Directive { get; set; }

        [Required]
        [StringLength(512)]
        public string Value { get; set; }
    }
}
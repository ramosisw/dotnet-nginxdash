using NginxDashCore.Enum;
using System;

namespace NginxDashCore.Data.Entities
{
    public class LocationSetting
    {
        public Guid Id { get; set; }
        public NginxDirective Directive { get; set; }
        public string Value { get; set; }
    }
}
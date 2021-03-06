﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NginxDashCore.Data.Entities
{
    public class Config
    {
        [Column(TypeName = "text")]
        public string LastConf { get; set; }

        [StringLength(32)]
        public string ConfMd5Sum { get; set; }

        [Column(TypeName = "text")]
        public string TestConf { get; set; }

    }
}
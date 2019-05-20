using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NginxDashCore.Data.Entities
{
    public class Location : Config
    {
        [Key]
        [Required]
        [StringLength(36)]
        public Guid Id { get; set; }

        [StringLength(2)]
        public string Modifier { get; set; }

        [StringLength(100)]
        public string Match { get; set; }

        [Column(TypeName = "json")]
        public string Settings { get; set; }

        
    }
}
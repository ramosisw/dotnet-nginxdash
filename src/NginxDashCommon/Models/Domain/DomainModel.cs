using System.ComponentModel.DataAnnotations;

namespace NginxDashCommon.Models.Domain
{
    public class DomainModel
    {
        [Required]
        [RegularExpression(@"^(?!:\/\/)([a-zA-Z0-9-_]+\.)*[a-zA-Z0-9][a-zA-Z0-9-_]+\.[a-zA-Z]{2,11}?$", ErrorMessage = "INCORRECT_DOMAIN_NAME")]
        public string Name { get; set; }
    }
}
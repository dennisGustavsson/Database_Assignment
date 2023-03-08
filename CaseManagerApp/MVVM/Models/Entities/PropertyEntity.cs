using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseManagerApp.MVVM.Models
{
    public class PropertyEntity
    {
        [Key]
        public int PropertyId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string StreetName { get; set; } = null!;

        [Required]
        [Column(TypeName = "char(6)")]
        public string PostalCode { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; } = null!;

        public int PropertyManagerId { get; set; }
        public PropertyManagerEntity PropertyManager { get; set; } = null!;

        public ICollection<TenantEntity> Tenants { get; set; } = new HashSet<TenantEntity>();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseManagerApp.MVVM.Models
{
    public class PropertyManagerEntity
    {
        [Key]
        public int PropertyManagerId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; } = null!;

        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } = null!;

        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; } = null!;
    }
}

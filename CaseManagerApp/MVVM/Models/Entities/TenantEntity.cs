﻿
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Documents;

namespace CaseManagerApp.MVVM.Models
{
    public class TenantEntity
    {
        [Key]
        public int TenantId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; } = null!;

        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } = null!;

        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; } = null!;

        [Column(TypeName = "char(13)")]
        public string PhoneNumber { get; set; } = null!;

        public ICollection<CaseEntity> Cases { get; set; }

/*        public int PropertyId { get; set; }

        public PropertyEntity Property { get; set; } = null!;*/
    }
}
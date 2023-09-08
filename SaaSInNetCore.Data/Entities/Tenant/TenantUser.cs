using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SaaSInNetCore.Data.Entities.Tenant
{
    public class TenantUser : IdentityUser
    {
        [Required]
        public string TenantId { get; set; }

        public int Status { get; set; } //1=> Active, 2=> InActive

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdated { get; set; }

    }
}

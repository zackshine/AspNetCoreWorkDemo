using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Core3MVC.Models
{
    public class ApplicationUserClaim : IdentityUserClaim<string>
    {
        public ApplicationUserClaim() { }

        public ApplicationUserClaim(string userId, string type, string value, int? siteId) : this(userId, new Claim(type, value), siteId)
        {
            this.SiteId = siteId;
        }

        public ApplicationUserClaim(string userId, Claim claim, int? siteId)
        {
            this.UserId = userId;
            this.SiteId = siteId;
            this.ClaimType = claim.Type;
            this.ClaimValue = claim.Value;
        }

        [PersonalData]
        public bool Active { get; set; } = true;
        [PersonalData]
        public Guid UId { get; set; } = Guid.NewGuid();
        public int? SiteId { get; set; }
        [PersonalData]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [PersonalData]
        public DateTime? DateDeleted { get; set; }

        [NotMapped]
        public Claim Claim => new Claim(this.ClaimType, this.ClaimValue);
    }
}

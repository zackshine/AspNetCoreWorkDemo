using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core22MVCIdentity.Models
{
    public class Roles:IdentityRole
    {
        public string ApplicationId { get; set; }
    }
    public class Applications
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
            
    }
    public class ApplicationUsers : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomTag { get; set; }
    }

    //[Table("IdentityUserClaim", Schema = "ManagementStudio")]
    //public class UserClaims : IdentityUserClaim<string>
    //{
    //    [Key]
    //    public override int Id { get; set; }
    //}

    //[Table("IdentityUserRole", Schema = "ManagementStudio")]
    //public class UserRoles : IdentityUserRole<string>
    //{
    //    [Key]
    //    public string Id { get; set; }
    //    [ForeignKey("Users")]
    //    public override string UserId { get; set; }
    //    public virtual ApplicationUsers Users { get; set; }
    //    [ForeignKey("Roles")]
    //    public override string RoleId { get; set; }
    //    public virtual Roles Roles { get; set; }
    //}
}

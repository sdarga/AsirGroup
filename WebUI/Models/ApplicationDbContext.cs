using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace WebUI.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("ASIRGroupDBEntities", false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
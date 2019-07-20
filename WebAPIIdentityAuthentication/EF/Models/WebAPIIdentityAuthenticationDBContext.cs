using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPIIdentityAuthentication.EF.Models
{
    public partial class WebAPIIdentityAuthenticationDBContext : IdentityDbContext
    {
        public WebAPIIdentityAuthenticationDBContext()
        {
        }

        public WebAPIIdentityAuthenticationDBContext(DbContextOptions<WebAPIIdentityAuthenticationDBContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectsV13;Database=WebAPIIdentityAuthentication.DB;Trusted_Connection=True;");
            }
        }
    }
}

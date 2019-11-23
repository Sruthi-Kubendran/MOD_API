using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MOD.ModelLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MOD.AuthLibrary
{
    public class AuthContext : IdentityDbContext
    {
        public AuthContext([NotNullAttribute]
        DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>(r => r.HasData(new IdentityRole
            {
                Id = "1",
                Name = "Admin",
                NormalizedName = "Admin"
            },
            new IdentityRole
            {
                Id = "2",
                Name = "Mentor",
                NormalizedName = "Mentor"

            },
            new IdentityRole
            {
                Id = "3",
                Name = "Student",
                NormalizedName = "Student"
            }
            ));

            base.OnModelCreating(builder);
        }
        public DbSet<UserMod> UserMods { get; set; }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<TrainingDtls> TrainingDtls { get; set; }
        public DbSet<PaymentDtls> PaymentDtls { get; set; }

    }
}

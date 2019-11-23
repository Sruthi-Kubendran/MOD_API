using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MOD.ModelLibrary;

namespace MOD.MentorLibrary
{
    public class MentorContext : IdentityDbContext
    {
        public MentorContext([NotNullAttribute]
        DbContextOptions options) : base(options)
        {

        }
        public DbSet<UserMod> UserMods { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<TrainingDtls> TrainingDtls { get; set; }
        public DbSet<PaymentDtls> PaymentDtls { get; set; }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eStateV1.Models;

namespace eStateV1.Models
{
    public class eStateDBContext : IdentityDbContext<Korisnik, Role, int>
    {
        public eStateDBContext(DbContextOptions<eStateDBContext> options) : base(options)
        {

        }
        public DbSet<Nekretnina> Nekretnina { get; set; }
        public DbSet<Stan> Stan { get; set; }
        public DbSet<Vikendica> Vikendica { get; set; }
        public DbSet<Kuca> Kuca { get; set; }
        public DbSet<Zemljiste> Zemljiste { get; set; }
        public DbSet<Slike> Slike { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Nekretnina>().ToTable("Nekretnina");
            modelBuilder.Entity<Nekretnina>().Property(f => f.VrijemeObjave).HasColumnType("datetime2");
            //modelBuilder.Entity<Stan>().ToTable("")
        }
    }
}

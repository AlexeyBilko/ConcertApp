namespace ConcertApp.DAL.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ConcertContext : DbContext
    {
        public ConcertContext()
            : base("name=ConcertContext_new2")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<Concerts> Concerts { get; set; }
        public virtual DbSet<CreditCards> CreditCards { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Concerts>()
                .HasMany(e => e.Tickets)
                .WithOptional(e => e.Concerts)
                .HasForeignKey(e => e.ConcertId);

            modelBuilder.Entity<CreditCards>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.CreditCards)
                .HasForeignKey(e => e.CardId);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Tickets)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.UserId);
        }
    }
}

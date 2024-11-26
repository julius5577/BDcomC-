
namespace EFtemp46
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BDtemp46Entities : DbContext
    {
        public BDtemp46Entities()
            : base("name=BDtemp46Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Agenda> Agenda { get; set; }
    }
}

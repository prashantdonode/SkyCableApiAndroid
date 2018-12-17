namespace SkyCableApiAndroid.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models;

    public partial class CableApiAndroidEntity : DbContext
    {
        public CableApiAndroidEntity()
            : base("name=CableApiAndroidEntity")
        {
        }

        public DbSet<tblAdminRegistration> tblAdminRegistrations { get; set; }
        public DbSet<tblAgent> tblAgents { get; set; }
        public DbSet<tblCustomerRegistration> tblCustomerRegistrations { get; set; }
        public DbSet<tblPackage> tblPackages { get; set; }
        public DbSet<tblSkyVisionLogin> tblSkyVisionLogins { get; set; }
        public DbSet<tblBill> tblBills { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

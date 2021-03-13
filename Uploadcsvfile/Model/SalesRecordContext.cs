using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uploadcsvfile.Model
{
    public partial class SalesRecordContext : DbContext
    {
        public SalesRecordContext() : base("name=SalesRecord")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<SalesRecordContext>());
        }

        public virtual DbSet<SalesRecord> SalesRecord { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;


namespace TimeSheet2017.Models
{
    public class TimeSheetContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TimeSheetContext() : base("name=TimeSheetContext")
        {
           //Database.SetInitializer<TimeSheetContext>(null);
        }

        public System.Data.Entity.DbSet<TimeSheet2017.Models.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<TimeSheet2017.Models.TimeLog> TimeLogs { get; set; }


 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
         }
    }

}




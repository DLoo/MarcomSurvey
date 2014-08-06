using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MarcomSurvey.Models
{
    public class EFESurvey_Context : DbContext
    {
        public EFESurvey_Context()
            : base("name=EFESurvey")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFESurvey_Context, MarcomSurvey.Migrations.Configuration>("EFESurvey"));
            
        }

        public DbSet<SurveyLog> SurveyLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
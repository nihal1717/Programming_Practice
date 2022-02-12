using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EFCodeFirstExample.Models
{
    public class SchoolContext:DbContext
    {
        public SchoolContext() : base("SchoolContext")
        {
         //   Database.SetInitializer(new MigrateDatabaseToLatestVersion<
         //SchoolContext, EFCodeFirstExample.Migrations.Configuration>("SchoolContext"));
            //Database.SetInitializer<SchoolContext>(new CreateDatabaseIfNotExists<SchoolContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>()); --- It will drop the existing DB and create new DB as per schema.
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>()); --- It will always drop the previous DB and create new one. Best during devlopment phase.
            //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
        }
         
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}
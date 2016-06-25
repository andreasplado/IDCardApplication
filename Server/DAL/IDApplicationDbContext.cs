using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL
{
    public class IDApplicationDbContext : DbContext, IDbContext
    {
        public IDApplicationDbContext() : base("name=DefaultConnection")
        {
            //Initialize database.
            //Algväärtusta andmebaas.
            Database.SetInitializer(
            new DropCreateDatabaseIfModelChanges<IDApplicationDbContext>());
        }
        //Generate tables.
        //Genereeri tabelid.
        public DbSet<IDApplication> Users { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}

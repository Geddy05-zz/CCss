using System.Data.Entity;
using Simple_solutions.Models;

namespace Simple_solutions.ApplicationDbContext__Simple_solutions
{
    public class Models_ : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<Simple_solutions.ApplicationDbContext__Simple_solutions.Models_>());

        public Models_() : base("name=Models_")
        {
        }

        public DbSet<searchResult> searchResults { get; set; }
    }
}

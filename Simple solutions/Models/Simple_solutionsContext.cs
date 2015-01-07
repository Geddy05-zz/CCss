using System.Data.Entity;

namespace Simple_solutions.Models
{
    public class Simple_solutionsContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<Simple_solutions.Models.Simple_solutionsContext>());

        public Simple_solutionsContext() : base("name=Simple_solutionsContext")
        {
        }

        public DbSet<searchResult> searchResults { get; set; }
    }
}

using System.Linq;
using EmployeeManagementSystemApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystemApi.Data
{
    public class DataContextEf : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DataContextEf(DbContextOptions<DataContextEf> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();

            // Enable snake_case naming convention
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties())
                {
                    string snakeCaseName = ConvertToSnakeCase(property.Name);
                    property.SetColumnName(snakeCaseName);
                }
            }
        }

        private static string ConvertToSnakeCase(string name)
        {
            return string.Concat(
                name.Select((ch, i) => i > 0 && char.IsUpper(ch) ? "_" + ch : ch.ToString())
            ).ToLower();
        }
    }
}

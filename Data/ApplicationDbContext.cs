using DSA.Models;
using Microsoft.EntityFrameworkCore;

namespace DSA.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }


        public DbSet<Student> Student_DSA { get; set; }

    }
}

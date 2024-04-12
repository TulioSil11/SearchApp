using Microsoft.EntityFrameworkCore;

namespace SearchApp.Models.Context;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {
    }

    public DbSet<Person> Person { get; set; }
    public DbSet<Question> Question { get; set; }
    public DbSet<QuestionOption> QuestionOption { get; set; }
    public DbSet<Response> Response { get; set; }

}

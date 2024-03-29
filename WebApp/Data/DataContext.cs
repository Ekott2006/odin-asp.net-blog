using Microsoft.EntityFrameworkCore;
using WebApp.Model;

namespace WebApp.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Article> Articles { get; set; } = default!;
    public DbSet<Comment> Comments { get; set; } = default!;
}
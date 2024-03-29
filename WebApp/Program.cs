using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Repository;
using static Microsoft.AspNetCore.Builder.WebApplication;

WebApplicationBuilder builder = CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite($"Data Source=blogging.sqlite3"));
builder.Services.AddScoped<ArticleRepository>();
builder.Services.AddScoped<CommentRepository>();
WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
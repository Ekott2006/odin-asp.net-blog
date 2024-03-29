using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Model;

namespace WebApp.Repository;

public class ArticleRepository(DataContext context)
{
    public async Task Create(Article article)
    {
        context.Articles.Add(article);
        await context.SaveChangesAsync();
    }

    public async Task<bool> Edit(Article article)
    {
        context.Attach(article).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ArticleExists(article.Id))
            {
                return false;
            }

            throw;
        }

        return true;
    }

    public async Task<Article?> Get(Guid id)
    {
        return await context.Articles.Include(x => x.Comments).FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<List<Article>> Get()
    {
        return await context.Articles.ToListAsync();
    }

    public async Task Delete(Guid id)
    {
        Article? article = await context.Articles.FindAsync(id);
        if (article == null) return;

        context.Articles.Remove(article);
        await context.SaveChangesAsync();
    }

    private bool ArticleExists(Guid id)
    {
        return context.Articles.Any(e => e.Id == id);
    }
}
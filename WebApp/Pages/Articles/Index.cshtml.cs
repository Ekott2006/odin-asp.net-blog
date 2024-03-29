using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Model;
using WebApp.Repository;

namespace WebApp.Pages.Articles
{
    public class IndexModel(ArticleRepository repository) : PageModel
    {
        public IList<Article> Article { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Article = await repository.Get();
        }
    }
}
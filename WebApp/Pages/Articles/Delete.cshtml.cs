using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Model;
using WebApp.Repository;

namespace WebApp.Pages.Articles
{
    public class DeleteModel(ArticleRepository repository) : PageModel
    {
        [BindProperty] public Article Article { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Article? article = await repository.Get(id);

            if (article == null) return NotFound();

            Article = article;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            await repository.Delete(id);
            return RedirectToPage("./Index");
        }
    }
}
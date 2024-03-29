using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Model;
using WebApp.Repository;

namespace WebApp.Pages.Articles
{
    public class EditModel(ArticleRepository repository) : PageModel
    {
        [BindProperty]
        public Article Article { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Article? article = await repository.Get(id);
            if (article == null) return NotFound();
            Article = article;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            return await repository.Edit(Article) ? RedirectToPage("./Index"): NotFound(); 
        }

    }
}

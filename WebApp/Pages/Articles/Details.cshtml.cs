using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Dto.Comment;
using WebApp.Model;
using WebApp.Repository;

namespace WebApp.Pages.Articles
{
    public class DetailsModel(ArticleRepository articleRepository, CommentRepository commentRepository) : PageModel
    {
        public Article? CurrentArticle { get; set; }
        [BindProperty] public CreateCommentRequest NewComment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Article? article = await articleRepository.Get(id);
            if (article is null) return NotFound();
            CurrentArticle = article;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            Article? article = await articleRepository.Get(id);
            if (article is null) return NotFound();

            if (!ModelState.IsValid) return Page();
            CurrentArticle = await commentRepository.Create(article, NewComment);
            return RedirectToPage();
        }
    }
}
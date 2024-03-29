using WebApp.Data;
using WebApp.Dto.Comment;
using WebApp.Model;

namespace WebApp.Repository;

public class CommentRepository(DataContext context, ArticleRepository articleRepository)
{
    public async Task<Article?> Create(Article article, CreateCommentRequest request)
    {
        Comment comment = new()
            { Commenter = request.Commenter, Article = article, Body = request.Body, Id = request.Id };
        context.Comments.Add(comment);
        article.Comments.Add(comment);
        await context.SaveChangesAsync();
        return article;
    }
}
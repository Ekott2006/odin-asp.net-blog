using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Model;

public class Comment
{
    public Guid Id { get; set; }
    public string Commenter { get; set; }
    public string Body { get; set; }
    
    [ForeignKey(nameof(Article))]
    public Guid ArticleId { get; set; }
    public Article Article { get; set; }
}
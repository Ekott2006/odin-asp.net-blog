namespace WebApp.Dto.Comment;

public record CreateCommentRequest(
    Guid Id,
    string Commenter,
    string Body
);
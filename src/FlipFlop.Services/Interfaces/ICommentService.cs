namespace FlipFlop.Services.Interfaces 
{
    public interface ICommentService 
    {
        Task<List<Comment>> GetPostComments(string PostId);
        Task<Comment?> CreateComment(Comment comment, string PostId);
        Task DeleteComment(string id);
        Task<Comment?> UpdateComment(string id, Comment comment);
    }
}
namespace FlipFlop.Services.Interfaces 
{
    public interface ICommentService 
    {
        Task<List<Comment>> GetPostComments(long PostId);
        Task<Comment?> CreateComment(Comment comment);
        Task DeleteComment(long id);
        Task<Comment?> UpdateComment(long id, Comment comment);
    }
}
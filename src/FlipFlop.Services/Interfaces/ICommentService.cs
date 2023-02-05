namespace FlipFlop.Services.Interfaces 
{
    public interface ICommentService 
    {
        Task<List<Comment>> GetPostComments();
        Task<Comment?> CreateComment();
        Task DeleteComment();
        Task<Comment?> UpdateComment();
    }
}
using FlipFlop.Services.Interfaces;

namespace FlipFlop.Services.Impl
{
    public class CommentService : ICommentService
    {

        public Task<Comment?> CreateComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Task DeleteComment(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Comment>> GetPostComments(long PostId)
        {
            throw new NotImplementedException();
        }

        public Task<Comment?> UpdateComment(long id, Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
using FlipFlop.Helpers.Exceptions;
using FlipFlop.Services.Interfaces;

namespace FlipFlop.Services.Impl
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostService _postService;
        public CommentService(ICommentRepository commentRepository, IPostService postService)
        {
            _commentRepository = commentRepository;
            _postService = postService;
        }
        public async Task<Comment?> CreateComment(Comment comment, string PostId)
        {
            Post? post = await _postService.GetPostById(PostId);
            if (post == null)
            {
                throw new NotFoundException("post not found");
            }
            comment.PostId = PostId;
            await _commentRepository.Create(comment);
            return comment;
        }

        public Task DeleteComment(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Comment>> GetPostComments(string PostId)
        {
            return await _commentRepository.GetPostComments(PostId);
        }

        public Task<Comment?> UpdateComment(string id, Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
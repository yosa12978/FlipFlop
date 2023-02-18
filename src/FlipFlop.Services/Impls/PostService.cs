using FlipFlop.Helpers.Exceptions;
using FlipFlop.Services.Interfaces;

namespace FlipFlop.Services.Impl
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository) 
        {
            _postRepository = postRepository;
        }

        public async Task<Post?> CreatePost(Post post)
        {
            
            return await _postRepository.Create(post);
        }

        public async Task<List<Post>> SearchPost(string q)
        {
            return await _postRepository.SearchPost(q);
        }

        public Task DeletePost(string id, string userId)
        {
            throw new NotImplementedException(); //TODO: implement this
        }

        public async Task<List<Post>> GetAll()
        {
            return await Task.Run(() => _postRepository.GetAll().ToList());
        }

        public async Task<Post?> GetPostById(string id)
        {
            return await _postRepository.GetById(id);
        }

        public async Task<List<Post>> GetUserPosts(string userId)
        {
            return await _postRepository.GetUserPosts(userId);
        }

        public async Task<Post?> UpdatePost(string postId, Post updatedPost)
        {
            return await _postRepository.Update(postId, updatedPost);
        }
    }
}
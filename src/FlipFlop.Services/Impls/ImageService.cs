using FlipFlop.Services.Interfaces;

namespace FlipFlop.Services.Impl
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        public ImageService(IImageRepository imageRepository) 
        {
            _imageRepository = imageRepository;
        } 
        public async Task<Image?> CreateImage(Image img, string username, string postId)
        {
            return await _imageRepository.Create(img);
        }

        public async Task<List<Image>> GetPostImages(string postId)
        {
            return await _imageRepository.GetPostImages(postId);
        }
    }
}
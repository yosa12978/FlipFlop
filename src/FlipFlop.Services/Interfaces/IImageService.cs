namespace FlipFlop.Services.Interfaces 
{
    public interface IImageService 
    {
        // todo complete this interface
        Task<List<Image>> GetPostImages(string postId);
        Task<Image?> CreateImage(Image img, string username, string postId);
    }
}
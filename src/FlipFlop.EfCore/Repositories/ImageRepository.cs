using FlipFlop.Domain.Models;
using FlipFlop.EfCore.Data;
using Microsoft.EntityFrameworkCore;

namespace FlipFlop.EfCore.Repositories 
{
    public class ImageRepository : BaseRepository<Image, long>, IImageRepository
    {
        
        public ImageRepository(FlipFlopContext db) : base(db)
        {

        }

        public async Task<List<Image>> GetPostImages(long PostId)
        {
            return await _db.images.Where(x => x.PostId == PostId).ToListAsync();
        }
    }
}
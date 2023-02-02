using FlipFlop.Domain.Models;
using FlipFlop.EfCore.Data;

namespace FlipFlop.EfCore.Repositories 
{
    public class ImageRepository : BaseRepository<Image, long>
    {
        
        public ImageRepository(FlipFlopContext db) : base(db)
        {

        }
    }
}
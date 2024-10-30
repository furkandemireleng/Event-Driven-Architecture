using System.Collections;
using PlatformService.Models;

namespace PlatformService.Data
{
    public interface IPlatfromRepo
    {
        bool SaveChanges();
        IEnumerable<Platfrom> GetAllPlatforms();
        Platfrom GetPlatformById(int id);

        void CreatePlatfrom(Platfrom platfrom);
        
    } 
    
}
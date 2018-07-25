using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LocationFinder.DAL.Repository.Interfaces
{
    public interface ILocationRepository
    {
        Task<string> GetLocationData(string keyword, int radius, string location);
    }
}

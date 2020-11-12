using System.Collections.Generic;
using DMDB.Models;

namespace DMDB
{
    /// <summary>
    /// Data access interface for DunderMuffin locations
    /// </summary>
    public interface ILocationRepo
    {
        void AddLocation(Location location);
        void UpdateLocation(Location location);
        void DeleteLocation(Location location);
        Location GetLocationById(int id);
        Location GetLocationByName(string name);
        List<Location> GetAllLocations();
    }
}
using DMDB;
using DMDB.Models;
using System.Collections.Generic;

namespace DMLib
{
    /// <summary>
    /// These Are The Methods That Connect With The DBRepo and Allow Us To Use Location Related Business Logic Like Adding Updating Deleting Or Getting Locations
    /// </summary>
    public class LocationServices
    {
        private ILocationRepo repo;

        public LocationServices(ILocationRepo repo)
        {
            this.repo = repo;
        }
        public void AddLocation(Location location)
        {
            repo.AddLocation(location);
        }
        public void UpdateLocation(Location location)
        {
            repo.UpdateLocation(location);
        }
        public void DeleteLocation(Location location)
        {
            repo.DeleteLocation(location);
        }
        public Location GetLocationById(int id)
        {
            Location location = repo.GetLocationById(id);
            return location;
        }
        public Location GetLocationByName(string name)
        {
            Location location = repo.GetLocationByName(name);
            return location;
        }
        public List<Location> GetAllLocations()
        {
            List<Location> locations = repo.GetAllLocations();
            return locations;
        }
    }
}
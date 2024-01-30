using EZTripAPI.Models.Domain;

namespace EZTripAPI.Repositories.Abstract
{
    public interface ITripsRepository
    {
        bool AddUpdate(Trips Trips);
        bool Delete(int id);
        Trips GetById(int id );
        IEnumerable<Trips> GetAll(string term = "");
    }
}

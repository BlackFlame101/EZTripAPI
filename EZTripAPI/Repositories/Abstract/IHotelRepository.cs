using EZTripAPI.Models.Domain;

namespace EZTripAPI.Repositories.Abstract
{
    public interface IHotelRepository
    {
        bool AddUpdate(Hotel Hotel);
        bool Delete(int id);
        Hotel GetById(int id);
        IEnumerable<Hotel> GetAll();
    }
}

using EZTripAPI.Models.Domain;

namespace EZTripAPI.Repositories.Abstract
{
    public interface IBookingRepository
    {
            bool AddUpdate(Booking Booking);
            bool Delete(int id);
            Booking GetById(int id);
            IEnumerable<Booking> GetAll(string term = "");   
    }
}

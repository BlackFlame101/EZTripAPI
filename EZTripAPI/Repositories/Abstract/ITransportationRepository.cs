using EZTripAPI.Models.Domain;

namespace EZTripAPI.Repositories.Abstract
{
    public interface ITransportationRepository
    {
        bool AddUpdate(Transportation Transportation);
        bool Delete(int id);
        Transportation GetById(int id);
        IEnumerable<Transportation> GetAll();
    }
}

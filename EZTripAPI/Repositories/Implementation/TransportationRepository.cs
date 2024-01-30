using EZTripAPI.Models.Domain;
using EZTripAPI.Repositories.Abstract;

namespace EZTripAPI.Repositories.Implementation
{
    public class TransportationRepository : ITransportationRepository
    {
        private readonly DatabaseContext _ctx;
        public TransportationRepository(DatabaseContext ctx)
        {
            this._ctx = ctx;
        }
        public bool AddUpdate(Transportation transportation)
        {
            try
            {
                if (transportation.Id == 0)
                    _ctx.Transportation.Add(transportation);
                else
                    _ctx.Transportation.Update(transportation);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var record = GetById(id);
                if (record == null)
                    return false;
                _ctx.Transportation.Remove(record);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;

            }
        }

        public IEnumerable<Transportation> GetAll()
        {
            return _ctx.Transportation.ToList();
        }

        public Transportation GetById(int id)
        {
            return _ctx.Transportation.Find(id);
        }
    }
}

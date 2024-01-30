using EZTripAPI.Models.Domain;
using EZTripAPI.Repositories.Abstract;

namespace EZTripAPI.Repositories.Implementation
{
    public class HotelRepository : IHotelRepository
    {
        private readonly DatabaseContext _ctx;
        public HotelRepository(DatabaseContext ctx)
        {
            this._ctx = ctx;
        }
        public bool AddUpdate(Hotel hotel)
        {
            try
            {
                if (hotel.Id == 0)
                    _ctx.Hotel.Add(hotel);
                else
                    _ctx.Hotel.Update(hotel);
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
                _ctx.Hotel.Remove(record);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;

            }
        }

        public IEnumerable<Hotel> GetAll()
        {
            return _ctx.Hotel.ToList();
        }

        public Hotel GetById(int id)
        {
            return _ctx.Hotel.Find(id);
        }
    }
}

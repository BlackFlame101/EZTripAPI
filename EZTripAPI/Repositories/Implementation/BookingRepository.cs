using EZTripAPI.Models.Domain;
using EZTripAPI.Repositories.Abstract;

namespace EZTripAPI.Repositories.Implementation
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DatabaseContext _ctx;
        public BookingRepository(DatabaseContext ctx)
        {
            this._ctx = ctx;
        }
        public bool AddUpdate(Booking booking)
        {
            try
            {
                if (booking.Id == 0)
                    _ctx.Booking.Add(booking);
                else
                    _ctx.Booking.Update(booking);
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
                _ctx.Booking.Remove(record);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;

            }
        }

        public IEnumerable<Booking> GetAll(string term = "")
        {
            term = term.ToLower();
            var data = (from booking in _ctx.Booking
                        join
                        trip in _ctx.Trips
                        on booking.TripId equals trip.Id
                        where term == "" || booking.Trip_Name.ToLower().StartsWith(term)
                        select new Booking
                        {
                            Id = booking.Id,
                            Full_Name = booking.Full_Name,
                            Nbr_people = booking.Nbr_people,
                            Booked_at = booking.Booked_at,
                            TripId = booking.TripId,
                            Trip_Name = trip.Trip_Name,
                            Full_Price = booking.Full_Price
                        }
                        ).ToList();
            return data;
        }

        public Booking GetById(int id)
        {
            return _ctx.Booking.Find(id);
        }
    }
}

using EZTripAPI.Models.Domain;
using EZTripAPI.Repositories.Abstract;

namespace EZTripAPI.Repositories.Implementation
{
    public class TripsRepository : ITripsRepository
    {
        private readonly DatabaseContext _ctx;
        public TripsRepository(DatabaseContext ctx)
        {
            this._ctx = ctx;
        }
        public bool AddUpdate(Trips trips)
        {
            try
            {
                if (trips.Id == 0)
                    _ctx.Trips.Add(trips);
                else
                    _ctx.Trips.Update(trips);
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
                _ctx.Trips.Remove(record);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;

            }
        }

        public IEnumerable<Trips> GetAll(string term = "")
        {
            term = term.ToLower();
            var data = (from trips in _ctx.Trips
                        join
                        hotel in _ctx.Hotel
                        on trips.HotelId equals hotel.Id
                        join 
                        transportation in _ctx.Transportation
                        on trips.TransportationId equals transportation.Id
                        where term == "" || trips.Trip_Name.ToLower().StartsWith(term)
                        select new Trips
                        {
                            Id = trips.Id,
                            Trip_Name = trips.Trip_Name,
                            Destination_Name = trips.Destination_Name,
                            Nights_Stay = trips.Nights_Stay,
                            HotelId = trips.HotelId,
                            TransportationId = trips.TransportationId,
                            Hotel_Name = hotel.Hotel_Name,
                            Transportation_Type = transportation.Transportation_Type,
                            Price_Per_Person = trips.Price_Per_Person,
                            Department_Date = trips.Department_Date,
                            Overview = trips.Overview,
                            Trip_Image = trips.Trip_Image,

                        }
                        ).ToList();
            return data;
        }

        public Trips GetById(int id)
        {
            return _ctx.Trips.Find(id);
        }
    }
}

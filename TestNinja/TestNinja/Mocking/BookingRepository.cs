using System.Collections.Generic;
using System.Linq;

namespace TestNinja.Mocking
{
    public interface IBookingRepository
    {
        IQueryable<Booking> GetActiveBooking(int? exustingBookingId = null);
    }
    public class BookingRepository: IBookingRepository
    {
        public IQueryable<Booking> GetActiveBooking(int? exustingBookingId = null)
        {
            var unitOfWork = new UnitOfWork();

            var bookings = unitOfWork.Query<Booking>().Where(b => b.Status != "Cancelled");

            if (exustingBookingId.HasValue)
                bookings.Where(b => b.Id != exustingBookingId);

            return bookings;
        }
    }
}

using Moq;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    public class BookingHelper_OverlappingBookingsExistTests
    {
        private Mock<IBookingRepository> _bookingRepository;
        private BookingHelper _booking;
        private Booking _existingBooking;

        public BookingHelper_OverlappingBookingsExistTests()
        {
            _bookingRepository = new Mock<IBookingRepository>();
            _booking = new BookingHelper(_bookingRepository.Object);
            _existingBooking = new Booking()
            {
                Id = 2,
                ArrivalDate = ArriveOn(2023, 02, 15),
                DepartureDate = DepartOn(2023, 02, 20),
                Reference = "a"
            };
            _bookingRepository.Setup(b => b.GetActiveBooking(1)).Returns(new List<Booking>
            {
               _existingBooking
            }.AsQueryable());
        }

        [Fact]
        public void BookingStartAndFinishesBeforeAnExsitngBooking_ReturnEmptyString()
        {
            var result = _booking.OverlappingBookingsExist(
                new Booking()
                {
                    Id = 2,
                    ArrivalDate = Before(_existingBooking.ArrivalDate, days: 2),
                    DepartureDate = After(_existingBooking.DepartureDate),
                });

            Assert.Equal(result, string.Empty);
        }

        [Fact]
        public void BookingStartBeforeAndFinishesInTheMiddleOfAnExsitngBooking_ReturnExistingBookingReference()
        {
            var result = _booking.OverlappingBookingsExist(
                new Booking() {
                    Id = 2,
                    ArrivalDate = Before(_existingBooking.ArrivalDate),
                    DepartureDate = After(_existingBooking.ArrivalDate)
                });

            Assert.Equal(result, string.Empty);

        }

        [Fact]
        public void BookingStartBeforeAndFinishesAfterOfAnExsitngBooking_ReturnExistingBookingReference()
        {
            var result = _booking.OverlappingBookingsExist(
                new Booking()
                {
                    Id = 2,
                    ArrivalDate = Before(_existingBooking.ArrivalDate),
                    DepartureDate = After(_existingBooking.DepartureDate)
                });

            Assert.Equal(result, _existingBooking.Reference);

        }

        [Fact]
        public void BookingStartAndFinishesInTheMiddleOfAnExsitngBooking_ReturnExistingBookingReference()
        {
            var result = _booking.OverlappingBookingsExist(
                new Booking()
                {
                    Id = 2,
                    ArrivalDate = After(_existingBooking.ArrivalDate),
                    DepartureDate = Before(_existingBooking.DepartureDate)
                });

            Assert.Equal(result, _existingBooking.Reference);

        }

        private DateTime Before(DateTime date, int days = 1)
        {
            return date.AddDays(-days);
        }

        private DateTime After(DateTime date)
        {
            return date.AddDays(1);
        }
        private DateTime ArriveOn(int year, int mouth, int day)
        {
            return new DateTime(year, mouth, day, 14, 0, 0);
        }

        private DateTime DepartOn(int year, int mouth, int day)
        {
            return new DateTime(year, mouth, day, 10, 0, 0);
        }
    }

}
using NFluent;

namespace Hotel.UnitTests;

public class BehaviorTests
{
    [Fact]
    public void GivenValidBooking_WhenIBookARoom_ThenRoomIsBooked()
    {
        // Tests should be sensitive to changes in the behavior of the code under test
        var sut = new InMemoryBookingRepository();

        Check.That(sut.ReadMany()).IsEmpty();

        var roomId = RoomId.Generate();
        var bookingPeriod = BookingPeriod.Create(
            from: new DateOnly(2024, 2, 12),
            to: new DateOnly(2024, 2, 16)
        );

        sut.Write(Booking.Create(roomId, bookingPeriod));
        Check.That(sut.ReadMany()).HasSize(1);
    }
}

public class InMemoryBookingRepository
{
    private readonly HashSet<Booking> _bookings = [];
    public IEnumerable<Booking> ReadMany() => _bookings;
    public void Write(Booking booking) => _bookings.Add(booking);
}
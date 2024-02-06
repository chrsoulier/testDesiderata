namespace Hotel;

public record Booking(BookingId BookingId, RoomId IdRoom, BookingPeriod Period)
{
    public static Booking Create(RoomId idRoom, BookingPeriod period) => new(BookingId.Generate(), idRoom, period);
}

public record BookingId(Guid Id)
{
    public static BookingId Generate() => new(Guid.NewGuid());
}

public record Room(RoomId Id, uint RoomNumber)
{
    public static Room Create(uint roomNumber) => new(RoomId.Generate(), roomNumber);
}

public record RoomId(Guid Id)
{
    public static RoomId Generate() => new(Guid.NewGuid());
}

public record BookingPeriod(DateOnly From, DateOnly To)
{
    public static BookingPeriod Create(DateOnly from, DateOnly to) => new(from, to);
}
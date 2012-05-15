using System;
using System.Linq;

namespace Examples.Ex06Includes
{
    public class IncludesExample : Example
    {
        public override void Run()
        {
            var newBooking = CreateNewBooking();

            var existingBooking = GetBooking(newBooking.Id);
            OutputBooking("existingBooking", existingBooking, ConsoleColor.DarkBlue);

            var completeBooking = GetCompleteBooking(newBooking.Id);
            OutputBooking("completeBooking", completeBooking, ConsoleColor.DarkRed);
        }

        private Booking CreateNewBooking()
        {
            var newBooking = new Booking
            {
                Customer = CreateNewCustomer(),
                Room = CreateNewRoom(),
                CheckIn = DateTime.Now.AddDays(2),
                CheckOut = DateTime.Now.AddDays(4),
                LateArival = true
            };

            Db.UseOnceTo().Insert(newBooking);

            return newBooking;
        }

        private Booking GetBooking(Guid bookingId)
        {
            using(var session = Db.BeginSession())
            {
                return session.GetById<Booking>(bookingId);
            }
        }

        private Booking GetCompleteBooking(Guid bookingId)
        {
            using(var session = Db.BeginSession())
            {
                return session.Query<Booking>()
                        .Where(b => b.Id == bookingId)
                        .Include<Customer>(b => b.CustomerId)
                        .Include<Room>(b => b.RoomId).SingleOrDefault();
            }
        }

        private Customer CreateNewCustomer()
        {
            var newCustomer = new Customer
            {
                CustomerNo = "123",
                Firstname = "Daniel",
                Phone1 = new Phone("012", 12345),
                InvoiceAddress = { Street = "The Street 1", Zip = "12345", City = "Gothenburg", Country = "Sweden" }
            };

            Db.UseOnceTo().Insert(newCustomer);

            return newCustomer;
        }

        private Room CreateNewRoom()
        {
            var newRoom = new Room
            {
                RoomNo = "A123",
                Type = RoomTypes.Budget,
                BasePrice = 155.50m
            };

            Db.UseOnceTo().Insert(newRoom);

            return newRoom;
        }

        private void UpdateRoom(Room room)
        {
            Db.UseOnceTo().Update(room);
        }

        private static void OutputBooking(string title, Booking booking, ConsoleColor bg)
        {
            var oldBg = Console.BackgroundColor;
            Console.BackgroundColor = bg;

            Console.Out.WriteLine(title);
            Console.Out.WriteLine("BookingId = \t\t\t{0}", booking.Id);
            Console.Out.WriteLine("CustomerId = \t\t\t{0}", booking.CustomerId);
            Console.Out.WriteLine("RoomId = \t\t\t{0}", booking.RoomId);

            Console.Out.WriteLine("CheckIn = \t\t\t{0}", booking.CheckIn);
            Console.Out.WriteLine("CheckOut = \t\t\t{0}", booking.CheckOut);
            Console.Out.WriteLine("LateArival = \t\t\t{0}", booking.LateArival);

            Console.Out.WriteLine("CustomerNo = \t\t\t{0}", booking.Customer.CustomerNo);
            Console.Out.WriteLine("Phone1 = \t\t\t{0}", booking.Customer.Phone1);
            Console.Out.WriteLine("Phone2 = \t\t\t{0}", booking.Customer.Phone2);
            Console.Out.WriteLine("InvoiceAddress.Street = \t{0}", booking.Customer.InvoiceAddress.Street);
            Console.Out.WriteLine("InvoiceAddress.Zip = \t\t{0}", booking.Customer.InvoiceAddress.Zip);
            Console.Out.WriteLine("InvoiceAddress.City = \t\t{0}", booking.Customer.InvoiceAddress.City);
            Console.Out.WriteLine("InvoiceAddress.Country = \t{0}", booking.Customer.InvoiceAddress.Country);

            Console.Out.WriteLine("RoomNo = \t\t\t{0}", booking.Room.RoomNo);
            Console.Out.WriteLine("Type = \t\t\t\t{0}", booking.Room.Type);
            Console.Out.WriteLine("BasePrice = \t\t\t{0}", booking.Room.BasePrice.ToString("c"));

            Console.Out.WriteLine(string.Empty);

            Console.BackgroundColor = oldBg;
        }
    }
}
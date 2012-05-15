using System;

namespace Examples.Ex06Includes
{
    [Serializable]
    public class Booking
    {
        public Guid Id { get; set; }

        public Guid CustomerId
        {
            get { return Customer.Id; }
            private set { Customer.Id = value; }
        }

        public Customer Customer { get; set; }

        public Guid RoomId
        {
            get { return Room.Id; }
            private set { Room.Id = value; }
        }

        public Room Room { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public bool LateArival { get; set; }

        public Booking()
        {
            Customer = new Customer();
            Room = new Room();
        }
    }
}
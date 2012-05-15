using System;

namespace Examples.Ex06Includes
{
    [Serializable]
    public class Room
    {
        public Guid Id { get; set; }

        public string RoomNo { get; set; }

        public RoomTypes Type { get; set; }

        public decimal BasePrice { get; set; }
    }
}
using System;

namespace DemoApp
{
    enum RoomType {Economy, Business, Executive, Deluxe}

    class HotelRoom
    {
        public int Number;
        public RoomType Category = RoomType.Business; //field initializer - not allowed in struct
        public bool Taken;
    }

    class Program
    {
        static void PrintRoomInfo(HotelRoom room)
        {
            string status = room.Taken ? "Occupied" : "Available";
            float rate;
            switch(room.Category)
            {
                case RoomType.Economy:
                    rate = 31.95f;
                    break;
                case RoomType.Business:
                    rate = 52.95f;
                    break;
                case RoomType.Executive:
                    rate = 63.95f;
                    break;
                default:
                    rate = 84.95f;
                    break;
            }
            Console.WriteLine("Room {0} is of {1} class (${2}) and it's currently {3}.", room.Number, room.Category, rate, status);
        }

        static void Checkin(HotelRoom room)
        {
            if(!room.Taken)
                room.Taken = true;
        }

        static void Main(string[] args)
        {
            HotelRoom myroom = new HotelRoom(); //requires explicit allocation (on garbage-collected heap)
            myroom.Number = 503;
            PrintRoomInfo(myroom);
            Console.WriteLine("Checking into room {0}", myroom.Number);
            Checkin(myroom);
            PrintRoomInfo(myroom);
        }
    }
}

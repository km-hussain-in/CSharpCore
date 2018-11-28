using System;

namespace StructTypeTest
{
	enum RoomType {Economy, Business, Executive, Deluxe}

	struct HotelRoom
	{
		public int Number;
		public RoomType Category;
		public bool Taken;

		public void Print()
		{
			Console.WriteLine("Room {0} is of {1} class and is currently {2}.", Number, Category, Taken ? "occupied" : "available");
		}
	}

    	class Program
    	{
		static bool Checkin(ref HotelRoom room)
		{
			if(room.Taken)
				return false;
			return room.Taken = true;
		}

       		static void Main(string[] args)
        	{
            		HotelRoom myroom;
			myroom.Number = 501;
			myroom.Category = RoomType.Business;
			myroom.Taken = false;
			myroom.Print();
			Console.WriteLine($"Checking into room {myroom.Number}...");
			Checkin(ref myroom);
			myroom.Print();
        	}
    	}
}

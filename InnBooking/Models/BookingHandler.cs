using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnBooking.Models
{
    public class BookingHandler
    {
        #region Private Variables
        private static List<Rooms> roomList { get; set; }
        private static List<RoomBooking> roomBookings { get; set; }
        private static List<RoomOccupied> roomOccupied { get; set; }
        private static List<GnomeRoster> gnomeRoster { get; set; }

        #endregion

        #region Private Methods
        //Create fake initial Data
        private static void CreateRooms()
        {
            roomList = new List<Rooms>();
            if (roomList.Count == 0)
            {
                Rooms room1 = new Rooms(1, 2, 1);
                Rooms room2 = new Rooms(2, 2, 0);
                Rooms room3 = new Rooms(3, 1, 2);
                Rooms room4 = new Rooms(4, 1, 0);
                roomList.Add(room1);
                roomList.Add(room2);
                roomList.Add(room3);
                roomList.Add(room4);
            }
        }

        private static void CreateFakeRoomOccupied()
        {
            roomOccupied = new List<RoomOccupied>();
            if (roomOccupied.Count == 0)
            {
                RoomOccupied rooomOccupied1 = new RoomOccupied(1, 1, DateTime.Now, 2);
                RoomOccupied rooomOccupied2 = new RoomOccupied(2, 2, DateTime.Now, 2);
                RoomOccupied rooomOccupied3 = new RoomOccupied(3, 3, DateTime.Now, 1);
                RoomOccupied rooomOccupied4 = new RoomOccupied(4, 4, DateTime.Now, 1);
                roomOccupied.Add(rooomOccupied1);
                roomOccupied.Add(rooomOccupied2);
                roomOccupied.Add(rooomOccupied3);
                roomOccupied.Add(rooomOccupied4);
            }
        }

        private static void CreateFakeBooking()
        {
            roomBookings = new List<RoomBooking>();
            if (roomBookings.Count == 0)
            {
                RoomBooking booking1 = new RoomBooking(1, 1, DateTime.Now, DateTime.Now.Date.AddDays(1), 2, 1);
                RoomBooking booking2 = new RoomBooking(2, 2, DateTime.Now.AddDays(-1), DateTime.Now.Date.AddDays(1), 1,0);
                RoomBooking booking3 = new RoomBooking(3, 3, DateTime.Now.AddDays(-1), DateTime.Now.Date.AddDays(1), 1, 0);
                RoomBooking booking4 = new RoomBooking(3, 3, DateTime.Now.AddDays(4), DateTime.Now.Date.AddDays(5), 1, 0);
                roomBookings.Add(booking1);
                roomBookings.Add(booking2);
                roomBookings.Add(booking3);
                roomBookings.Add(booking4);
            }
        }

        private static void CreateGnomeRoster()
        {
            gnomeRoster = new List<GnomeRoster>();
            gnomeRoster.Add(new GnomeRoster(1, DateTime.Now, 7, 8));
        }

       

        //Checks if the Gnome is available that day
        private bool CheckIfGnomeAvailable(int GnomeId, DateTime datetoCheck)
        {
            bool available = false;
            foreach(GnomeRoster item in gnomeRoster)
            {
                if(item.GnomeId == GnomeId && item.ShiftStartDate <= datetoCheck)
                {
                    available = true;
                    break;
                }
            }
            return available;
        }

        //Gets the number of max hours a gnome can work for a day
        private int GetGnomesMaxHours(int GnomeId, DateTime datetoCheck)
        {
            int  maxHours = 0;
            foreach (GnomeRoster item in gnomeRoster)
            {
                if (item.GnomeId == GnomeId && item.ShiftStartDate.Date == datetoCheck.Date)
                {
                    maxHours = item.MaxHoursWorking;
                    break;
                }
            }
            return maxHours;
        }

        private int GetMaxNumberofPplInInn()
        {
            int maxPpl = 0;
            foreach (Rooms room in roomList)
            {
                maxPpl += room.RoomCapacity;
            }
            return maxPpl;
        }

        private int GetMaxNumberofLuggagesInInn()
        {
            int maxLuggage = 0;
            foreach (Rooms room in roomList)
            {
                maxLuggage += room.LuggageCount;
            }
            return maxLuggage;
        }

        private void AddBooking(DateTime checkinDate, DateTime checkOutDate, int luggageCount, int personCount)
        {
            foreach (Rooms rm in roomList)
            {
                if (rm.RoomCapacity > personCount && rm.LuggageCount > luggageCount)
                {
                    RoomBooking booking = new RoomBooking(roomBookings.Count + 1, rm.RoomNumber, checkinDate,

checkOutDate, personCount, luggageCount);
                    roomBookings.Add(booking);
                }

            }
        }

        private void AlterBooking(DateTime checkinDate, DateTime checkOutDate, int roomNumber, int luggageCount, int

personCount)
        {
            RoomBooking booking = new RoomBooking(roomBookings.Count + 1, roomNumber, checkinDate, checkOutDate,

personCount, luggageCount);
            roomBookings.Add(booking);
        }

        private int CheckifBookingHasSpaceforPerson(int numberPplToCheck, int RoomNumber)
        {

            if (GetRoomCapacity(RoomNumber) - numberPplToCheck > 0)
                return GetRoomCapacity(RoomNumber) - numberPplToCheck;

            return -1;
        }

        private int CheckifBookingHasSpaceforLuggage(int numberLuggageToCheck, int RoomNumber)
        {

            if (GetRoomLuggageCapacity(RoomNumber) - numberLuggageToCheck > 0)
                return GetRoomLuggageCapacity(RoomNumber) - numberLuggageToCheck;

            return -1;
        }

        private int GetRoomCapacity(int RoomNumber)
        {
            foreach (Rooms room in roomList)
            {
                if (room.RoomNumber == RoomNumber)
                    return room.RoomCapacity;
            }
            return -1;
        }

        private int GetRoomLuggageCapacity(int RoomNumber)
        {
            foreach (Rooms room in roomList)
            {
                if (room.RoomNumber == RoomNumber)
                    return room.LuggageCount;
            }
            return -1;
        }

        private int CheckifRoomHasSpaceforPerson(int numberPplToCheck, int RoomNumber)
        {
            foreach (Rooms room in roomList)
            {
                if (room.RoomNumber == RoomNumber && room.RoomCapacity >= numberPplToCheck)
                    return room.RoomCapacity;
            }
            return -1;
        }

        private int CheckifRoomHasSpaceforLuggage(int numberLuggageToCheck, int RoomNumber)
        {
            foreach (Rooms room in roomList)
            {
                if (room.RoomNumber == RoomNumber && room.LuggageCount >= numberLuggageToCheck)
                    return room.LuggageCount;
            }
            return -1;
        }

        #endregion privatemethods

        #region Public Methods
        //Get the List of  Rooms with either open luggage or open space on that day
        public List<Rooms> GetAvailableRooms(DateTime checkinDate)
        {
           
            BookingHandler.CreateRooms();
            BookingHandler.CreateFakeBooking();
            List<Rooms> availableroomList = new List<Rooms>();
            List<int> potentialrooomList = new List<int>();
            foreach (RoomBooking rb in roomBookings)
            {
                Rooms availableroom = new Rooms();
                bool isRoomOrLuggageSpaceAvailable = false;
                if (rb.CheckinTime.Date <= checkinDate.Date && checkinDate.Date < rb.CheckoutTime.Date)
                {
                    potentialrooomList.Add(rb.RoomNumber);
                    int roomCapacity = CheckifBookingHasSpaceforPerson(rb.NumberofPPl, rb.RoomNumber);
                    int luggageCapacity = CheckifBookingHasSpaceforLuggage(rb.LuggageCount, rb.RoomNumber);

                    if (roomCapacity > 0)
                    {
                        List<int> getGnomeSchedule = GetGnomeSchedule(1, checkinDate);
                        if (getGnomeSchedule.Contains(rb.RoomNumber))
                        {
                            availableroom.RoomNumber = rb.RoomNumber;
                            availableroom.RoomCapacity = roomCapacity;
                            isRoomOrLuggageSpaceAvailable = true;
                        }
                    }
                    if (luggageCapacity > 0) //No need to check gnome's cleaning schedule here
                    {
                        availableroom.RoomNumber = rb.RoomNumber;
                        availableroom.LuggageCount = luggageCapacity;
                        isRoomOrLuggageSpaceAvailable = true;
                    }
                }
                if (isRoomOrLuggageSpaceAvailable)
                    availableroomList.Add(availableroom);
            }

            if (potentialrooomList.Count != roomList.Count) // there are some unbooked rooms here, those are available for that date
            {
                foreach (Rooms room in roomList)
                {
                    if (!potentialrooomList.Contains(room.RoomNumber))
                    {
                        availableroomList.Add(room);
                    }
                }
            }
            return availableroomList;
        }

      
        //Gives the room numbers the Gnome can work on a given Date
        public List<int> GetGnomeSchedule(int GnomeId, DateTime dateToCheck)
        {
            CreateGnomeRoster();
            CreateFakeRoomOccupied();
            List<int> roomsToClean = new List<int>();
            if (CheckIfGnomeAvailable(GnomeId, dateToCheck))
            {
                int maxGnomeHours = GetGnomesMaxHours(GnomeId, dateToCheck);
                double totalHoursCleaning = 0;
                foreach(RoomOccupied room in roomOccupied)
                {
                    if(!room.isCleaned && room.CheckoutTime.Date == dateToCheck.Date && totalHoursCleaning < maxGnomeHours)
                    {
                        totalHoursCleaning += 1 + (room.NumberofPpl) * 0.5;
                        roomsToClean.Add(room.RoomNumber);
                    }
                }
            }
            return roomsToClean;
        }

       

        public List<int> GetBookingRooms(int peopleCount, DateTime checkinDate, DateTime checkOutDate, int luggageCount)
        {
            
            List<int> vacantroomList = new List<int>();
            if (checkinDate.Date < DateTime.Now.Date || checkOutDate.Date < DateTime.Now.Date || checkOutDate < checkinDate) //compare dates if trying to book in the past throw error
            {
                 vacantroomList.Add(-3);             
            }

            if (peopleCount == 1 && luggageCount > 2) // max number of luggages person is just 2
            {
                vacantroomList.Add(-1);              
            }
            int orginalNumberofppl = peopleCount;
            List<int> potentialRoomList = new List<int>();

            BookingHandler.CreateRooms();
            BookingHandler.CreateFakeBooking();

            if (vacantroomList.Count == 0)
            {
                if (peopleCount <= GetMaxNumberofPplInInn() && luggageCount <= GetMaxNumberofLuggagesInInn())
                {

                    foreach (RoomBooking rb in roomBookings)
                    {
                        int roomCapacity = CheckifBookingHasSpaceforPerson(rb.NumberofPPl, rb.RoomNumber);
                        int luggageCapacity = CheckifRoomHasSpaceforLuggage(rb.LuggageCount, rb.RoomNumber);

                        if (rb.CheckinTime.Date <= checkinDate.Date && checkinDate.Date < rb.CheckoutTime.Date && roomCapacity >= peopleCount &&
                        luggageCapacity >= luggageCount)
                        {
                            potentialRoomList.Add(rb.RoomNumber);
                            List<int> getGnomeSchedule = GetGnomeSchedule(1, checkinDate.Date);
                            if (getGnomeSchedule.Contains(rb.RoomNumber))
                            {
                                vacantroomList.Add(rb.RoomNumber);
                            }
                        }
                    }
                    //Inn is empty, get available rooms , or the person coud nor fit in any room booking
                   
                    while (peopleCount > 0)
                    {
                        foreach (Rooms rm in roomList)
                        {
                            if (!potentialRoomList.Contains(rm.RoomNumber) && (!vacantroomList.Contains(rm.RoomNumber)))
                            {
                                if (orginalNumberofppl != 1 && rm.LuggageCount != 0 && rm.LuggageCount < luggageCount)
                                {

                                    luggageCount = luggageCount - rm.LuggageCount;

                                    if (peopleCount == rm.RoomCapacity)
                                    {
                                        peopleCount = peopleCount - rm.LuggageCount;                                       
                                    }

                                    else if (peopleCount > rm.RoomCapacity)
                                    {
                                        peopleCount = peopleCount - rm.RoomCapacity;                                        
                                    }

                                    else if (peopleCount < rm.RoomCapacity)
                                    {
                                        peopleCount = rm.RoomCapacity - peopleCount;                                      
                                    }

                                    vacantroomList.Add(rm.RoomNumber);

                                }
                                else if ( (rm.LuggageCount != 0 && rm.LuggageCount > luggageCount) || (rm.LuggageCount == luggageCount))
                                {
                                    luggageCount = luggageCount - rm.LuggageCount;

                                    if (peopleCount == rm.RoomCapacity)
                                    {
                                        peopleCount = 0;
                                    }
                                    else
                                    {
                                        peopleCount = peopleCount - rm.RoomCapacity;
                                    }

                                    vacantroomList.Add(rm.RoomNumber);
                                }                               


                                if (peopleCount <= 0 && luggageCount <= 0) { return vacantroomList; }

                                if (peopleCount <= 0 && luggageCount >= 0) { vacantroomList.Clear(); vacantroomList.Add(-1); return vacantroomList; }
                            }
                        }
                    }

                }
                else //exceeds inn capacity
                {
                    vacantroomList.Add(-2);
                }
            }
            return vacantroomList;
        }

        //This is not used this is for the future
        public void BookRoom(int NumberOfPpl, DateTime checkinDate, DateTime checkOutDate, int luggageCount)
        {
            //First check all the booked rooms to see if we can put a person and their luggage there
            foreach (RoomBooking rb in roomBookings)
            {
                if (rb.CheckinTime <= checkinDate && CheckifBookingHasSpaceforPerson(rb.NumberofPPl, rb.RoomNumber) > 0

&&
                CheckifRoomHasSpaceforLuggage(rb.NumberofPPl, rb.RoomNumber) > 0)
                {
                    AlterBooking(checkinDate, checkOutDate, rb.RoomNumber, luggageCount, NumberOfPpl);
                }
            }

            //If there are no bookings, then we can put them in a room
            AddBooking(checkinDate, checkOutDate, luggageCount, NumberOfPpl);
        }

        #endregion publicmethods
    }
}

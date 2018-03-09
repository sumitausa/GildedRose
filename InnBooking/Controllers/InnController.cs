using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnBooking.Controllers
{
    public class InnController : Controller
    {
   
        BookingHandler BookingHandler = new BookingHandler();
     
       

        //List rooms available for the criteria
        [HttpGet("[action]")]
        public List<int> GetBooking(DateTime checkInDate,DateTime checkoutDate, int personCount, int luggageCount)
        {
            return BookingHandler.GetBookingRooms(personCount, checkInDate, checkoutDate, luggageCount);         
        }


        //Get all rooms that have some sort of space, availability for a given date
        [HttpGet("[action]")]
        public List<Rooms> ViewAllAvailableRooms(DateTime checkInDate)
        {
            return BookingHandler.GetAvailableRooms(checkInDate);          
        }


        //Given an id and a date list the gnome schedule
        //For now there is a single gnome in the system
        [HttpGet("[action]")]
        public List<int> GetGnomeSchedule(int GnomeId, DateTime dateToCheck)
        {
            return BookingHandler.GetGnomeSchedule(GnomeId, dateToCheck);          
        }

      

        public IActionResult Index()
        {
            return View();
        }
    }
}
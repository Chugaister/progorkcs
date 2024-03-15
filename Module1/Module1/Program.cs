using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module1
{


    class CalendarEvent
    {
        public enum CustomDayOfWeeek
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        public string EventNam
        {
            get; set;
        }

        public CalendarEvent.CustomDayOfWeeek EventName
        {
            get; set;
        }
        
        public CalendarEvent(string eventName, CalendarEvent.CustomDayOfWeeek eventDay)
        {
            EventNam = eventName;
            EventName = eventDay;
        }

        public void PrintEventDetails()
        {
            Console.WriteLine($"Подія {EventNam} відбудеться у {EventName}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CalendarEvent e = new CalendarEvent("П'ємо пиво", CalendarEvent.CustomDayOfWeeek.Friday);
            e.PrintEventDetails();
            Console.Read();
        }
    }
}

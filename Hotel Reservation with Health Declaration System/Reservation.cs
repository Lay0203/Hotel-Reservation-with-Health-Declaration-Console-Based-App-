using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hotel_Reservation_with_Health_Declaration_System
{
    internal class Reservation
    {
        private List<Customers> reservations;
        public Reservation()
        {
            reservations = new List<Customers>();
        }

        public void AddCustomer()
        {
            Console.Write("\tVisit Date(MMDDYYYY): ");
            string visit_dateStr = Console.ReadLine();
            DateTime visit_date;
            if (!DateTime.TryParseExact(visit_dateStr, "MMddyyyy", null, System.Globalization.DateTimeStyles.None, out visit_date))
            {
                Console.WriteLine("\tInvalid Date Format!");
                return;
            }

            Console.Write("\tName: ");
            string name = Console.ReadLine();

            Console.Write("\tGender: ");
            string gender = Console.ReadLine();

            Console.Write("\tAge: ");
            int age;
            if (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("\tInvalid age format!");
                return;
            }

            Console.Write("\tMobile Number: ");
            string mobileNum = Console.ReadLine();

            Console.Write("\tBody Temperature: ");
            float bodyTemp;
            if (!float.TryParse(Console.ReadLine(), out bodyTemp))
            {
                Console.WriteLine("\tInvalid body temperature format!");
                return;
            }

            Console.Write("\tCovid-19 Encounter (YES/NO): ");
            string covidEncounterStr = Console.ReadLine();
            bool covidEncounter = covidEncounterStr.Equals("YES", StringComparison.OrdinalIgnoreCase);

            Console.Write("\tRoom Type (ECONOMY, DELUXE, EXECUTIVE): ");
            string roomType = Console.ReadLine();

            while (true)
            {
                try
                {
                    Console.WriteLine("\n\t1.Save Reservation");
                    Console.WriteLine("\t2.Cancel Reservation");
                    Console.Write("\tEnter your Choice: ");
                    int choice = int.Parse(Console.ReadLine());

                    if(choice == 1)
                    {
                        Customers reservation = new Customers(visit_date, name, gender, mobileNum, age, bodyTemp, covidEncounter, roomType.ToUpper());
                        reservations.Add(reservation);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\tReservation Added Successfully!");
                        break;
                    }
                    else if(choice == 2)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\tReservation Cancelled");
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\tInvalid Choice! Please Try Again.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                catch
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tInvalid Choice! Please Try Again.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }       
        }

        public void DeleteCustomer()
        {
            Console.Write("\tEnter Visit Date(MMDDYYYY): ");
            string visit_dateStr = Console.ReadLine();
            DateTime visit_date;
            if (!DateTime.TryParseExact(visit_dateStr, "MMddyyyy", null, System.Globalization.DateTimeStyles.None, out visit_date))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tInvalid Date Format!");
                return;
            }

            Console.Write("\tEnter Mobile Number: ");
            string mobileNumber = Console.ReadLine();

            Customers reservationToDelete = reservations.Find(reservation => reservation.VisitDate == visit_date && reservation.MobileNumber == mobileNumber);

            if (reservationToDelete == null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\tNo Reservation Found!");
                return;
            }

            reservations.Remove(reservationToDelete);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\tReservation Deleted Successfully!");

        }

        public void ShowList()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\tReservation List:");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Customers reservation in reservations)
            {
                Console.WriteLine("\t" + reservation.ToString());
            }
        }

        private decimal RoomRate(string roomType, int age)
        {
            int roomRate = 0;

            switch (roomType)
            {
                case "ECONOMY":
                    roomRate = age >= 18 ? 300 : 250;
                    break;
                case "DELUXE":
                    roomRate = age >= 18 ? 450 : 375;
                    break;
                case "EXECUTIVE":
                    roomRate = age >= 18 ? 700 : 600;
                    break;
            }

            return roomRate;
        }

        public void GenerateReport()
        {
            int totalEconomyCustomers = 0;
            int totalDeluxeCustomers = 0;
            int totalExecutiveCustomers = 0;
            decimal totalEconomyEarnings = 0;
            decimal totalDeluxeEarnings = 0;
            decimal totalExecutiveEarnings = 0;
            int totalAdults = 0;
            int totalChildren = 0;
            int totalMales = 0;
            int totalFemales = 0;

            foreach(Customers reservation in reservations)
            {
                switch (reservation.RoomType)
                {
                    case "ECONOMY":
                        totalEconomyCustomers++;
                        totalEconomyEarnings += RoomRate(reservation.RoomType, reservation.Age);
                        break;
                    case "DELUXE":
                        totalDeluxeCustomers++;
                        totalDeluxeEarnings += RoomRate(reservation.RoomType, reservation.Age);
                        break;
                    case "EXECUTIVE":
                        totalExecutiveCustomers++;
                        totalExecutiveEarnings += RoomRate(reservation.RoomType, reservation.Age);
                        break;
                }

                if (reservation.Age >= 18)
                    totalAdults++;
                else
                    totalChildren++;

                if (reservation.Gender.Equals("MALE", StringComparison.OrdinalIgnoreCase))
                    totalMales++;
                else if (reservation.Gender.Equals("FEMALE", StringComparison.OrdinalIgnoreCase))
                    totalFemales++;

            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\tReservation Report:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\tTotal ECONOMY customers: {totalEconomyCustomers}\t\tTotal ECONOMY earnings: {totalEconomyEarnings}");
            Console.WriteLine($"\tTotal DELUXE customers: {totalDeluxeCustomers}\t\tTotal DELUXE earnings: {totalDeluxeEarnings}");
            Console.WriteLine($"\tTotal EXECUTIVE customers: {totalExecutiveCustomers}\t\tTotal EXECUTIVE earnings: {totalExecutiveEarnings}");

            Console.WriteLine($"\n\tTotal number of Adult: {totalAdults}\t\tTotal number of MALE: {totalMales}");
            Console.WriteLine($"\tTotal number of Children: {totalChildren}\t\tTotal number of FEMALE: {totalFemales}");

            decimal grandTotalEarnings = totalEconomyEarnings + totalDeluxeEarnings + totalExecutiveEarnings;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n\tGRAND TOTAL EARNINGS: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(grandTotalEarnings);
            Console.WriteLine();
        }
    }
}

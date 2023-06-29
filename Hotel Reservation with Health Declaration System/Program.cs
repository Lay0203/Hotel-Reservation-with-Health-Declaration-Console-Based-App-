namespace Hotel_Reservation_with_Health_Declaration_System
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Reservation myHotel = new Reservation();

            bool exit = false;

            while (exit!=true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\tWELCOME TO HOTEL DEL LUNA");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\tPlease see the price below.");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\tEconomy\t\tRate");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\tAdult\t\t300");
                Console.WriteLine("\tChildren\t250");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\tDeluxe\t\tRate");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\tAdult\t\t450");
                Console.WriteLine("\tChildren\t375");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\tExecutive\tRate");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\tAdult\t\t700");
                Console.WriteLine("\tChildren\t600");

                Console.WriteLine("\n\t1. Add Reservation");
                Console.WriteLine("\t2. Delete Reservation");
                Console.WriteLine("\t3. Show Reservation List");
                Console.WriteLine("\t4. Generate Report");
                Console.WriteLine("\t5. Exit");
                Console.Write("\n\tEnter your Choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        myHotel.AddCustomer();
                        break;
                    case 2:
                        myHotel.DeleteCustomer(); 
                        break;
                    case 3:
                        Console.Clear();
                        myHotel.ShowList();
                        break;
                    case 4:
                        Console.Clear();
                        myHotel.GenerateReport();
                        break;
                    case 5:
                        exit = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\tThank you for using the system!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\n\tInvalid Choice! Please Try Again.");
                        break;

                }

            }

        }
    }
}
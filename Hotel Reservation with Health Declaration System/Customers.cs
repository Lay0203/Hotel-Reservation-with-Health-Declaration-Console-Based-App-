using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_with_Health_Declaration_System
{
    internal class Customers
    {
        public DateTime VisitDate { get; set; }
        private string Name { get; set; }
        public string Gender { get; set; }
        public string MobileNumber { get; set; }
        public int Age { get; set; }
        private float BodyTemp { get; set; }
        private bool CovidEncounter { get; set; }
        public string RoomType { get; set; }


        public Customers(DateTime visit_date, string name, string gender, string mobile_number, int age, float body_temp, bool covid_encounter, string room_type) 
        {
        
            this.VisitDate = visit_date;
            this.Name = name;
            this.Gender = gender;
            this.Age = age;
            this.MobileNumber = mobile_number;
            this.BodyTemp = body_temp;
            this.CovidEncounter = covid_encounter;
            this.RoomType = room_type;
        
        }

        public override string ToString()
        {
            return $"Visit Date: {VisitDate:MM/dd/yyyy}, Name: {Name}, Gender: {Gender}, Mobile Number: {MobileNumber}, Age: {Age}, Body Temperature: {BodyTemp}, Covid-19 Encounter: {(CovidEncounter ? "Yes" : "No")}, Room Type: {RoomType}";
        }

    }
}

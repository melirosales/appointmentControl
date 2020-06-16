using System;
namespace appointmentControl.Backend.Model
{
    public class Patient
    {
        public Patient()
        {
            Pk_Patient = 0;
            Dob = Convert.ToDateTime("1900-01-01"); ;
            Name = "";
            Last_Name = "";
            Phone = "";
            Email = "";
            Identity = "";
            Creation_Date = Convert.ToDateTime("1900-01-01");
        }
        public Int32 Pk_Patient { get; set; }
        public DateTime Dob { get; set; }
        public String Name { get; set; }
        public String Last_Name { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String Identity { get; set; }
        public DateTime Creation_Date { get; set; }
    }
}

using System;
namespace appointmentControl.Backend.Model
{
    public class Appointment_History
    {
        public Appointment_History()
        {
            Pk_Appointment_History = 0;
            Fk_Medical_Service = 0;
            Fk_Patient = 0;
            Date = Convert.ToDateTime("1900-01-01");
            Hour = new TimeSpan(0, 0, 0);
        }
        public Int32 Pk_Appointment_History { get; set; }
        public Int32 Fk_Medical_Service { get; set; }
        public Int32 Fk_Patient { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Hour { get; set; }
    }
}

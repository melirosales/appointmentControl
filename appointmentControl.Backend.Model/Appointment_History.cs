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
            Hour = "";
            Option=0;
            Canceled=false;
        }
        public Int32 Pk_Appointment_History { get; set; }
        public Int32 Fk_Medical_Service { get; set; }
        public string Medical_Service_Name { get; set; }
        public bool Can_Cancel { get; set; }
        public bool Canceled { get; set; }
        public Int32 Fk_Patient { get; set; }
        public DateTime Date { get; set; }
        public string Hour { get; set; }
        public int Option { get; set; }
    }
}

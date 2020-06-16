using System;
namespace appointmentControl.Backend.Model
{
    public class Medical_Service
    {
        public Medical_Service()
        {
            Pk_Medical_Service = 0;
            Name = "";
        }
        public Int32 Pk_Medical_Service { get; set; }
        public String Name { get; set; }
    }
}

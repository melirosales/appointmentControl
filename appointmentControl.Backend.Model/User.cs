using System;
namespace appointmentControl.Backend.Model
{
    public class User
    {
        public User()
        {
            Pk_User = 0;
            User_Name = "";
            Password = "";
            Password_Salt = "";
            Full_Name = "";
        }
        public Int32 Pk_User { get; set; }
        public String User_Name { get; set; }
        public String Password { get; set; }
        public String Password_Salt { get; set; }
        public String Full_Name { get; set; }
    }
}

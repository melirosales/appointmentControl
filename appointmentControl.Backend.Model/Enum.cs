using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appointmentControl.Backend.Model
{
    public class Enum
    { 
        
        public enum Operation
        {
            Save,
            List,
            Get,
            Delete,
        }

        public enum Status
        {
            Success,
            Failed
        } 

    }
}

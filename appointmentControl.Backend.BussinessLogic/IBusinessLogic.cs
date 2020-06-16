using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appointmentControl.Backend.Model;

namespace appointmentControl.Backend.BussinessLogic
{

public interface IBusinessLogic : IDisposable
    {
        Task<Model.Message> DoWork(Model.Message message);
        Task<Model.Message> List(Model.Message message);
        Task<Model.Message> Get(Model.Message message);
        Task<Model.Message> Save(Model.Message message);
        Task<Model.Message> Delete(Model.Message message);
    }

}
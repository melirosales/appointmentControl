using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appointmentControl.Backend.Model;
using static appointmentControl.Backend.Model.Enum;
using appointmentControl.Backend.DataAccess.Repository;
using appointmentControl.Backend.Extender;
namespace appointmentControl.Backend.BussinessLogic
{
    public class User : IBusinessLogic
    {
        #region Region [Methods]

        public async Task<Model.Message> DoWork(Message message)
        {
            try
            {
                switch (message.Operation)
                {
                    case Operation.List:
                        return await List(message);
                    case Operation.Get:
                        return await Get(message);
                    case Operation.Save:
                        return await Save(message);
                    case Operation.Delete:
                        return await Delete(message);
                    default:
                        var resultMessage = new Message();
                        resultMessage.Status = Status.Failed;
                        resultMessage.Result = "Operación no soportada";
                        resultMessage.MessageInfo = string.Empty;
                        return resultMessage;
                }
            }
            catch (Exception ex)
            {
                var resultMessage = new Message();
                resultMessage.Status = Status.Failed;
                resultMessage.Result = string.Format("{0}", ex.Message);
                resultMessage.MessageInfo = string.Empty;
                return resultMessage;
            }
        }

     

        public async virtual Task<Message> Get(Message message)
        {
            try
            {
                var resultMessage = new Message();
                var model = message.DeSerializeObject<Model.User>();
                bool isValid = false;
                using (var repository = new User_Repository(message.Connection))
                {
                    var returnObject = await repository.Get(model);

                    Encryption encryption = new Encryption("8464261197043003");
                    string password = encryption.CreatePasswordHash(model.Password, returnObject.Password_Salt, "");
                    isValid = password == returnObject.Password;
                    if (!isValid)
                    {
                        returnObject = new Model.User();
                    }

                    resultMessage.Status = Status.Success;
                    resultMessage.Result = "Proceso efectuado satisfactoriamente...";
                    resultMessage.MessageInfo = returnObject.SerializeObject();
                    return resultMessage;
                }
            }
            catch (Exception ex)
            {
                var resultMessage = new Message();
                resultMessage.Status = Status.Failed;
                resultMessage.Result = string.Format("{ 0}", ex.Message);
                resultMessage.MessageInfo = string.Empty;
                return resultMessage;
            }
        }

        public Task<Message> List(Message message)
        {
            throw new NotImplementedException();
        }

        public Task<Message> Save(Message message)
        {
            throw new NotImplementedException();
        }

        public Task<Message> Delete(Message message)
        {
            throw new NotImplementedException();
        }


 
        #endregion
        #region Region [Dispose]
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
        }        ~User()
        {
            this.Dispose(false);
        }
        #endregion
    }
}

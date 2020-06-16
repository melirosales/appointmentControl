using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace appointmentControl.Backend.BussinessLogic
{
    public class DoWorkService : IDisposable
    {
        #region Region [Variables]
        private bool disposed;
        IBusinessLogic businesslogic; 
        #endregion

        #region Region [Metodos]
        public async Task<Model.Message> DoWork(Model.Message message)
        {
            try
            {

                var nameSpace = Assembly.GetExecutingAssembly().GetName().Name;
                var CadenaObjeto = string.Format("{0}.{1}", nameSpace, message.BusinessLogic);
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath( Assembly.GetExecutingAssembly().Location);
                var type = assembly.GetType(CadenaObjeto);
                dynamic obj = Activator.CreateInstance(type);

                return await obj.DoWork(message);
            }
            catch (Exception ex)
            {
                return new Model.Message(new Exception(string.Format("Mensaje del sistema: {0}", ex.Message)));
            }
        }
        #endregion

        #region Region [Dispose]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DoWorkService()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
        }
        #endregion
    }
}

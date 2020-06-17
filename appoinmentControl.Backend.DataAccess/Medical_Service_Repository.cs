using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using appointmentControl.Backend.Model;

namespace appointmentControl.Backend.DataAccess.Repository
{

    public class Medical_Service_Repository : IDisposable
    {

        #region Region [Variables] 
        private string ConnectionString { get; set; }
        #endregion

        #region Region [Constructor]
        public Medical_Service_Repository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        #endregion

        #region Region [Methods]

        public async Task<IEnumerable<Medical_Service>> List(Medical_Service model)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query<
                    Model.Medical_Service>
                    ("SP_MEDICAL_SERVICE_GET", 
                    commandType: CommandType.StoredProcedure);
                return await Task.FromResult<IEnumerable<Medical_Service>>(result.ToList());
            }
        }
 
 
 
        #endregion
        #region Region [Dispose]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~Medical_Service_Repository()
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

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

        public async Task<Model.Medical_Service> Get(Model.Medical_Service model)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query<
                    appointmentControl.Backend.Model.Medical_Service>
                    ("PA_CON_MEDICAL_SERVICE_GET",
                    param: new
                    {
                        P_PK_MEDICAL_SERVICE = model.Pk_Medical_Service,
                        P_NAME = model.Name,
                    },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                return await Task.FromResult<Model.Medical_Service>(result);
            }
        }

        public async Task Save(Model.Medical_Service model)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.QueryAsync<
                    appointmentControl.Backend.Model.Medical_Service>
                    ("PA_MAN_MEDICAL_SERVICE_SAVE",
                    param: new
                    {
                        P_PK_MEDICAL_SERVICE = model.Pk_Medical_Service,
                        P_NAME = model.Name,
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Delete(Model.Medical_Service model)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(
                sql: "PA_MEDICAL_SERVICE_DELETE",
                param: new
                {
                    P_PK_MEDICAL_SERVICE = model.Pk_Medical_Service
                },
                commandType: CommandType.StoredProcedure);
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

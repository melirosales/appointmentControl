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

    public class Patient_Repository : IDisposable
    {

        #region Region [Variables] 
        private string ConnectionString { get; set; }
        #endregion

        #region Region [Constructor]
        public Patient_Repository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        #endregion

        #region Region [Methods]

        public async Task<IEnumerable<Patient>> List(Patient model)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query<
                    Model.Patient>
                    ("SP_PATIENT_GET",
                    param: new
                    {
                        P_PK_PATIENT = model.Pk_Patient, 
                        P_NAME = model.Name, 
                        P_IDENTITY = model.Identity, 
                    },
                    commandType: CommandType.StoredProcedure);
                return await Task.FromResult<IEnumerable<Patient>>(result.ToList());
            }
        }

        public async Task<Model.Patient> Get(Model.Patient model)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query<
                    appointmentControl.Backend.Model.Patient>
                    ("SP_PATIENT_GET",
                    param: new
                    {
                        P_PK_PATIENT = model.Pk_Patient, 
                        P_NAME = model.Name, 
                        P_IDENTITY = model.Identity, 
                    },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                return await Task.FromResult<Model.Patient>(result);
            }
        }
 
        #endregion
        #region Region [Dispose]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~Patient_Repository()
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

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

    public class Appointment_History_Repository : IDisposable
    {

        #region Region [Variables]
        private string ConnectionString { get; set; }
        #endregion

        #region Region [Constructor]
        public Appointment_History_Repository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        #endregion

        #region Region [Methods]

        public async Task<IEnumerable<Appointment_History>> List(Appointment_History model)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query<
                    Model.Appointment_History>
                    ("SP_APPOINTMENT_HISTORY_GET",
                    param: new
                    {  
                        P_FK_PATIENT = model.Fk_Patient ,
                    },
                    commandType: CommandType.StoredProcedure);
                return await Task.FromResult<IEnumerable<Appointment_History>>(result.ToList());
            }
        } 
        public async Task Save(Model.Appointment_History model)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.QueryAsync<
                    appointmentControl.Backend.Model.Appointment_History>
                    ("SP_APPOINTMENT_HISTORY_SAVE",
                    param: new
                    {
                        P_PK_APPOINTMENT_HISTORY = model.Pk_Appointment_History,
                        P_FK_MEDICAL_SERVICE = model.Fk_Medical_Service,
                        P_FK_PATIENT = model.Fk_Patient,
                        P_DATE = model.Date,
                        P_HOUR = model.Hour,
                        P_OPTION=model.Option
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
        ~Appointment_History_Repository()
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

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

    public class User_Repository : IDisposable
    {

        #region Region [Variables] 
        private string ConnectionString { get; set; }
        #endregion

        #region Region [Constructor]
        public User_Repository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        #endregion

        #region Region [Methods]
 

        public async Task<Model.User> Get(Model.User model)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query<
                    appointmentControl.Backend.Model.User>
                    ("SP_LOGIN_USER",
                    param: new
                    { 
                        P_USER_NAME = model.User_Name
                    },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                return await Task.FromResult<Model.User>(result);
            }
        }
 
 
        #endregion
        #region Region [Dispose]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~User_Repository()
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

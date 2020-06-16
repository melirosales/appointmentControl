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

        public async Task<IEnumerable<User>> List(User model)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query<
                    Model.User>
                    ("PA_CON_USER_GET",
                    param: new
                    {
                        P_PK_USER = model.Pk_User,
                        P_USER_NAME = model.User_Name,
                        P_PASSWORD = model.Password,
                        P_PASSWORD_SALT = model.Password_Salt,
                        P_FULL_NAME = model.Full_Name,
                    },
                    commandType: CommandType.StoredProcedure);
                return await Task.FromResult<IEnumerable<User>>(result.ToList());
            }
        }

        public async Task<Model.User> Get(Model.User model)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query<
                    appointmentControl.Backend.Model.User>
                    ("PA_CON_USER_GET",
                    param: new
                    {
                        P_PK_USER = model.Pk_User,
                        P_USER_NAME = model.User_Name,
                        P_PASSWORD = model.Password,
                        P_PASSWORD_SALT = model.Password_Salt,
                        P_FULL_NAME = model.Full_Name,
                    },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                return await Task.FromResult<Model.User>(result);
            }
        }

        public async Task Save(Model.User model)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.QueryAsync<
                    appointmentControl.Backend.Model.User>
                    ("PA_MAN_USER_SAVE",
                    param: new
                    {
                        P_PK_USER = model.Pk_User,
                        P_USER_NAME = model.User_Name,
                        P_PASSWORD = model.Password,
                        P_PASSWORD_SALT = model.Password_Salt,
                        P_FULL_NAME = model.Full_Name,
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Delete(Model.User model)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(
                sql: "PA_USER_DELETE",
                param: new
                {
                    P_PK_USER = model.Pk_User
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

using Siloam.Service.LasaMedication.Common;
using Siloam.Service.LasaMedication.Models;
using Siloam.Service.LasaMedication.Models.ViewModels;
using Siloam.Service.LasaMedication.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Siloam.Service.LasaMedication.Repositories
{
	public class UserRepository : DatabaseConfig, IUserRepository
	{
		public UserRepository() : base()
		{ }

		public UserRepository(DatabaseContext Context) : base(Context)
		{ }

        public IEnumerable<ViewLogin> GetData_user_Login(ParamLogin paramLogin)
        {
            IEnumerable<ViewLogin> data;
            using (SqlConnection conn = new SqlConnection(Siloam.System.ApplicationSetting.ConnectionString))
            {
                var hashPassword = EncryptDecrypt.Encrypt(paramLogin.Password);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "spLogin";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("UserName", paramLogin.Username));
                cmd.Parameters.Add(new SqlParameter("UserPassword", hashPassword));

                using (var reader = cmd.ExecuteReader())
                {
                    data = reader.MapToList<ViewLogin>();
                }
            }

            return data;
        }

    }
}

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
	public class LasaRepository : DatabaseConfig, ILasaRepository
	{
		public LasaRepository() : base()
		{ }

		public LasaRepository(DatabaseContext Context) : base(Context)
		{ }

        public IEnumerable<ViewLasa> GetAllData_lasa()
        {
            IEnumerable<ViewLasa> data;
            using (SqlConnection conn = new SqlConnection(Siloam.System.ApplicationSetting.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "spGetData_Lasa";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                using (var reader = cmd.ExecuteReader())
                {
                    data = reader.MapToList<ViewLasa>();
                }
            }

            return data;
        }

        public IEnumerable<ViewLasa> GetData_lasa_byID(Int64 SalesItemId)
        {
            IEnumerable<ViewLasa> data;
            using (SqlConnection conn = new SqlConnection(Siloam.System.ApplicationSetting.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "spGetData_LasaById";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("InputSalesItemId", SalesItemId));

                using (var reader = cmd.ExecuteReader())
                {
                    data = reader.MapToList<ViewLasa>();
                }
            }
            return data;
        }

        public IEnumerable<ResponseLasa> PostData_lasa(ParamLasa paramLasa)
        {
            IEnumerable<ResponseLasa> data;
            using (SqlConnection conn = new SqlConnection(Siloam.System.ApplicationSetting.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "spPostData_Lasa";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("InputSalesItemId", paramLasa.InputSalesItemId));
                cmd.Parameters.Add(new SqlParameter("InputIsLasa", paramLasa.InputIsLasa));
                cmd.Parameters.Add(new SqlParameter("InputUserId", paramLasa.InputUserId));

                using (var reader = cmd.ExecuteReader())
                {
                    data = reader.MapToList<ResponseLasa>();
                }
            }

            return data;
        }
    }
}

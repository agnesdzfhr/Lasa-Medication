using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

using Siloam.Ui.LasaMedication.App_Code.Models;
using log4net;
using System.Reflection;


namespace Siloam.Ui.LasaMedication.App_Code.Controller
{
    public class clsLoginUser
    {
        public static async Task<string> GetLogin(string UserName, string Password)
        {
            string StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            ParamLoginUser ParamLogin = new ParamLoginUser();
            ParamLogin.username = UserName;
            ParamLogin.password = Password;

            string JsonString = JsonConvert.SerializeObject(ParamLogin);
            var content = new StringContent(JsonString, Encoding.UTF8, "application/json");

            try
            {
                HttpClient http_login_user = new HttpClient();
                http_login_user.BaseAddress = new Uri(ConfigurationManager.AppSettings["URLLasaMedication"].ToString());

                http_login_user.DefaultRequestHeaders.Accept.Clear();
                http_login_user.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var task = Task.Run(async () =>
                {
                    return await http_login_user.PostAsync(string.Format($"/getdatauserlogin"), content);
                });

                return task.Result.Content.ReadAsStringAsync().Result;
            }
            catch (Exception exx)
            {
                return exx.Message;
            }
        }
    }
}
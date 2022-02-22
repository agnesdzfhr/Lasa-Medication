using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace Siloam.Ui.LasaMedication.App_Code.Models
{
    public class ViewLoginUser
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public int Result { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
    }

    public class Result_login_user
    {
        private List<ViewLoginUser> lists = new List<ViewLoginUser>();
        [JsonProperty("data")]
        public List<ViewLoginUser> list { get { return lists; } }
    }
}
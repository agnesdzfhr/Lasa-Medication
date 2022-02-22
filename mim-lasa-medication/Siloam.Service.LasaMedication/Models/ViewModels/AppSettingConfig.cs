using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siloam.Service.LasaMedication.Models.ViewModels
{
	public class AppSettingConfig
	{
        //model untuk data yang disetting di application setting
        public static string EncryptKey_Encrypt { get; set; }
        public static string EncryptKey_Decrypt { get; set; }
        public static string MaxLockCounter { get; set; }
        public static string ExpPassCounter { get; set; }
        public static string DefaultPassword { get; set; }
        public static string IsChangeGlobalPass { get; set; }
        public static string proInt_Domain { get; set; }
        public static string proInt_Username { get; set; }
        public static string proInt_Password { get; set; }
        public static string emailEngineService { get; set; }
        public static string emailType { get; set; }
        public static string emailSender { get; set; }
        public static string emailDisplayName { get; set; }
        public static string loginapiconfig { get; set; }
        public static string minPasswordLength { get; set; }
    }
}

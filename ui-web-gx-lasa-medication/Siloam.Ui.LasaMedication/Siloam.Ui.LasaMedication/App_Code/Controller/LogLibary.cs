using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LogLibrary
/// </summary>
public static class LogLibrary
{
    public static string SaveLog(string OrgId, string ReferenceCode, string ReferenceNo, string method, string StartTime, string Type, string User, string QueryString, string JsonRequest, string Response)
    {
        string result = OrgId + ";" + ReferenceCode + ";" + ReferenceNo + ";" + method + ";" + StartTime + ";" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ";" + User + ";" + Type + ";" + QueryString + ";" + JsonRequest + ";" + "";

        return result;
    }



}
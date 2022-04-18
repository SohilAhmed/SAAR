using SAAR.Models;

namespace SAAR
{
    public static class CommonClass
    {
        private static string URL = $@"http://einvoicetex.com/new/";
        public static string SharedKeyMobile = "Mobile";
        public static string SharedKeyGSTNo = "GSTNo";
        public static string SharedKeyPartyName = "PartyName";

        public static string DispatchType = "2";

        public static string OutstandingDetailsPartyName = "";
        public static string OutstandingDetailsCompGstNo = "";

        public static string DispatchDetailsPartyName = "";
        public static string DispatchDetailsCompGstNo = "";

        public static string GetCompanyDetails(string Comp_gstno) => $@"{URL}Company_Activation?Comp_gstno={Comp_gstno}";

        public static string MobileNoVerify(string MobileNo) => $@"{URL}MobileNoVerify?MobileNo={MobileNo}";

        public static string OutstandingSummary(string MobileNo) => $@"{URL}OutstandingSummary?MobileNo={MobileNo}";

        public static string OutstandingDetails(string MobileNo, string PartyName, string GSTNo) => $@"{URL}OutstandingDetails?MobileNo={MobileNo}&PartyName={PartyName}&Comp_GstNo={GSTNo}";

        public static string DispatchInfoSummary(string MobileNo, string Type) => $@"{URL}DispatchInfoSummary?MobileNo={MobileNo}&Type={Type}";

        public static string DispatchInfoDetails(string MobileNo, string PartyName, string GSTNo) => $@"{URL}DispatchInfoDetails?MobileNo={MobileNo}&PartyName={PartyName}&Comp_GstNo={GSTNo}";

        public static string DispatchBillBodyInfo(string Comp_GstNo, string Fvno, string Bill_No) => $@"{URL}DispatchBillBodyInfo?Comp_GstNo={Comp_GstNo}&Fvno={Fvno}&Bill_No={Bill_No}";

        public static string PackInfoDetails(string CaseNo, string Comp_GSTno, string Party) => $@"{URL}PackInfoDetails?CaseNo={CaseNo}&Comp_GSTno={Comp_GSTno}&Party={Party}";

        public static MstUser LogedinUser;

        public static string SendOtp(string MobileNo, string OTP)
        {
            //string OTPURL = $"http://bulksms.texinfotech.com/smsaspx?ID=infotechinfo@yahoo.com&Pwd=Lansing$2105&PhNo=91{MobileNo}&Text=Dear Customer, Your Saar OTP is {OTP}. Thanks for Registration on Saar App. Tex Infotech Pvt. Ltd.&TemplateID=1007081986918400296";
            //RestClient client = new RestClient(OTPURL);
            //var request = new RestRequest(Method.GET);
            //IRestResponse response = await client.ExecuteAsync(request);
            //if (response.Content != "")
            //{
            return OTP;
            //}
            //else
            //    return "";
        }

        //public static async Task<string> SendOtp(string MobileNo, string OTP)
        //{
        //    string OTPURL = $"http://bulksms.texinfotech.com/smsaspx?ID=infotechinfo@yahoo.com&Pwd=Lansing$2105&PhNo=91{MobileNo}&Text=Dear Customer, Your Saar OTP is {OTP}. Thanks for Registration on Saar App. Tex Infotech Pvt. Ltd.&TemplateID=1007081986918400296";
        //    RestClient client = new RestClient(OTPURL);
        //    var request = new RestRequest(Method.GET);
        //    IRestResponse response = await client.ExecuteAsync(request);
        //    if (response.Content != "")
        //    {
        //        return OTP;
        //    }
        //    else
        //        return "";
        //}

        /// <summary>
        /// converts Obj to string
        /// </summary>
        /// <param name="Obj">Obj to convert</param>
        /// <returns>returns "" if not found</returns>
        public static string ObjToString(object Obj)
        {
            if (Obj != null) return Obj.ToString().Trim();
            return string.Empty;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace ShipTracking.Generic.Infrastructure
{
    public class Constants
    {
        public const string DataTypeString = "string";
        public const string DataTypeBoolean = "bool";
        public const string Success = "Success";

        public const string HTTP_Get = "GET";
        public const string HTTP_Post = "POST";

        public const int AllRecordsConstant = -1;
        public const int DefaultUserId = -99;
        public const int DefaultPriorityMonth = 31;

        public const string ApiDateFormat = "yyyy-MM-dd";
        public const string WipoDateFormat = "yyyyMMdd";
        public const string WipoDisplayDateFormat = "dd.MM.yyyy";
        public const string DateFormatSlash = "MM/dd/yyyy HH:mm";

        public const string ApplicationName = "SFCreateNewCase";
        public const int TempNameForCase = 54996;

        public const string Extention_PDF = "pdf";
        public const string Extention_TXT = "txt";
        
        public const string IRN_Exists_Code = "IRN_EXISTS";

        public const string English_Language = "EN";
        public const string French_Language = "FR";

        public const string SignUpUrl = "/security/account-notification";
        public const string ResetPasswordUrl = "/security/reset-password";
        public const string SiteBaseUrl = "http://localhost:4200";

        public const long TokenExpiryPeriod = 1;

        #region Wip data Fields id

        public const string detailMainForm = "detailMainForm";
        public const string pctBiblio = "pctBiblio";
        public const string PublicationNumber = detailMainForm + ":" + pctBiblio + ":" + "detailPCTtableWO";
        public const string PublicationDate = detailMainForm + ":" + pctBiblio + ":" + "detailPCTtablePubDate";
        public const string InternationalApplicationNumber = detailMainForm + ":" + pctBiblio + ":" + "j_idt3680";
        public const string InternationalFillingDate = detailMainForm + ":" + pctBiblio + ":" + "j_idt3706";
        public const string Chapter2DemandFiled = detailMainForm + ":" + pctBiblio + ":" + "j_idt3737";


        #endregion
    }
}

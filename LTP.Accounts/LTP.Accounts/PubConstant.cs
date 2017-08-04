using System.Configuration;

namespace LTP.Accounts
{
    public class PubConstant
    {
 
        public static string ConnectionString
        {   
            get
            {
                string text = ConfigurationManager.AppSettings["ConnectionString"];
                string str2 = ConfigurationManager.AppSettings["ConStringEncrypt"];
                if (str2 == "true")
                {
                    text = DESEncrypt.Decrypt(text);
                }
                return text;
            }
         }

    }


}

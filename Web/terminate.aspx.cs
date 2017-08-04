using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ZhangWei.Web
{
    public partial class terminate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string message1 = this.TextBox1.Text;
                //message1 = Maticsoft.Common.DEncrypt.DEncrypt.Encrypt(message1, "bnbnbn");
                string path = Server.MapPath("/Txt/EffTime.txt");
                FileInfo fi = new FileInfo(path);
                if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)//如果文件只读
                {
                    fi.Attributes = FileAttributes.Normal;//文件只读取消
                }
                FileStream fs = new FileStream(path, FileMode.Create);
                Byte[] bContent = System.Text.Encoding.GetEncoding("GB2312").GetBytes(message1);
                fs.Write(bContent, 0, bContent.Length);
                fs.Close();
                fs = null;
                Response.Redirect("/login.aspx");
            }
            catch (Exception er)
            {
                Response.Write(er.Message);
                Response.End();
            }
        }
    }
}

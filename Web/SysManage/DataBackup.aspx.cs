using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;

namespace ZhangWei.Web.SysManage
{
    public partial class DataBackup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBind();
            }
        }

        protected void DataBind()
        {
            string strFilePath = Server.MapPath("\\DataBackup\\");
            FileInfo[] arrFile = new DirectoryInfo(strFilePath).GetFiles();
            this.GridView1.DataSource = arrFile;
            this.GridView1.DataBind();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string FileName = GridView1.Rows[e.RowIndex].Cells[0].Text;
            FileInfo DelFile = new FileInfo(Server.MapPath("\\DataBackup\\" + FileName));
            DelFile.Delete();
            Maticsoft.Common.MessageBox.Show(this, "删除成功！");
            DataBind();
        }
    }
}

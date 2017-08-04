using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ZhangWei.Web.Report
{
    public partial class HisTab : System.Web.UI.Page
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
            string strFilePath = Server.MapPath("\\ExcelFiles\\");
            FileInfo[] arrFile = new DirectoryInfo(strFilePath).GetFiles();
            //arrFile.OrderBy<arrFile,arrFile.k>;
            this.GridView1.DataSource = arrFile;
            this.GridView1.DataBind();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string FileName = GridView1.Rows[e.RowIndex].Cells[0].Text;
            FileInfo DelFile = new FileInfo(Server.MapPath("\\ExcelFiles\\" + FileName));
            DelFile.Delete();
            Maticsoft.Common.MessageBox.Show(this, "删除成功！");
            DataBind();
        }

    }
}

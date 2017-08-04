using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ZhangWei.Web.warehouse
{
    public partial class EnterStockRecordDtl : System.Web.UI.Page
    {
        BLL.EnterStock bl_es = new ZhangWei.BLL.EnterStock();
        BLL.EnterStock_Detail bl_esd = new ZhangWei.BLL.EnterStock_Detail();
        Int32 EnterStock_ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["EnterStock_ID"] != null && Request.Params["EnterStock_ID"].Trim() != "")
            {
                EnterStock_ID = Convert.ToInt32(Request.Params["EnterStock_ID"].Trim());
            }
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            this.Label3.Text = "单号：" + EnterStock_ID;
            Model.EnterStock ml_es = bl_es.GetModel(EnterStock_ID);
            this.Label4.Text = new BLL.StoreHouse().GetModel(ml_es.StoreHouse_ID).Address;
            DataSet ds_es = bl_esd.GetEnterStock(EnterStock_ID);
            this.GridView1.DataSource = ds_es;
            this.GridView1.DataBind();
            decimal AllTot = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                decimal price = Convert.ToDecimal(row.Cells[4].Text);
                decimal qty = Convert.ToDecimal(row.Cells[5].Text);
                decimal RowTot = price * qty;
                row.Cells[7].Text = RowTot.ToString();
                AllTot += RowTot;
            }
            this.Label1.Text = AllTot.ToString();
            this.Label2.Text = Maticsoft.Common.Rmb.CmycurD(AllTot);
        }
    }
}

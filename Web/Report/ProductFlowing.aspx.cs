using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace ZhangWei.Web.Report
{
    public partial class ProductFlowing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Int32 Product_ID = Convert.ToInt32(this.HiddenField1.Value);
            DataTable dt = new BLL.ProductFlowing().GetFlowing(Product_ID, Convert.ToDateTime("2012-02-01"), Convert.ToDateTime("2012-06-01"));
            this.GridView5.DataSource = dt;
            this.GridView5.DataBind();

            this.Panel1.Visible = true;
            DataSet ds = new BLL.Product().GetStockFromView(10, 1, "Product_ID = " + Product_ID);
            this.Repeater1.DataSource = ds;
            this.Repeater1.DataBind();
            decimal TotalQTY = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["Quantity"]!="")
                {
                    TotalQTY += Convert.ToDecimal(ds.Tables[0].Rows[i]["Quantity"]);
                }
            }
            Int32 RecCount = this.GridView5.Rows.Count;
            if (RecCount > 0)
            {
                this.GridView5.Rows[RecCount - 1].Cells[6].Text = TotalQTY.ToString();
            }
            if (RecCount > 1)
            {
                for (int i = RecCount; i > 1; i--)
                {
                    decimal RowQTY = Convert.ToDecimal(this.GridView5.Rows[i - 1].Cells[6].Text);
                    if (this.GridView5.Rows[i - 1].Cells[1].Text=="销售"||this.GridView5.Rows[i - 1].Cells[1].Text=="出库")
                    {
                        this.GridView5.Rows[i - 2].Cells[6].Text = (RowQTY + Convert.ToDecimal(this.GridView5.Rows[i - 1].Cells[2].Text)).ToString();
                    }
                    else
                    {
                        this.GridView5.Rows[i - 2].Cells[6].Text = (RowQTY - Convert.ToDecimal(this.GridView5.Rows[i - 1].Cells[2].Text)).ToString();
                    }
                    
                }
            }
        }
    }
}

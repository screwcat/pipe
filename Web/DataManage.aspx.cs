using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Web.LocalCass;

namespace ZhangWei.Web
{
    public partial class DataManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new BLL.Product().GetAllList();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Model.Product mo = new BLL.Product().GetModel(Convert.ToInt32(ds.Tables[0].Rows[i]["Product_ID"]));
                
            }
        }
        protected Int32 getSpecId(string Spec)
        {
            DataSet ds = new BLL.ProductSpec().GetAllList();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if ((ds.Tables[0].Rows[i]["Name"]).ToString()==Spec.ToString())
                {
                    return Convert.ToInt32(ds.Tables[0].Rows[i]["ProductSpec_ID"]);
                }
            }
            return 0;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataSet ds = new BLL.Product().GetAllList();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Model.Supplier mo_supp = new Model.Supplier();
                string s_name = ds.Tables[0].Rows[i]["Name"].ToString();
                if (s_name.Length>1)
                {
                    s_name = s_name.Substring(0, 2);
                }
                mo_supp.Name = s_name;
                mo_supp.Address = s_name;
                BLL.Supplier bl_supp = new BLL.Supplier();
                bl_supp.Add(mo_supp);
            }
        }
    }
}

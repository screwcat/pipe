using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Web.LocalCass;

namespace ZhangWei.Web.warehouse
{
    public partial class AddBackStock : UserPageBass
    {
        DataSet Dept = new BLL.Dept().GetAllList();
        DataSet Employee = new BLL.Employee().GetAllList();
        DataSet StoreHouse = new BLL.StoreHouse().GetAllList();
        DataSet Supplier = new BLL.Supplier().GetAllList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.DataSource = Dept;
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "Dept_ID";
                DropDownList1.DataBind();
                DropDownList2.DataSource = Employee;
                DropDownList2.DataTextField = "Name";
                DropDownList2.DataValueField = "Employee_ID";
                DropDownList2.DataBind();
                DropDownList3.DataSource = StoreHouse;
                DropDownList3.DataTextField = "Address";
                DropDownList3.DataValueField = "StoreHouse_ID";
                DropDownList3.DataBind();
                DropDownList4.DataSource = Supplier;
                DropDownList4.DataTextField = "Name";
                DropDownList4.DataValueField = "Supplier_ID";
                DropDownList4.DataBind();
                DropDownList2.SelectedValue = UserModel.Employee_ID.ToString();
                Button4.Attributes.Add("onclick", "return false;");
                //Button2.Attributes.Add("onclick", "return confirm(\"确认出库信息吗？\")");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (HiddenField1.Value == "")
            {
                Maticsoft.Common.MessageBox.Show(this, "请添加商品");
                return;
            }
            else
            {
                Model.BackStock ml_bs = new ZhangWei.Model.BackStock();
                ml_bs.BackDate = Convert.ToDateTime(BackDate.Text);
                ml_bs.Dept_ID = Convert.ToInt32(DropDownList1.SelectedValue);
                ml_bs.Employee_ID = Convert.ToInt32(DropDownList2.SelectedValue);
                ml_bs.StoreHouse_ID = Convert.ToInt32(DropDownList3.SelectedValue);
                ml_bs.Remark = this.TextBox1.Text;


                Int32 BackStock_id = new BLL.BackStock().Add(ml_bs);
                string Ids = HiddenField1.Value.Replace(" ", "").Replace("\r\n", "");
                string Qtys = HiddenField2.Value.Replace(" ", "").Replace("\r\n", "");
                string Prices = HiddenField3.Value.Replace(" ", "").Replace("\r\n", "");
                string[] ArrIds = Ids.Split(new char[] { '|' });
                string[] ArrQty = Qtys.Split(new char[] { '|' });
                string[] ArrPri = Prices.Split(new char[] { '|' });
                for (int i = 0; i < ArrIds.Length - 1; i++)
                {
                    //Model.Sale_Detail ml_sa = new ZhangWei.Model.Sale_Detail();
                    Model.BackStock_Detail ml_bsd = new ZhangWei.Model.BackStock_Detail();
                    ml_bsd.BackStock_ID = BackStock_id;
                    ml_bsd.Product_ID = Convert.ToInt32(ArrIds[i]);
                    ml_bsd.Price = Convert.ToDecimal(ArrPri[i]);
                    ml_bsd.Quantity = Convert.ToDecimal(ArrQty[i]);
                    
                    BLL.BackStock_Detail bl_bsd = new ZhangWei.BLL.BackStock_Detail();
                    Model.StockPile ml_sp = new BLL.StockPile().GetModelByProId(Convert.ToInt32(ArrIds[i]), Convert.ToInt32(DropDownList3.SelectedValue));
                    BLL.StockPile bl_sp = new ZhangWei.BLL.StockPile();
                    if (ml_sp == null)
                    {
                        Model.Product ml_pr = new BLL.Product().GetModel(Convert.ToInt32(ArrIds[i]));
                        ml_sp = new ZhangWei.Model.StockPile();
                        ml_sp.Product_ID = Convert.ToInt32(ArrIds[i]);
                        ml_sp.Dept_ID = Convert.ToInt32(DropDownList1.SelectedValue);
                        ml_sp.FirstEnterDate = DateTime.Now;
                        ml_sp.LastLeaveDate = DateTime.Now;
                        ml_sp.Price = Convert.ToDecimal(ArrPri[i]);
                        ml_sp.StoreHouse_ID = Convert.ToInt32(DropDownList3.SelectedValue);
                        ml_sp.Quantity = 0;
                        ml_sp.Quantity -= Convert.ToDecimal(ArrQty[i]);
                        bl_sp.Add(ml_sp);
                    }
                    else
                    {
                        ml_sp.Quantity -= Convert.ToDecimal(ArrQty[i]);
                        ml_sp.LastLeaveDate = DateTime.Now;
                        bl_sp.Update(ml_sp);
                    }
                    bl_bsd.Add(ml_bsd);
                }
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "/warehouse/BackStock/List.aspx");
            }
        }
    }
}

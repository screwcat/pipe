using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Web.LocalCass;
using System.Data;

namespace ZhangWei.Web.warehouse
{
    public partial class AddLeaveStock : UserPageBass
    {
        DataSet StoreHouse = new BLL.StoreHouse().GetAllList();
        DataSet Dept = new BLL.Dept().GetAllList();
        DataSet Employee = new BLL.Employee().GetAllList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.DataSource = Dept;
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "Dept_ID";
                DropDownList1.DataBind();
                DropDownList2.DataSource = StoreHouse;
                DropDownList2.DataTextField = "Address";
                DropDownList2.DataValueField = "StoreHouse_ID";
                DropDownList2.DataBind();
                DropDownList3.DataSource = StoreHouse;
                DropDownList3.DataTextField = "Address";
                DropDownList3.DataValueField = "StoreHouse_ID";
                DropDownList3.DataBind();
                DropDownList4.DataSource = Employee;
                DropDownList4.DataTextField = "Name";
                DropDownList4.DataValueField = "Employee_ID";
                DropDownList4.DataBind();
                DropDownList4.SelectedValue = UserModel.Employee_ID.ToString();
            }
            Button4.Attributes.Add("onclick", "return false;");
            //Button2.Attributes.Add("onclick", "return confirm(\"确认调拔吗？\")");
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
                Model.LeaveStock LeaveStock = new Model.LeaveStock();
                LeaveStock.LeaveDate = Convert.ToDateTime(txtWriteDate.Text);
                LeaveStock.Dept_ID = Convert.ToInt32(DropDownList1.SelectedValue);
                LeaveStock.Employee_ID = Convert.ToInt32(DropDownList4.SelectedValue);
                LeaveStock.StoreHouse_ID = Convert.ToInt32(DropDownList2.SelectedValue);
                LeaveStock.ToStoreHouse_ID = Convert.ToInt32(DropDownList3.SelectedValue);
                Int32 LeaveStock_ID = new BLL.LeaveStock().Add(LeaveStock);
                string Ids = HiddenField1.Value.Replace(" ", "").Replace("\r\n", "");
                string Qtys = HiddenField2.Value.Replace(" ", "").Replace("\r\n", "");
                string Prices = HiddenField3.Value.Replace(" ", "").Replace("\r\n", "");
                string[] ArrIds = Ids.Split(new char[] { '|' });
                string[] ArrQty = Qtys.Split(new char[] { '|' });
                string[] ArrPri = Prices.Split(new char[] { '|' });
                for (int i = 0; i < ArrIds.Length - 1; i++)
                {
                    Model.LeaveStock_Detail ml_ld = new Model.LeaveStock_Detail();
                    BLL.LeaveStock_Detail bl_ld = new BLL.LeaveStock_Detail();
                    ml_ld.LeaveStock_ID = LeaveStock_ID;
                    ml_ld.Product_ID = Convert.ToInt32(ArrIds[i]);
                    ml_ld.Quantity = Convert.ToDecimal(ArrQty[i]);
                    ml_ld.Price = Convert.ToDecimal(ArrPri[i]);
                    Model.StockPile ml_sp_out = new BLL.StockPile().GetModelByProId(Convert.ToInt32(ArrIds[i]), Convert.ToInt32(DropDownList2.SelectedValue));
                    Model.StockPile ml_sp_in = new BLL.StockPile().GetModelByProId(Convert.ToInt32(ArrIds[i]), Convert.ToInt32(DropDownList3.SelectedValue));
                    BLL.StockPile bl_sp = new ZhangWei.BLL.StockPile();
                    if (ml_sp_out == null)
                    {
                        //Model.Product ml_pr = new BLL.Product().GetModel(Convert.ToInt32(ArrIds[i]));
                        ml_sp_out = new ZhangWei.Model.StockPile();
                        ml_sp_out.Product_ID = Convert.ToInt32(ArrIds[i]);
                        ml_sp_out.Dept_ID = Convert.ToInt32(DropDownList1.SelectedValue);
                        ml_sp_out.FirstEnterDate = DateTime.Now;
                        ml_sp_out.LastLeaveDate = DateTime.Now;
                        ml_sp_out.Price = Convert.ToDecimal(ArrPri[i]);
                        ml_sp_out.Quantity = 0;
                        ml_sp_out.StoreHouse_ID = Convert.ToInt32(DropDownList2.SelectedValue);
                        ml_sp_out.Quantity -= Convert.ToDecimal(ArrQty[i]);
                        bl_sp.Add(ml_sp_out);
                    }
                    else
                    {
                        ml_sp_out.Quantity -= Convert.ToDecimal(ArrQty[i]);
                        ml_sp_out.LastLeaveDate = DateTime.Now;
                        bl_sp.Update(ml_sp_out);
                    }
                    if (ml_sp_in == null)
                    {
                        Model.Product ml_pr = new BLL.Product().GetModel(Convert.ToInt32(ArrIds[i]));
                        ml_sp_in = new ZhangWei.Model.StockPile();
                        ml_sp_in.Product_ID = Convert.ToInt32(ArrIds[i]);
                        ml_sp_in.Dept_ID = Convert.ToInt32(DropDownList1.SelectedValue);
                        ml_sp_in.FirstEnterDate = DateTime.Now;
                        ml_sp_in.LastLeaveDate = DateTime.Now;
                        ml_sp_in.Price = Convert.ToDecimal(ArrPri[i]);
                        ml_sp_in.Quantity = 0;
                        ml_sp_in.StoreHouse_ID = Convert.ToInt32(DropDownList3.SelectedValue);
                        ml_sp_in.Quantity += Convert.ToDecimal(ArrQty[i]);
                        bl_sp.Add(ml_sp_in);
                    }
                    else
                    {
                        ml_sp_in.Quantity += Convert.ToDecimal(ArrQty[i]);
                        ml_sp_in.LastLeaveDate = DateTime.Now;
                        bl_sp.Update(ml_sp_in);
                    }
                    bl_ld.Add(ml_ld);
                }
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "/warehouse/TransferRecord.aspx");
            }
        }
    }
}

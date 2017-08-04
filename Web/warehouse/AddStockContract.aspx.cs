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
    public partial class AddStockContract : UserPageBass
    {
        DataSet Dept = new BLL.Dept().GetAllList();
        DataSet Supplier = new BLL.Supplier().GetAllList();
        DataSet Employee = new BLL.Employee().GetAllList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.DataSource = Dept;
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "Dept_ID";
                DropDownList1.DataBind();
                DropDownList2.DataSource = Supplier;
                DropDownList2.DataTextField = "Name";
                DropDownList2.DataValueField = "Supplier_ID";
                DropDownList2.DataBind();
                DropDownList3.DataSource = Employee;
                DropDownList3.DataTextField = "Name";
                DropDownList3.DataValueField = "Employee_ID";
                DropDownList3.DataBind();
                DropDownList3.SelectedValue = UserModel.Employee_ID.ToString();
                Button4.Attributes.Add("onclick", "return false;");
                Button2.Attributes.Add("onclick", "return confirm(\"确定入库信息吗？\")");
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
                Model.BuyOrder BuyOrder = new Model.BuyOrder();
                BuyOrder.Dept_ID = Convert.ToInt32(DropDownList1.SelectedValue);
                BuyOrder.Employee_ID = Convert.ToInt32(DropDownList3.SelectedValue);
                BuyOrder.WriteDate = DateTime.Now;
                BuyOrder.InsureDate = DateTime.Now;
                BuyOrder.EndDate = DateTime.Now;
                BuyOrder.Supplier_ID = Convert.ToInt32(DropDownList2.SelectedValue);
                BLL.BuyOrder bo = new BLL.BuyOrder();
                Int32 BuyOrderId = bo.Add(BuyOrder);
                string Ids = HiddenField1.Value.Replace(" ", "").Replace("\r\n", "");
                string Qtys = HiddenField2.Value.Replace(" ", "").Replace("\r\n", "");
                string Prices = HiddenField3.Value.Replace(" ", "").Replace("\r\n", "");
                string[] ArrIds = Ids.Split(new char[] { '|' });
                string[] ArrQty = Qtys.Split(new char[] { '|' });
                string[] ArrPri = Prices.Split(new char[] { '|' });
                for (int i = 0; i < ArrIds.Length - 1; i++)
                {
                    Model.BuyOrder_Detail model = new Model.BuyOrder_Detail();
                    BLL.BuyOrder_Detail bd = new BLL.BuyOrder_Detail();
                    model.BuyOrder_ID = BuyOrderId;
                    model.Product_ID = Convert.ToInt32(ArrIds[i]);
                    model.Quantity = Convert.ToDecimal(ArrQty[i]);
                    model.Price = Convert.ToDecimal(ArrPri[i]);
                    bd.Add(model);
                }
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！请到进货管理页进行入库操作", "/warehouse/BuyOrder/List.aspx");
            }

        }
    }
}

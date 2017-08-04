using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
using Maticsoft.Web.LocalCass;
namespace ZhangWei.Web.BuyOrder
{
    public partial class Add : UserPageBass
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
            }
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            string strErr = "";
            if (!PageValidate.IsDateTime(txtWriteDate.Text))
            {
                strErr += "WriteDate格式错误！\\n";
            }
            if (!PageValidate.IsDateTime(txtInsureDate.Text))
            {
                strErr += "InsureDate格式错误！\\n";
            }
            if (!PageValidate.IsDateTime(txtEndDate.Text))
            {
                strErr += "EndDate格式错误！\\n";
            }
            //if (!PageValidate.IsNumber(txtDept_ID.Text))
            //{
            //    strErr += "Dept_ID格式错误！\\n";
            //}
            //if (!PageValidate.IsNumber(txtSupplier_ID.Text))
            //{
            //    strErr += "Supplier_ID格式错误！\\n";
            //}
            //if (!PageValidate.IsNumber(txtEmployee_ID.Text))
            //{
            //    strErr += "Employee_ID格式错误！\\n";
            //}

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            DateTime WriteDate = DateTime.Parse(this.txtWriteDate.Text);
            DateTime InsureDate = DateTime.Parse(this.txtInsureDate.Text);
            DateTime EndDate = DateTime.Parse(this.txtEndDate.Text);
            int Dept_ID = int.Parse(this.DropDownList1.SelectedValue);
            int Supplier_ID = int.Parse(this.DropDownList2.SelectedValue);
            int Employee_ID = int.Parse(this.DropDownList3.SelectedValue);

            ZhangWei.Model.BuyOrder model = new ZhangWei.Model.BuyOrder();
            model.WriteDate = WriteDate;
            model.InsureDate = InsureDate;
            model.EndDate = EndDate;
            model.Dept_ID = Dept_ID;
            model.Supplier_ID = Supplier_ID;
            model.Employee_ID = Employee_ID;

            ZhangWei.BLL.BuyOrder bll = new ZhangWei.BLL.BuyOrder();
            bll.Add(model);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "add.aspx");

        }


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}

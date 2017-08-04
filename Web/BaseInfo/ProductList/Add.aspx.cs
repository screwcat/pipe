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
namespace ZhangWei.Web.ProductList
{
    public partial class Add : Page
    {
        DataSet ProductClass = new ZhangWei.BLL.ProductClass().GetAllList();
        DataSet Employee = new ZhangWei.BLL.Employee().GetAllList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.DropDownList1.DataSource = ProductClass;
                this.DropDownList1.DataTextField = "Name";
                this.DropDownList1.DataValueField = "ProductClass_ID";
                this.DropDownList1.DataBind();
                this.DropDownList2.DataSource = Employee;
                this.DropDownList2.DataTextField = "Name";
                this.DropDownList2.DataValueField = "Employee_ID";
                this.DropDownList2.DataBind();
            }
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            string strErr = "";
            //if (!PageValidate.IsNumber(txtProductClass_ID.Text))
            //{
            //    strErr += "ProductClass_ID格式错误！\\n";
            //}
            if (this.txtName.Text.Trim().Length == 0)
            {
                strErr += "Name不能为空！\\n";
            }
            //if (!PageValidate.IsNumber(txtEmployee_ID.Text))
            //{
            //    strErr += "Employee_ID格式错误！\\n";
            //}
            //if (!PageValidate.IsDateTime(txtCreateDate.Text))
            //{
            //    strErr += "CreateDate格式错误！\\n";
            //}
            if (this.txtRemark.Text.Trim().Length == 0)
            {
                strErr += "Remark不能为空！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            //int ProductClass_ID = int.Parse(this.txtProductClass_ID.Text);
            int ProductClass_ID = int.Parse(this.DropDownList1.SelectedValue);
            string Name = this.txtName.Text;
            int Employee_ID = int.Parse(this.DropDownList2.SelectedValue);
            DateTime CreateDate = DateTime.Now;
            string Remark = this.txtRemark.Text;

            ZhangWei.Model.ProductList model = new ZhangWei.Model.ProductList();
            model.ProductClass_ID = ProductClass_ID;
            model.Name = Name;
            model.Employee_ID = Employee_ID;
            model.CreateDate = CreateDate;
            model.Remark = Remark;

            ZhangWei.BLL.ProductList bll = new ZhangWei.BLL.ProductList();
            bll.Add(model);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "add.aspx");

        }


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}

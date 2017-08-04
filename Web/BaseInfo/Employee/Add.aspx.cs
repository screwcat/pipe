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
namespace ZhangWei.Web.Employee
{
    public partial class Add : Page
    {
        DataSet Dept = new BLL.Dept().GetAllList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.DataSource = Dept;
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "Dept_ID";
                DropDownList1.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            string strErr = "";
            //if(!PageValidate.IsNumber(txtDept_ID.Text))
            //{
            //    strErr+="Dept_ID格式错误！\\n";	
            //}
            if (this.txtName.Text.Trim().Length == 0)
            {
                strErr += "Name不能为空！\\n";
            }
            if (this.txtDuty.Text.Trim().Length == 0)
            {
                strErr += "Duty不能为空！\\n";
            }
            //if(this.txtGender.Text.Trim().Length==0)
            //{
            //    strErr+="Gender不能为空！\\n";	
            //}
            if (!PageValidate.IsDateTime(txtBirthDate.Text))
            {
                strErr += "BirthDate格式错误！\\n";
            }
            if (!PageValidate.IsDateTime(txtHireDate.Text))
            {
                strErr += "HireDate格式错误！\\n";
            }
            if (!PageValidate.IsDateTime(txtMatureDate.Text))
            {
                strErr += "MatureDate格式错误！\\n";
            }
            if (this.txtIdentityCard.Text.Trim().Length == 0)
            {
                strErr += "IdentityCard不能为空！\\n";
            }
            if (this.txtAddress.Text.Trim().Length == 0)
            {
                strErr += "Address不能为空！\\n";
            }
            if (this.txtPhone.Text.Trim().Length == 0)
            {
                strErr += "Phone不能为空！\\n";
            }
            if (this.txtEmail.Text.Trim().Length == 0)
            {
                strErr += "Email不能为空！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            int Dept_ID = int.Parse(this.DropDownList1.SelectedValue);
            string Name = this.txtName.Text;
            string Duty = this.txtDuty.Text;
            string Gender = this.RadioButtonList1.SelectedValue;
            DateTime BirthDate = DateTime.Parse(this.txtBirthDate.Text);
            DateTime HireDate = DateTime.Parse(this.txtHireDate.Text);
            DateTime MatureDate = DateTime.Parse(this.txtMatureDate.Text);
            string IdentityCard = this.txtIdentityCard.Text;
            string Address = this.txtAddress.Text;
            string Phone = this.txtPhone.Text;
            string Email = this.txtEmail.Text;

            ZhangWei.Model.Employee model = new ZhangWei.Model.Employee();
            model.Dept_ID = Dept_ID;
            model.Name = Name;
            model.Duty = Duty;
            model.Gender = Gender;
            model.BirthDate = BirthDate;
            model.HireDate = HireDate;
            model.MatureDate = MatureDate;
            model.IdentityCard = IdentityCard;
            model.Address = Address;
            model.Phone = Phone;
            model.Email = Email;

            ZhangWei.BLL.Employee bll = new ZhangWei.BLL.Employee();
            bll.Add(model);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "add.aspx");

        }


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}

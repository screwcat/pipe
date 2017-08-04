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
namespace ZhangWei.Web.Product
{
    public partial class Add : UserPageBass
    {
        //DataSet ProductList = new BLL.ProductList().GetAllList();
        DataSet ProductSpec = new BLL.ProductSpec().GetAllList();
        DataSet ProductUnit = new BLL.ProductUnit().GetAllList();
        DataSet ProductClass = new BLL.ProductClass().GetAllList();
        DataSet Supplier = new BLL.Supplier().GetAllList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList2.DataSource = ProductSpec;
                DropDownList2.DataTextField = "Name";
                DropDownList2.DataValueField = "ProductSpec_ID";
                DropDownList2.DataBind();
                DropDownList3.DataSource = ProductUnit;
                DropDownList3.DataTextField = "Name";
                DropDownList3.DataValueField = "ProductUnit_ID";
                DropDownList3.DataBind();
                DropDownList4.DataSource = ProductClass;
                DropDownList4.DataTextField = "Name";
                DropDownList4.DataValueField = "ProductClass_ID";
                DropDownList4.DataBind();
                DropDownList5.DataSource = Supplier;
                DropDownList5.DataTextField = "Name";
                DropDownList5.DataValueField = "Supplier_ID";
                DropDownList5.DataBind();
            }
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            string strErr = "";
            //if (!PageValidate.IsNumber(txtProductList_ID.Text))
            //{
            //    strErr += "ProductList_ID格式错误！\\n";
            //}
            if (Request.Form["DropDownList1"] == null)
            {
                strErr += "请选择产品分类！\\n";
            }
            if (this.txtName.Text.Trim().Length == 0)
            {
                strErr += "名称不能为空！\\n";
            }
            if (this.TextBox1.Text.Trim().Length == 0)
            {
                strErr += "简称不能为空！\\n";
            }
            if (this.Offering_Price.Text.Trim().Length == 0)
            {
                strErr += "零售价不能空！\\n";
            }

            if (this.txtPrice.Text.Trim().Length == 0)
            {
                strErr += "进价不能空！\\n";
            }
            //if (!PageValidate.IsNumber(txtProductSpec_ID.Text))
            //{
            //    strErr += "ProductSpec_ID格式错误！\\n";
            //}
            //if (!PageValidate.IsNumber(txtProductUnit_ID.Text))
            //{
            //    strErr += "ProductUnit_ID格式错误！\\n";
            //}
            //if (!PageValidate.IsDecimal(txtPrice.Text))
            //{
            //    strErr += "Price格式错误！\\n";
            //}
            //if (!PageValidate.IsNumber(txtEmployee_ID.Text))
            //{
            //    strErr += "Employee_ID格式错误！\\n";
            //}
            //if (!PageValidate.IsDateTime(txtCreateDate.Text))
            //{
            //    strErr += "CreateDate格式错误！\\n";
            //}
            //if (this.txtRemark.Text.Trim().Length == 0)
            //{
            //    strErr += "Remark不能为空！\\n";
            //}

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            int ProductList_ID = int.Parse(Request.Form["DropDownList1"]);
            string Name = this.txtName.Text;
            string spell = LTP.Common.Hz2Py.GetQuanPing(Name);
            string s_spell = LTP.Common.Hz2Py.GetPYString(Name);
            int ProductSpec_ID = int.Parse(this.DropDownList2.SelectedItem.Value);
            int ProductUnit_ID = int.Parse(this.DropDownList3.SelectedValue);
            decimal Price = decimal.Parse(this.txtPrice.Text);
            decimal Offering_Price = decimal.Parse(this.Offering_Price.Text);
            int Employee_ID = UserModel.Employee_ID;
            string shortname = this.TextBox1.Text;
            
            string Remark = this.txtRemark.Text;

            ZhangWei.Model.Product model = new ZhangWei.Model.Product();
            model.ProductList_ID = ProductList_ID;
            model.Name = Name;
            model.spell = spell;
            model.s_spell = s_spell;
            model.ProductSpec_ID = ProductSpec_ID;
            model.ProductUnit_ID = ProductUnit_ID;
            model.Price = Price;
            model.Offering_Price = Offering_Price;
            model.Employee_ID = Employee_ID;
            model.CreateDate = DateTime.Now;
            model.Remark = Remark;
            model.shortname = shortname;
            string strWhere = "Name like '%" + Name + "%' AND ProductSpec_ID = " + ProductSpec_ID + " AND ProductUnit_ID = " + ProductUnit_ID;
            if (new BLL.Product().GetList(strWhere).Tables[0].Rows.Count > 0)
            {
                Maticsoft.Common.MessageBox.Show(this, "您添加的商品似乎与ID号为“" + new BLL.Product().GetList(strWhere).Tables[0].Rows[0]["Product_ID"].ToString() + "”的商品比较相像，请确认是否重复添加。");
            }
            else
            {
                ZhangWei.BLL.Product bll = new ZhangWei.BLL.Product();
                Int32 PId = bll.Add(model);
                Model.Product_Supplier PS = new Model.Product_Supplier();
                PS.Product_ID = PId;
                PS.Supplier_ID = Convert.ToInt32(DropDownList5.SelectedValue);
                BLL.Product_Supplier bl_ps = new ZhangWei.BLL.Product_Supplier();
                bl_ps.Add(PS);
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "添加成功！", "add.aspx");
            }
            

        }


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
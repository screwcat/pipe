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
    public partial class Modify : UserPageBass
    {
        Int32 Product_ID;
        DataSet ProductList = new BLL.ProductList().GetAllList();
        DataSet ProductSpec = new BLL.ProductSpec().GetAllList();
        DataSet ProductUnit = new BLL.ProductUnit().GetAllList();
        DataSet EUser = new BLL.EUser().GetAllList();
        DataSet ProductClass = new BLL.ProductClass().GetAllList();
        DataSet Supplier = new BLL.Supplier().GetAllList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DropDownList1.DataSource = ProductList;
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "ProductList_ID";
                DropDownList1.DataBind();
                DropDownList2.DataSource = ProductSpec;
                DropDownList2.DataTextField = "Name";
                DropDownList2.DataValueField = "ProductSpec_ID";
                DropDownList2.DataBind();
                DropDownList3.DataSource = ProductUnit;
                DropDownList3.DataTextField = "Name";
                DropDownList3.DataValueField = "ProductUnit_ID";
                DropDownList3.DataBind();
                DropDownList4.DataSource = EUser;
                DropDownList4.DataTextField = "UserName";
                DropDownList4.DataValueField = "UserId";
                DropDownList4.DataBind();
                DropDownList5.DataSource = ProductClass;
                DropDownList5.DataTextField = "Name";
                DropDownList5.DataValueField = "ProductClass_ID";
                DropDownList5.DataBind();
                DropDownList6.DataSource = Supplier;
                DropDownList6.DataTextField = "Name";
                DropDownList6.DataValueField = "Supplier_ID";
                DropDownList6.DataBind();
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    Product_ID = (Convert.ToInt32(Request.Params["id"]));
                    ShowInfo(Product_ID);
                    BindSelect();
                }
            }
        }

        private void ShowInfo(int Product_ID)
        {
            ZhangWei.BLL.Product bll = new ZhangWei.BLL.Product();
            ZhangWei.Model.Product model = bll.GetModel(Product_ID);
            this.lblProduct_ID.Text = model.Product_ID.ToString();
            //this.txtProductList_ID.Text = model.ProductList_ID.ToString();
            DropDownList1.SelectedValue = model.ProductList_ID.ToString();
            this.txtName.Text = model.Name;
            //this.txtProductSpec_ID.Text = model.ProductSpec_ID.ToString();
            DropDownList2.SelectedValue = model.ProductSpec_ID.ToString();
            //this.txtProductUnit_ID.Text = model.ProductUnit_ID.ToString();
            DropDownList3.SelectedValue = model.ProductUnit_ID.ToString();
            this.txtPrice.Text = model.Price.ToString();
            this.Offering_Price.Text = model.Offering_Price.ToString();
            //this.txtEmployee_ID.Text = model.Employee_ID.ToString();
            DropDownList4.SelectedValue = model.Employee_ID.ToString();
            DataSet ds = new BLL.ProductList().GetList(1, "ProductList_ID = " + model.ProductList_ID, "ProductList_ID");
            DropDownList5.SelectedValue = ds.Tables[0].Rows[0]["ProductClass_ID"].ToString();
            //this.txtCreateDate.Text = model.CreateDate.ToString();
            this.Label1.Text = model.CreateDate.ToString();
            this.txtRemark.Text = model.Remark;
            this.s_spell.Text = model.s_spell;
            this.spell.Text = model.spell;
            this.TextBox1.Text = model.shortname;
            ZhangWei.Model.Product_Supplier ml_ps = new BLL.Product_Supplier().GetModel(Product_ID);
            this.DropDownList6.SelectedValue = ml_ps.Supplier_ID.ToString();
        }

        public void btnSave_Click(object sender, EventArgs e)
        {

            string strErr = "";
            //if (!PageValidate.IsNumber(txtProductList_ID.Text))
            //{
            //    strErr += "ProductList_ID格式错误！\\n";
            //}
            if (DropDownList1.SelectedValue == "")
            {
                strErr += "请选择产品类别！\\n";
            }
            if (this.txtName.Text.Trim().Length == 0)
            {
                strErr += "名称不能为空！\\n";
            }
            //if (!PageValidate.IsNumber(txtProductSpec_ID.Text))
            //{
            //    strErr += "ProductSpec_ID格式错误！\\n";
            //}
            //if (!PageValidate.IsNumber(txtProductUnit_ID.Text))
            //{
            //    strErr += "ProductUnit_ID格式错误！\\n";
            //}
            if (!PageValidate.IsDecimal(txtPrice.Text))
            {
                strErr += "进价格式错误！应该为货币格式\\n";
            }
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
            int Product_ID = int.Parse(this.lblProduct_ID.Text);
            //int ProductList_ID = int.Parse(this.txtProductList_ID.Text);
            int ProductList_ID = int.Parse(this.DropDownList1.SelectedValue);
            string Name = this.txtName.Text;
            //int ProductSpec_ID = int.Parse(this.txtProductSpec_ID.Text);
            int ProductSpec_ID = int.Parse(this.DropDownList2.SelectedValue);
            //int ProductUnit_ID = int.Parse(this.txtProductUnit_ID.Text);
            int ProductUnit_ID = int.Parse(this.DropDownList3.SelectedValue);
            decimal Price = decimal.Parse(this.txtPrice.Text);
            decimal Offering_Price = decimal.Parse(this.Offering_Price.Text);
            int Employee_ID = int.Parse(this.DropDownList4.SelectedValue);
            DateTime CreateDate = DateTime.Parse(this.Label1.Text);
            string Remark = this.txtRemark.Text;
            string shortname = this.TextBox1.Text;


            ZhangWei.Model.Product model = new ZhangWei.Model.Product();
            model.Product_ID = Product_ID;
            model.ProductList_ID = ProductList_ID;
            model.Name = Name;
            model.ProductSpec_ID = ProductSpec_ID;
            model.ProductUnit_ID = ProductUnit_ID;
            model.Price = Price;
            model.Offering_Price = Offering_Price;
            model.Employee_ID = Employee_ID;
            model.CreateDate = CreateDate;
            model.Remark = Remark;
            model.spell = spell.Text;
            model.s_spell = s_spell.Text;
            model.shortname = shortname;

            ZhangWei.BLL.Product bll = new ZhangWei.BLL.Product();
            bll.Update(model);
            ZhangWei.Model.Product_Supplier ml_ps = new BLL.Product_Supplier().GetModel(Product_ID);
            ZhangWei.BLL.Product_Supplier bl_ps = new ZhangWei.BLL.Product_Supplier();
            ml_ps.Supplier_ID = Convert.ToInt32(this.DropDownList6.SelectedValue);
            bl_ps.Update(ml_ps);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "list.aspx");

        }


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSelect();
        }

        /// <summary>
        /// 根据主分类对细分类的下拉列表进行二级联动
        /// </summary>
        protected void BindSelect()
        {
            DataSet ds = new BLL.ProductList().GetList("ProductClass_ID = " + DropDownList5.SelectedValue);
            DropDownList1.Items.Clear();
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "ProductList_ID";
            DropDownList1.DataBind();
        }
    }
}

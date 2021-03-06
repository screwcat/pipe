﻿using System;
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
namespace ZhangWei.Web.ProductSpec
{
    public partial class Add : UserPageBass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtName.Text.Trim().Length==0)
			{
				strErr+="Name不能为空！\\n";	
			}
            //if(!PageValidate.IsNumber(txtEmployee_ID.Text))
            //{
            //    strErr+="Employee_ID格式错误！\\n";	
            //}
            //if(!PageValidate.IsDateTime(txtCreateDate.Text))
            //{
            //    strErr+="CreateDate格式错误！\\n";	
            //}
            //if(this.txtRemark.Text.Trim().Length==0)
            //{
            //    strErr+="Remark不能为空！\\n";	
            //}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string Name=this.txtName.Text;
            int Employee_ID = UserModel.Employee_ID;
			DateTime CreateDate=DateTime.Now;
			//string Remark=this.txtRemark.Text;

			ZhangWei.Model.ProductSpec model=new ZhangWei.Model.ProductSpec();
			model.Name=Name;
			model.Employee_ID=Employee_ID;
			model.CreateDate=CreateDate;
			//model.Remark=Remark;
            if (new BLL.ProductSpec().GetList("Name = '" + Name + "'").Tables[0].Rows.Count>0)
            {
                Maticsoft.Common.MessageBox.Show(this, "该规格已经存在，不用重复添加，以免造成货品资料混乱。");
            }
            else
            {
                ZhangWei.BLL.ProductSpec bll = new ZhangWei.BLL.ProductSpec();
                bll.Add(model);
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "add.aspx");
            }
			

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}

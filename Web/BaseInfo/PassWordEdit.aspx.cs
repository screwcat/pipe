using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Web.LocalCass;

namespace ZhangWei.Web.BaseInfo
{
    public partial class PassWordEdit : UserPageBass
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == UserModel.PassWord)
            {
                if (TextBox2.Text==""||TextBox3.Text=="")
                {
                    Maticsoft.Common.MessageBox.Show(this, "新密码不能为空！");
                }
                else if (TextBox2.Text!=TextBox3.Text)
                {
                    Maticsoft.Common.MessageBox.Show(this, "两次密码不一致！");
                }
                else
                {
                    UserModel.PassWord = TextBox2.Text;
                    BLL.Employee bl_emp = new BLL.Employee();
                    bl_emp.Update(UserModel);
                    Maticsoft.Common.MessageBox.Show(this, "密码修改成功！");
                }
            }
            else
            {
                Maticsoft.Common.MessageBox.Show(this, "旧密码不对！");
            }
        }
    }
}
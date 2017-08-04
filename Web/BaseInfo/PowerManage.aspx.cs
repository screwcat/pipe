using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Web.LocalCass;

namespace ZhangWei.Web.BaseInfo
{
    public partial class PowerManage : UserPageBass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = new BLL.Employee().GetAllList();
                Repeater1.DataSource = ds;
                Repeater1.DataBind();
                foreach (RepeaterItem item in Repeater1.Items)
                {
                    Label UserId = (Label)item.FindControl("Label2");
                    DataSet UserRight = new BLL.UserRight().GetListByUserId(Convert.ToInt32(UserId.Text));
                    CheckBox CB1 = (CheckBox)item.FindControl("CheckBox1");
                    CheckBox CB2 = (CheckBox)item.FindControl("CheckBox2");
                    CheckBox CB3 = (CheckBox)item.FindControl("CheckBox3");
                    CheckBox CB4 = (CheckBox)item.FindControl("CheckBox4");
                    CheckBox CB5 = (CheckBox)item.FindControl("CheckBox5");
                    CheckBox CB6 = (CheckBox)item.FindControl("CheckBox6");
                    CheckBox CB7 = (CheckBox)item.FindControl("CheckBox7");
                    CheckBox CB8 = (CheckBox)item.FindControl("CheckBox8");
                    CheckBox CB9 = (CheckBox)item.FindControl("CheckBox9");
                    CheckBox CB10 = (CheckBox)item.FindControl("CheckBox10");
                    CB1.Checked = CheckHaveRight(UserRight, Convert.ToInt32(CB1.Text));
                    CB2.Checked = CheckHaveRight(UserRight, Convert.ToInt32(CB2.Text));
                    CB3.Checked = CheckHaveRight(UserRight, Convert.ToInt32(CB3.Text));
                    CB4.Checked = CheckHaveRight(UserRight, Convert.ToInt32(CB4.Text));
                    CB5.Checked = CheckHaveRight(UserRight, Convert.ToInt32(CB5.Text));
                    CB6.Checked = CheckHaveRight(UserRight, Convert.ToInt32(CB6.Text));
                    CB7.Checked = CheckHaveRight(UserRight, Convert.ToInt32(CB7.Text));
                    CB8.Checked = CheckHaveRight(UserRight, Convert.ToInt32(CB8.Text));
                    CB9.Checked = CheckHaveRight(UserRight, Convert.ToInt32(CB9.Text));
                    CB10.Checked = CheckHaveRight(UserRight, Convert.ToInt32(CB10.Text));
                }
            }
            
            
        }
        bool CheckHaveRight(DataSet ds,Int32 RightNum)
        {
            bool flag = false;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[i]["Rights"])==RightNum)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in Repeater1.Items)
            {
                Label UserId = (Label)item.FindControl("Label2");
                DataSet UserRight = new BLL.UserRight().GetListByUserId(Convert.ToInt32(UserId.Text));
                BLL.UserRight bl_ur = new BLL.UserRight();
                bl_ur.DeleteList(Convert.ToInt32(UserId.Text));
                CheckBox CB1 = (CheckBox)item.FindControl("CheckBox1");
                CheckBox CB2 = (CheckBox)item.FindControl("CheckBox2");
                CheckBox CB3 = (CheckBox)item.FindControl("CheckBox3");
                CheckBox CB4 = (CheckBox)item.FindControl("CheckBox4");
                CheckBox CB5 = (CheckBox)item.FindControl("CheckBox5");
                CheckBox CB6 = (CheckBox)item.FindControl("CheckBox6");
                CheckBox CB7 = (CheckBox)item.FindControl("CheckBox7");
                CheckBox CB8 = (CheckBox)item.FindControl("CheckBox8");
                CheckBox CB9 = (CheckBox)item.FindControl("CheckBox9");
                CheckBox CB10 = (CheckBox)item.FindControl("CheckBox10");
                ChangeRight(Convert.ToInt32(UserId.Text),CB1);
                ChangeRight(Convert.ToInt32(UserId.Text), CB2);
                ChangeRight(Convert.ToInt32(UserId.Text), CB3);
                ChangeRight(Convert.ToInt32(UserId.Text), CB4);
                ChangeRight(Convert.ToInt32(UserId.Text), CB5);
                ChangeRight(Convert.ToInt32(UserId.Text), CB6);
                ChangeRight(Convert.ToInt32(UserId.Text), CB7);
                ChangeRight(Convert.ToInt32(UserId.Text), CB8);
                ChangeRight(Convert.ToInt32(UserId.Text), CB9);
                ChangeRight(Convert.ToInt32(UserId.Text), CB10);
            }
            Maticsoft.Common.MessageBox.Show(this, "保存成功！");
        }
        void ChangeRight(Int32 UserId,CheckBox cb)
        {
            BLL.UserRight bl_ur = new BLL.UserRight();
            Model.UserRight ml_ur = new Model.UserRight();
            if (cb.Checked)
            {
                ml_ur.UserId = UserId;
                ml_ur.Rights = Convert.ToInt32(cb.Text);
                bl_ur.Add(ml_ur);
            }
        }
    }
}

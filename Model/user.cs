using System;
namespace ZhangWei.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class user
	{
		public user()
		{}
		#region Model
		private string _user_id;
		private string _user_pwd;
		private string _again_pwd;
		private string _bel_group;
		private string _div_type;
		private string _user_auth;
		private string _auth_type;
		private string _user_status;
		private string _create_user;
		private string _create_date;
		private string _create_time;
		private string _appr_user;
		private string _appr_date;
		private string _appr_time;
		private string _pwd_date;
		private decimal? _err_count;
		private string _use_ejcic;
		/// <summary>
		/// 
		/// </summary>
		public string User_Id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string User_Pwd
		{
			set{ _user_pwd=value;}
			get{return _user_pwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Again_Pwd
		{
			set{ _again_pwd=value;}
			get{return _again_pwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Bel_Group
		{
			set{ _bel_group=value;}
			get{return _bel_group;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Div_Type
		{
			set{ _div_type=value;}
			get{return _div_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string User_Auth
		{
			set{ _user_auth=value;}
			get{return _user_auth;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Auth_Type
		{
			set{ _auth_type=value;}
			get{return _auth_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string User_Status
		{
			set{ _user_status=value;}
			get{return _user_status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Create_User
		{
			set{ _create_user=value;}
			get{return _create_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Create_Date
		{
			set{ _create_date=value;}
			get{return _create_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Create_Time
		{
			set{ _create_time=value;}
			get{return _create_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Appr_User
		{
			set{ _appr_user=value;}
			get{return _appr_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Appr_Date
		{
			set{ _appr_date=value;}
			get{return _appr_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Appr_Time
		{
			set{ _appr_time=value;}
			get{return _appr_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Pwd_Date
		{
			set{ _pwd_date=value;}
			get{return _pwd_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Err_Count
		{
			set{ _err_count=value;}
			get{return _err_count;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Use_eJCIC
		{
			set{ _use_ejcic=value;}
			get{return _use_ejcic;}
		}
		#endregion Model

	}
}


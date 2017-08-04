using System;
namespace ZhangWei.Model
{
	/// <summary>
	/// EUser:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EUser
	{
		public EUser()
		{}
		#region Model
		private int _userid;
		private string _username;
		private string _password;
		private string _email;
		private string _name;
		private string _sex;
		private int? _age;
		private string _id_card;
		private string _phone;
		private string _mobilphone;
		private string _address;
		private string _postalcode;
		private string _work;
		private decimal? _income;
		private int? _integral=0;
		private DateTime _createtime= DateTime.Now;
		private DateTime _laselogin= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PassWord
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Age
		{
			set{ _age=value;}
			get{return _age;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ID_Card
		{
			set{ _id_card=value;}
			get{return _id_card;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MobilPhone
		{
			set{ _mobilphone=value;}
			get{return _mobilphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Postalcode
		{
			set{ _postalcode=value;}
			get{return _postalcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Work
		{
			set{ _work=value;}
			get{return _work;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Income
		{
			set{ _income=value;}
			get{return _income;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Integral
		{
			set{ _integral=value;}
			get{return _integral;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime LaseLogin
		{
			set{ _laselogin=value;}
			get{return _laselogin;}
		}
		#endregion Model

	}
}


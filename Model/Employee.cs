using System;
namespace ZhangWei.Model
{
	/// <summary>
	/// Employee:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Employee
	{
		public Employee()
		{}
		#region Model
		private int _employee_id;
		private string _username;
		private string _password;
		private int _dept_id;
		private string _name;
		private string _duty;
		private string _gender;
		private DateTime _birthdate;
		private DateTime? _hiredate;
		private DateTime? _maturedate;
		private string _identitycard;
		private string _address;
		private string _phone;
		private string _email;
		/// <summary>
		/// 
		/// </summary>
		public int Employee_ID
		{
			set{ _employee_id=value;}
			get{return _employee_id;}
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
		public int Dept_ID
		{
			set{ _dept_id=value;}
			get{return _dept_id;}
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
		public string Duty
		{
			set{ _duty=value;}
			get{return _duty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Gender
		{
			set{ _gender=value;}
			get{return _gender;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime BirthDate
		{
			set{ _birthdate=value;}
			get{return _birthdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? HireDate
		{
			set{ _hiredate=value;}
			get{return _hiredate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? MatureDate
		{
			set{ _maturedate=value;}
			get{return _maturedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IdentityCard
		{
			set{ _identitycard=value;}
			get{return _identitycard;}
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
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		#endregion Model

	}
}


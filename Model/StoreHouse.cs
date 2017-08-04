using System;
namespace ZhangWei.Model
{
	/// <summary>
	/// StoreHouse:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class StoreHouse
	{
		public StoreHouse()
		{}
		#region Model
		private int _storehouse_id;
		private string _address;
		private string _phone;
		private int _employee_id;
		private DateTime? _createdate;
		/// <summary>
		/// 
		/// </summary>
		public int StoreHouse_ID
		{
			set{ _storehouse_id=value;}
			get{return _storehouse_id;}
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
		public int Employee_ID
		{
			set{ _employee_id=value;}
			get{return _employee_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}


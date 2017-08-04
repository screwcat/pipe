using System;
namespace ZhangWei.Model
{
	/// <summary>
	/// EnterStock:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EnterStock
	{
		public EnterStock()
		{}
		#region Model
		private int _enterstock_id;
		private DateTime _enterdate;
		private int _dept_id;
		private int _storehouse_id;
		private int _employee_id;
		/// <summary>
		/// 
		/// </summary>
		public int EnterStock_ID
		{
			set{ _enterstock_id=value;}
			get{return _enterstock_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime EnterDate
		{
			set{ _enterdate=value;}
			get{return _enterdate;}
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
		public int StoreHouse_ID
		{
			set{ _storehouse_id=value;}
			get{return _storehouse_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Employee_ID
		{
			set{ _employee_id=value;}
			get{return _employee_id;}
		}
		#endregion Model

	}
}


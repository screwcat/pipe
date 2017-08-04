using System;
namespace ZhangWei.Model
{
	/// <summary>
	/// LeaveStock:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class LeaveStock
	{
		public LeaveStock()
		{}
		#region Model
		private int _leavestock_id;
		private DateTime _leavedate;
		private int _dept_id;
		private int _storehouse_id;
		private int _tostorehouse_id;
		private int _employee_id;
		/// <summary>
		/// 
		/// </summary>
		public int LeaveStock_ID
		{
			set{ _leavestock_id=value;}
			get{return _leavestock_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime LeaveDate
		{
			set{ _leavedate=value;}
			get{return _leavedate;}
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
		public int ToStoreHouse_ID
		{
			set{ _tostorehouse_id=value;}
			get{return _tostorehouse_id;}
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


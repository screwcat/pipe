using System;
namespace ZhangWei.Model
{
	/// <summary>
	/// BackStock:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BackStock
	{
		public BackStock()
		{}
		#region Model
		private int _backstock_id;
		private DateTime _backdate;
		private int _dept_id;
		private int _storehouse_id;
		private int _employee_id;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int BackStock_ID
		{
			set{ _backstock_id=value;}
			get{return _backstock_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime BackDate
		{
			set{ _backdate=value;}
			get{return _backdate;}
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
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}


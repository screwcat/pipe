using System;
namespace ZhangWei.Model
{
	/// <summary>
	/// BuyOrder:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BuyOrder
	{
		public BuyOrder()
		{}
		#region Model
		private int _buyorder_id;
		private DateTime _writedate;
		private DateTime _insuredate;
		private DateTime _enddate;
		private int _dept_id;
		private int _supplier_id;
		private int _employee_id;
		private bool _produced= true;
		/// <summary>
		/// 
		/// </summary>
		public int BuyOrder_ID
		{
			set{ _buyorder_id=value;}
			get{return _buyorder_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime WriteDate
		{
			set{ _writedate=value;}
			get{return _writedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime InsureDate
		{
			set{ _insuredate=value;}
			get{return _insuredate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
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
		public int Supplier_ID
		{
			set{ _supplier_id=value;}
			get{return _supplier_id;}
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
		public bool Produced
		{
			set{ _produced=value;}
			get{return _produced;}
		}
		#endregion Model

	}
}


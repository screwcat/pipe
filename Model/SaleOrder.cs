using System;
namespace ZhangWei.Model
{
	/// <summary>
	/// SaleOrder:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SaleOrder
	{
		public SaleOrder()
		{}
		#region Model
		private int _saleorder_id;
		private DateTime _writedate;
		private DateTime _insuredate;
		private DateTime _enddate;
		private int _dept_id;
		private int _customer_id;
		private int _employee_id;
		/// <summary>
		/// 
		/// </summary>
		public int SaleOrder_ID
		{
			set{ _saleorder_id=value;}
			get{return _saleorder_id;}
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
		public int Customer_ID
		{
			set{ _customer_id=value;}
			get{return _customer_id;}
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


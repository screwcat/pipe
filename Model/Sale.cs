using System;
namespace ZhangWei.Model
{
	/// <summary>
	/// Sale:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sale
	{
		public Sale()
		{}
		#region Model
		private int _sale_id;
		private DateTime _saledate;
		private string _tradeno;
		private int _dept_id;
		private int _employee_id;
		private int _storehouse_id;
		private string _address;
		private string _account;
		private string _gatheringway;
		private int _customer;
		/// <summary>
		/// 
		/// </summary>
		public int Sale_ID
		{
			set{ _sale_id=value;}
			get{return _sale_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime SaleDate
		{
			set{ _saledate=value;}
			get{return _saledate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TradeNo
		{
			set{ _tradeno=value;}
			get{return _tradeno;}
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
		public int Employee_ID
		{
			set{ _employee_id=value;}
			get{return _employee_id;}
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
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Account
		{
			set{ _account=value;}
			get{return _account;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GatheringWay
		{
			set{ _gatheringway=value;}
			get{return _gatheringway;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Customer
		{
			set{ _customer=value;}
			get{return _customer;}
		}
		#endregion Model

	}
}


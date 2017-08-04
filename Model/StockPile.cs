using System;
namespace ZhangWei.Model
{
	/// <summary>
	/// StockPile:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class StockPile
	{
		public StockPile()
		{}
		#region Model
		private int _stockpile_id;
		private int _dept_id;
		private int _storehouse_id;
		private int _product_id;
		private DateTime _firstenterdate;
		private DateTime _lastleavedate;
		private decimal _quantity;
		private decimal _price;
		/// <summary>
		/// 
		/// </summary>
		public int StockPile_ID
		{
			set{ _stockpile_id=value;}
			get{return _stockpile_id;}
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
		public int Product_ID
		{
			set{ _product_id=value;}
			get{return _product_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime FirstEnterDate
		{
			set{ _firstenterdate=value;}
			get{return _firstenterdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime LastLeaveDate
		{
			set{ _lastleavedate=value;}
			get{return _lastleavedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		#endregion Model

	}
}


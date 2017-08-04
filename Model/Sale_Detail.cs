using System;
namespace ZhangWei.Model
{
	/// <summary>
	/// Sale_Detail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sale_Detail
	{
		public Sale_Detail()
		{}
		#region Model
		private int _sale_id;
		private int _product_id;
		private int? _saleorder_id;
		private decimal _quantity;
		private decimal _price;
		private int? _discount;
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
		public int Product_ID
		{
			set{ _product_id=value;}
			get{return _product_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SaleOrder_ID
		{
			set{ _saleorder_id=value;}
			get{return _saleorder_id;}
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
		/// <summary>
		/// 
		/// </summary>
		public int? Discount
		{
			set{ _discount=value;}
			get{return _discount;}
		}
		#endregion Model

	}
}


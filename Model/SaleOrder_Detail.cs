using System;
namespace ZhangWei.Model
{
	/// <summary>
	/// SaleOrder_Detail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SaleOrder_Detail
	{
		public SaleOrder_Detail()
		{}
		#region Model
		private int _saleorder_id;
		private int _product_id;
		private int _quantity;
		private decimal? _price;
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
		public int Product_ID
		{
			set{ _product_id=value;}
			get{return _product_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		#endregion Model

	}
}


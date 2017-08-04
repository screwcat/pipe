using System;
namespace ZhangWei.Model
{
	/// <summary>
	/// BackSale_Detail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BackSale_Detail
	{
		public BackSale_Detail()
		{}
		#region Model
		private int _backsale_id;
		private int _product_id;
		private decimal _quantity;
		private decimal _price;
		/// <summary>
		/// 
		/// </summary>
		public int BackSale_ID
		{
			set{ _backsale_id=value;}
			get{return _backsale_id;}
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


using System;
namespace ZhangWei.Model
{
	/// <summary>
	/// BackStock_Detail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BackStock_Detail
	{
		public BackStock_Detail()
		{}
		#region Model
		private int _backstock_id;
		private int _product_id;
		private decimal _quantity;
		private decimal _price;
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


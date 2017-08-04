using System;
namespace ZhangWei.Model
{
	/// <summary>
	/// Product_Supplier:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Product_Supplier
	{
		public Product_Supplier()
		{}
		#region Model
		private int _product_id;
		private int _supplier_id;
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
		public int Supplier_ID
		{
			set{ _supplier_id=value;}
			get{return _supplier_id;}
		}
		#endregion Model

	}
}


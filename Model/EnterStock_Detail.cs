using System;
namespace ZhangWei.Model
{
	/// <summary>
	/// EnterStock_Detail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EnterStock_Detail
	{
		public EnterStock_Detail()
		{}
		#region Model
		private int _enterstock_id;
		private int _product_id;
		private decimal _quantity;
		private decimal _price;
		private bool _haveinvoice;
		private string _invoicenum;
		/// <summary>
		/// 
		/// </summary>
		public int EnterStock_ID
		{
			set{ _enterstock_id=value;}
			get{return _enterstock_id;}
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
		/// <summary>
		/// 
		/// </summary>
		public bool HaveInvoice
		{
			set{ _haveinvoice=value;}
			get{return _haveinvoice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InvoiceNum
		{
			set{ _invoicenum=value;}
			get{return _invoicenum;}
		}
		#endregion Model

	}
}


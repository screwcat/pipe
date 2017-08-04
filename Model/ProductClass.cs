using System;
namespace ZhangWei.Model
{
	/// <summary>
	/// ProductClass:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProductClass
	{
		public ProductClass()
		{}
		#region Model
		private int _productclass_id;
		private string _name;
		private int _employee_id;
		private DateTime? _createdate;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int ProductClass_ID
		{
			set{ _productclass_id=value;}
			get{return _productclass_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
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
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}


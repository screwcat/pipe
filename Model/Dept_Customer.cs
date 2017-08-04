using System;
namespace ZhangWei.Model
{
	/// <summary>
	/// Dept_Customer:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Dept_Customer
	{
		public Dept_Customer()
		{}
		#region Model
		private int _dept_id;
		private int _customer_id;
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
		#endregion Model

	}
}


using System;
namespace ZhangWei.Model
{
	/// <summary>
	/// Dept_Supplier:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Dept_Supplier
	{
		public Dept_Supplier()
		{}
		#region Model
		private int _dept_id;
		private int _supplier_id;
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
		public int Supplier_ID
		{
			set{ _supplier_id=value;}
			get{return _supplier_id;}
		}
		#endregion Model

	}
}


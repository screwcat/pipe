using System;
namespace ZhangWei.Model
{
	/// <summary>
	/// HasChecked:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class HasChecked
	{
		public HasChecked()
		{}
		#region Model
		private int _id;
		private DateTime _month;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Month
		{
			set{ _month=value;}
			get{return _month;}
		}
		#endregion Model

	}
}


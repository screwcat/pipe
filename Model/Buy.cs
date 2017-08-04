using System;
namespace ZhangWei.Model
{
	/// <summary>
	/// Buy:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Buy
	{
		public Buy()
		{}
		#region Model
		private int _buy_id;
		private DateTime _comedate;
		private int _dept_id;
		private int _employee_id;
		/// <summary>
		/// 
		/// </summary>
		public int Buy_ID
		{
			set{ _buy_id=value;}
			get{return _buy_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ComeDate
		{
			set{ _comedate=value;}
			get{return _comedate;}
		}
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
		public int Employee_ID
		{
			set{ _employee_id=value;}
			get{return _employee_id;}
		}
		#endregion Model

	}
}


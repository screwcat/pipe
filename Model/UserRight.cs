using System;
namespace ZhangWei.Model
{
	/// <summary>
	/// UserRight:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UserRight
	{
		public UserRight()
		{}
		#region Model
		private int _userid;
		private int _rights;
		/// <summary>
		/// 
		/// </summary>
		public int UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Rights
		{
			set{ _rights=value;}
			get{return _rights;}
		}
		#endregion Model

	}
}


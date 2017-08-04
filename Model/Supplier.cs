using System;
namespace ZhangWei.Model
{
	/// <summary>
	/// Supplier:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Supplier
	{
		public Supplier()
		{}
		#region Model
		private int _supplier_id;
		private string _name;
		private string _address;
		private string _phone;
		private string _fax;
		private string _postalcode;
		private string _constactperson;
		/// <summary>
		/// 
		/// </summary>
		public int Supplier_ID
		{
			set{ _supplier_id=value;}
			get{return _supplier_id;}
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
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Fax
		{
			set{ _fax=value;}
			get{return _fax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PostalCode
		{
			set{ _postalcode=value;}
			get{return _postalcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ConstactPerson
		{
			set{ _constactperson=value;}
			get{return _constactperson;}
		}
		#endregion Model

	}
}


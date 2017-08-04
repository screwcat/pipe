using System;
namespace ZhangWei.Model
{
    /// <summary>
    /// Product:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Product
    {
        public Product()
        { }
        #region Model
        private int _product_id;
        private int _productlist_id;
        private string _name;
        private string _shortname;
        private string _spell;
        private string _s_spell;
        private int _productspec_id;
        private int _productunit_id;
        private decimal _price;
        private decimal _offering_price;
        private int _employee_id;
        private DateTime _createdate = DateTime.Now;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int Product_ID
        {
            set { _product_id = value; }
            get { return _product_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ProductList_ID
        {
            set { _productlist_id = value; }
            get { return _productlist_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string shortname
        {
            set { _shortname = value; }
            get { return _shortname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string spell
        {
            set { _spell = value; }
            get { return _spell; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string s_spell
        {
            set { _s_spell = value; }
            get { return _s_spell; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ProductSpec_ID
        {
            set { _productspec_id = value; }
            get { return _productspec_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ProductUnit_ID
        {
            set { _productunit_id = value; }
            get { return _productunit_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Offering_Price
        {
            set { _offering_price = value; }
            get { return _offering_price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Employee_ID
        {
            set { _employee_id = value; }
            get { return _employee_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}


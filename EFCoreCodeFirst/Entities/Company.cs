namespace EFCoreCodeFirst.Entities
{
    public class Company
    {
        public int Id { get; init; }

        public string CompanyName { get; private set; }
        public Company(string companyName,string companyNo)
        {
            this.CompanyName = companyName;
            this.CompanyNo = companyNo;
        }

        
        private string CompanyNo; //包含进去

        private string remark;
        public string Remark { get { return this.remark; } } //设置只读，不能更改

        public string Note { get; set; }



        /// <summary>
        /// 导航属性
        /// </summary>
        public virtual IList<Account> Accounts { get; set; }
    }
}

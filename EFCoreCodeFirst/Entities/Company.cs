namespace EFCoreCodeFirst.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public virtual IList<Account> Accounts { get; set; }
    }
}

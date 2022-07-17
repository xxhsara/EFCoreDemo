namespace EFCoreCodeFirst.Entities
{
    public class Account
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int CompanyId { get; set; }

        /// <summary>
        /// 引用属性
        /// </summary>
        public virtual Company Company { get; set; }
    }
}

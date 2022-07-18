using EFCoreCodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirst
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> dbContext) : base(dbContext)
        {

        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Company> Company { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=EFCoreCodeFirst;Persist Security Info=True;User ID=sa;Password=123456");


            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(loggerbuilder =>
            {
                loggerbuilder.AddConsole(); //增加控制台输出对应的sql语句，好像不加也可以实现
            }));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}

using EFCoreCodeFirst.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirst.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly CustomerDbContext _dbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,CustomerDbContext customerDbContext)
        {
            _logger = logger;
            _dbContext = customerDbContext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            #region ��������
            //var company = new Company
            //{
            //    CompanyName = "��˾����001",
            //    Accounts = new List<Account>
            //   {
            //       new Account
            //       {
            //           Name="test002"
            //       }
            //   }
            //};
            //_dbContext.Company.Add(company);

            var existCompany = _dbContext.Company.FirstOrDefault();
            var existCompanyIncluding = _dbContext.Company.Include(s=>s.Accounts).FirstOrDefault();

            _dbContext.SaveChanges();
            #endregion
            #region ʵ���State
            //var account = new Entities.Account
            //{
            //    Name = "test001"
            //};
            //_dbContext.Account.Add(account);
          
            //var state = _dbContext.Entry<Account>(account).State;
            //Console.WriteLine($"Add���StateΪ��{state}");

            //_dbContext.SaveChanges();
            var firstAccount = _dbContext.Account.FirstOrDefault(s => s.Name.Equals("test001"));
            var statefirstAccount = _dbContext.Entry<Account>(firstAccount).State;
            Console.WriteLine($"��ѯ���StateΪ��{statefirstAccount}");

            var firstAccountNoTracking = _dbContext.Account.AsNoTracking().FirstOrDefault(s => s.Name.Equals("test001"));
            var statefirstAccountNoTracking = _dbContext.Entry<Account>(firstAccountNoTracking).State;
            Console.WriteLine($"��ѯ��NoTracking��StateΪ��{statefirstAccountNoTracking}");
            #endregion
           


            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
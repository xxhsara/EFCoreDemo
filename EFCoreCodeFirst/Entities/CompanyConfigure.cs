using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreCodeFirst.Entities
{
    public class CompanyConfigure : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property("CompanyNo");
            builder.Property(p => p.Remark).HasField("remark");
            builder.Ignore(e=>e.Note);
        }
    }
}

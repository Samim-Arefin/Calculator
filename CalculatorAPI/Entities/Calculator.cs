using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalculatorAPI.Entities
{
    public class Calculator
    {
        public int Id { get; set; }
        public string? Answer { get; set; }
        public DateTime Date { get; set; }
    }

    public class CalculatorConfiguration : IEntityTypeConfiguration<Calculator>
    {
        public void Configure(EntityTypeBuilder<Calculator> builder)
        {
            builder.ToTable("Calculator");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("int");
            builder.Property(x => x.Answer).HasColumnType("nvarchar(128)");
            builder.Property(x => x.Date).HasColumnType("datetime2");
        }
    }
}

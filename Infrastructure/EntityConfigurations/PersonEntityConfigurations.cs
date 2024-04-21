using Infrastructure.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.EntityConfigurations
{
    internal class PersonEntityConfigurations : IEntityTypeConfiguration<PersonDataModel>
    {
        public void Configure(EntityTypeBuilder<PersonDataModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();
            builder.OwnsOne(c => c.HomeAddress);
            builder.OwnsOne(c => c.WorkAddress);
            builder.OwnsMany(c => c.Documents, b =>
            {
                b.HasKey(c => c.Id);
                b.Property(c => c.Id).ValueGeneratedNever();
                b.ToTable("Documents");

            });
            builder.ToTable("Persons");
        }
    }
}

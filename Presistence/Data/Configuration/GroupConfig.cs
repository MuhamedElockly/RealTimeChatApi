using Domain.Entities.CoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistence.Data.Configuration
{
	public class GroupConfig : IEntityTypeConfiguration<Group>
	{
		public void Configure(EntityTypeBuilder<Group> builder)
		{
			builder.HasOne(g => g.Owner)
				.WithMany()
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}



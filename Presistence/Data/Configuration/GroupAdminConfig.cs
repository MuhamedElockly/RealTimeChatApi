using Domain.Entities.CoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistence.Data.Configuration
{
	public class GroupAdminConfig : IEntityTypeConfiguration<GroupAdmin>
	{
		public void Configure(EntityTypeBuilder<GroupAdmin> builder)
		{
			builder.HasOne(ga => ga.Group)
				.WithMany(g => g.Admins)
				.HasForeignKey(ga => ga.GroupID)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(ga => ga.User)
				.WithMany(u => u.AdminOfGroups)
				.HasForeignKey(ga => ga.UserID)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}



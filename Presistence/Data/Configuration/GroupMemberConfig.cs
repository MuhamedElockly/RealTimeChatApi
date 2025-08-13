using Domain.Entities.CoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistence.Data.Configuration
{
	public class GroupMemberConfig : IEntityTypeConfiguration<GroupMember>
	{
		public void Configure(EntityTypeBuilder<GroupMember> builder)
		{
			builder.HasOne(gm => gm.Group)
				.WithMany(g => g.Members)
				.HasForeignKey(gm => gm.GroupID)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(gm => gm.User)
				.WithMany(u => u.MemberOfGroups)
				.HasForeignKey(gm => gm.UserID)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}



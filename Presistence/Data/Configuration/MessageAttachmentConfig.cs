using Domain.Entities.CoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistence.Data.Configuration
{
	public class MessageAttachmentConfig : IEntityTypeConfiguration<MessageAttachment>
	{
		public void Configure(EntityTypeBuilder<MessageAttachment> builder)
		{
			builder.HasOne(ma => ma.Message)
				.WithOne(m => m.Attachment)
				.HasForeignKey<MessageAttachment>(ma => ma.MessageId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}



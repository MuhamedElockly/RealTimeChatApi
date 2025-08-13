using Domain.Entities.CoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Data.Configuration
{
	public class ChatUserConfig : IEntityTypeConfiguration<ChatUser>
	{
		public void Configure(EntityTypeBuilder<ChatUser> builder)
		{
            builder.HasOne(u => u.ApplicationUser)
                .WithMany()
                .HasForeignKey(u => u.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);
		}
	}
}

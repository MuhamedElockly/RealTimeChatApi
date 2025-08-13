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
	public class ChatSessionConfig : IEntityTypeConfiguration<ChatSession>

	{
		public void Configure(EntityTypeBuilder<ChatSession> builder)
		{

			builder.HasOne(s => s.User1)
				  .WithMany(u => u.SessionsAsUser1)
			      .HasForeignKey(s => s.User1Id)
				  .OnDelete(DeleteBehavior.NoAction);
			builder.HasOne(s => s.User2)
				  .WithMany(u => u.SessionsAsUser2)
				  .HasForeignKey(s => s.User2Id)
				  .OnDelete(DeleteBehavior.NoAction);

		}


	}
}

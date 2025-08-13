using Domain.Entities.CoreEntities;
using Domain.Entities.IdentityEntity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
			//builder.Entity<ApplicationUser>(entity =>
			//{
			//	entity.ToTable("Users");
			//});
		}

		public DbSet<ChatUser> ChatUsers { get; set; }
		public DbSet<ChatSession> ChatSessions { get; set; }
		public DbSet<Group> Groups { get; set; }

		public DbSet<GroupMember> GroupMembers { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<MessageAttachment> MessageAttachments { get; set; }
		public DbSet<UserConnection> UserConnections { get; set; }

	}
}

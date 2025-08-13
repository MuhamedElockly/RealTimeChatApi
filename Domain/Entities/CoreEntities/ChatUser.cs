using Domain.Entities.IdentityEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CoreEntities
{
	public class ChatUser : BaseEntity<int>
	{
		public string AppUserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
		public DateTime CreatedAt { get; set; }
		public string Descreption { get; set; }
		public bool Online { get; set; }
		public DateTime LastSeen { get; set; }
		public ICollection<ChatSession> SessionsAsUser1 { get; set; } = new HashSet<ChatSession>();
		public ICollection<ChatSession> SessionsAsUser2 { get; set; } = new HashSet<ChatSession>();
		[NotMapped]
		public IEnumerable<ChatSession> Sessions => SessionsAsUser1.Concat(SessionsAsUser2);
		public virtual ICollection<GroupMember> MemberOfGroups { get; set; } = new HashSet<GroupMember>();
		public virtual ICollection<Group> AdminOfGroups { get; set; } = new HashSet<Group>();
	}
}

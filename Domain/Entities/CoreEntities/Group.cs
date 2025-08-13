using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CoreEntities
{
	public class Group : BaseEntity<int>
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public ushort Capacity { get; set; }
		public DateTime CreatedAt { get; set; }
		public string? imageUrl { get; set; }
		public bool IsDeleted { get; set; } = false;
		public bool IsLocked { get; set; } = false;
		public ChatUser Owner { get; set; }
		public virtual ICollection<GroupAdmin> Admins { get; set; } = new HashSet<GroupAdmin>();
		public virtual ICollection<GroupMember> Members { get; set; } = new HashSet<GroupMember>();
		public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

	}
}

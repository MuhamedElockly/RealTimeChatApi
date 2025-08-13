using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CoreEntities
{
	public class ChatSession : BaseEntity<int>
	{
		public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
		public bool IsClosed { get; set; }

		public int User1Id { get; set; }

		public int User2Id { get; set; }
		public ChatUser User1 { get; set; }
		public ChatUser User2 { get; set; }

		public DateTime CreatedAt { get; set; }

	}
}

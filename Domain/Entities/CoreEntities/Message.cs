using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CoreEntities
{
	public class Message : BaseEntity<int>
	{
		public string Text { get; set; }
		public int SenderId { get; set; }
		public ChatUser Sender { get; set; }
		public DateTime SendAt { get; set; }
		public DateTime ReceiveAt { get; set; }
		public DateTime SeenAt { get; set; }
		public bool IsSeen { get; set; }
		public bool IsReceived { get; set; }
		public bool IsDeleted { get; set; }
		public virtual MessageAttachment? Attachment { get; set; }

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CoreEntities
{
	public class MessageAttachment : BaseEntity<int>
	{
		public virtual ICollection<string>? imageUrls { get; set; }= new HashSet<string>();
		public int MessageId { get; set; }
		public Message Message { get; set; }
	}
}

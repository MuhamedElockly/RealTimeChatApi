using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CoreEntities
{
	public class UserConnection : BaseEntity<int>
	{
		public int UserId { get; set; }
		public ChatUser User { get; set; }
		public string ConnectionId { get; set; }
	}
}

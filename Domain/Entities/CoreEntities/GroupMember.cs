using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CoreEntities
{
	public class GroupMember :BaseEntity<int>
	{
		public int UserID { get; set; }
		public ChatUser User { get; set; }
		public int GroupID { get; set; }
		public Group Group { get; set; }
	}
}

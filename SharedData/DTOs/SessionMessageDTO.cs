using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedData.DTOs
{
	public class SessionMessageDTO
	{
		public int messageId { get; set; }
		public DateTime SendAt { get; set; }
		public int SessionId { get; set; }
		public string Text { get; set; }

	}
}

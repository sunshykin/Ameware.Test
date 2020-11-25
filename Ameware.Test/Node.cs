using System.Collections.Generic;
using System.Linq;

namespace Ameware.Test
{
	public class Node
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public List<Node> Childs { get; set; }

		public bool IsRoot => Id == 0;
		public bool HasChilds => Childs != null && Childs.Any();
	}
}
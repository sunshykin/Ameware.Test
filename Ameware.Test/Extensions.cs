using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ameware.Test
{
	public static class Extensions
	{
		/// <summary>
		/// Method mapping <c>Item</c> to <c>Node</c>
		/// </summary>
		/// <param name="item"><c>Item</c> object</param>
		/// <returns></returns>
		public static Node ToNode(this Item item)
		{
			return new()
			{
				Id = item.Id,
				Text = item.Text,
				Childs = new List<Node>()
			};
		}

		private static StringBuilder AppendWithTabs(this StringBuilder builder, string value, int tabsCount)
		{
			if (tabsCount > 0)
			{
				builder.Append(String.Concat(Enumerable.Repeat("\t", tabsCount)));
			}

			builder.AppendLine(value);

			return builder;
		}

		/// <summary>
		/// Converting flat id-parent list to tree
		/// </summary>
		/// <param name="items"></param>
		/// <returns></returns>
		public static Node ToTree(this IEnumerable<Item> items)
		{
			// O(N^2)

			// Creating a variable for Parent-Node
			Node parent = null;

			// Would be better if we could use Array.Length for capacity
			var dictionary = new Dictionary<int, Node>();

			// Creating a dictionary
			foreach (var item in items)
			{
				dictionary.TryAdd(item.Id, item.ToNode());
			}

			foreach (var item in items)
			{
				if (item.Parent == -1)
				{
					parent = dictionary[item.Id];
				}
				else
				{
					dictionary[item.Parent].Childs.Add(dictionary[item.Id]);
				}
			}

			return parent;
		}

		/// <summary>
		/// Formats A tree
		/// </summary>
		/// <param name="node">Parent node</param>
		/// <returns>String with markup hierarchy of nodes</returns>
		public static string MakeFormattedString(this Node node)
		{
			void printNode(StringBuilder builder, Node node, int tabLevel = 1)
			{
				// Opening the list if node is the root
				if (node.IsRoot)
				{
					builder.AppendLine("<ul>");
				}

				// Describing the node
				builder.AppendWithTabs($"<li>{node.Id}. {node.Text} ({tabLevel})</li>", tabLevel);

				if (node.HasChilds)
				{
					builder.AppendWithTabs("<ul>", tabLevel);

					foreach (var child in node.Childs)
					{
						printNode(builder, child, tabLevel + 1);
					}

					builder.AppendWithTabs("</ul>", tabLevel);
				}

				// Closing the list if node is the root
				if (node.IsRoot)
				{
					builder.AppendLine("</ul>");
				}
			}

			var resultBuilder = new StringBuilder();
			printNode(resultBuilder, node);

			return resultBuilder.ToString();
		}
	}
}
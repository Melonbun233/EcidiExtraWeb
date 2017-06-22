using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Node 的摘要说明
/// </summary>

namespace Common
{
	public class Node
	{
		private int id;
		private string channelName;
		private string title;
		private string callIndex;
		private Node parent;
		private List<Node> children; 

		public Node() { }

		public Node(int id, string channelName, string title, string callIndex)
		{
			this.id = id;
			this.channelName = channelName;
			this.title = title;
			this.callIndex = callIndex;
		}

		public void AddChild(Node child)
		{
			child.SetParent(this);
			this.children.Add(child);
		}

		public void SetParent(Node parent)
		{
			this.parent = parent;
		}

		public bool IsLeaf()
		{
			bool isLeaf = children == null ? true : false;
			return isLeaf;
		}

		public List<Node> GetChildren()
		{
			List<Node> children = new List<Node>();
			children = this.children;
			return children;
		}

		public int GetId()
		{
			int id = this.id;
			return id;
		}

		public Node GetParent()
		{
			Node parent = new Node();
			parent = this.parent;
			return parent;
		}

		public string GetCallIndex()
		{
			return callIndex;
		}

		public string GetTitle()
		{
			return title;
		}

		public string GetChannelName()
		{
			return channelName;
		}

		public static string ConstructNavHtml(Node node)
		{
			string html = "<div id='aside-nav-container'><ul class='nav aside-nav'>";
			html += ConstructNavHtml(html, node);
			html += "</ul></div>";
			return html;
		}
		private static string ConstructNavHtml(string html, Node node)
		{
			if(node.GetChildren() != null)		//NOT leaf nod
			{
				html += "<li class='nav-dropdown'><a href='../" + node.GetChannelName() + node.GetCallIndex() + ".aspx'" + node.GetTitle() + "</a>";
				foreach(Node child in node.GetChildren())
				{
					html += ConstructNavHtml(html, child);
				}
				html += "</li>";
			} else								//leaf node
			{
				html += "<li><a href ='../" + node.GetChannelName() + node.GetCallIndex() + ".aspx'" + node.GetTitle() + "</a></li>";
			}
			return html;
		}
	}
}
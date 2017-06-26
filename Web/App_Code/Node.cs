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
		private List<Node> children = new List<Node>(); 

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

		/// <summary>
		/// Construct html code which is an aside navigation
		/// </summary>
		/// <param name="node">the start node that contains all article categories</param>
		/// <returns></returns>
		public static string ConstructNavHtml(Node node)
		{
			string html = "<div id='aside-nav-container'><ul class='nav aside-nav'>";
			foreach (Node child in node.GetChildren())
			{
				html = ConstructNavHtml(html, child);
			}

			html += "</ul></div>";
			return html;
		}
		private static string ConstructNavHtml(string html, Node node)
		{
			if (node.GetCallIndex() == "ManagerTeam")	// 在这里可以选择特殊标题 更改其url为某一个特定的值
			{		// ManagerTeam is a leaf node
				string url = ConstructPage.ConstructListURL(node.GetId());
				html += "<li><a href ='" + url + "'>项目经理<br>（总监）团队</a></li>";		// 在此处更改url
			} 
			else if(node.GetCallIndex() == "ProjectManagementAgentConstruction")
			{		// a leaf node
				string url = ConstructPage.ConstructListURL(node.GetId());
				html += "<li><a href ='" + url + "'>工程管理<br>与工程代建</a></li>";       // 在此处更改url
			}
			else
			{
				if (node.GetChildren().Count != 0)      //NOT leaf nod
				{
					html += "<li class='nav-dropdown'><a>" + node.GetTitle() + "</a>" + "<ul class='nav-dropdown-list'>";
					foreach (Node child in node.GetChildren())
					{
						html = ConstructNavHtml(html, child);
					}
					html += "</ul></li>";
				}
				else                                //leaf node
				{
					string url = ConstructPage.ConstructListURL(node.GetId());
					html += "<li><a href ='" + url + "'>" + node.GetTitle() + "</a></li>";
				}
			}

			return html;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Common;

/// <summary>
/// This class contains methods used to construct pages
/// </summary>

namespace Common
{
	public class ConstructPage
	{
		/// <summary>Get channel ID by channel title</summary>
		/// <param name="channelTitle"> This should be Chinese channel name/title</param>
		/// <returns int>channel ID</returns>
		public static int GetChannelId(string channelTitle)
		{
			string strSQL = "select id from " + Base.ArticleCategory + " where title = '" + channelTitle +"'";
			int channelId = Base.ExecuteSql4Value(strSQL);
			return channelId;
		}

		///<summary>Get channel Name by channel id</summary>
		///<param name="channelId"
		///
		public static string GetChannelName(int channelId)
		{
			string strSQL = "select name from " + Base.ChannelCategory + " where id = " + channelId;
			string channelName = Base.ExecuteSql4String(strSQL);
			return channelName;
		}

		/// <summary>Construct an aside navigation using HTML tags</summary>
		/// <param name="channelId">ID of the channel used to construct aside navigation</param>
		/// <param name="channelName">This should be English channel name</param>
		/// <returns>Set of HTML tags of the aside navigation</returns>

		public static string GetAsideNav(string channelName, int channelId	)
		{
			string html = "";
			string strSQL = "select id, title, call_index, parent_id, class_list, class_layer from " + Base.ArticleCategory + " where channel_id = " + channelId;
			DataTable dt = Base.ExecuteSql4Dt(strSQL);
			Node asideNav = ConstructTree(dt, channelName);     //construct a tree
			html = Node.ConstructNavHtml(asideNav);

			return html; 
		}

		private static Node ConstructTree(DataTable dt, string channelName)
		{
			DataRow[] firstLayerDr = dt.Select("class_layer = 1");
			DataRow[] secondLayerDr = dt.Select("class_layer = 2");
			DataRow[] thirdLayerDr = dt.Select("class_layer = 3");

			// construct a tree
			Node node = new Node();
			foreach (DataRow firstDr in firstLayerDr)
			{
				int firstId = Int32.Parse(firstDr["id"].ToString());
				Node firstNode = new Node(firstId, channelName, firstDr["title"].ToString(), firstDr["call_index"].ToString());
				node.AddChild(firstNode);
				// add child to first layer channel
				foreach (DataRow secondDr in secondLayerDr)
				{
					int secondId = Int32.Parse(secondDr["id"].ToString());
					int secondParentId = Int32.Parse(secondDr["parent_id"].ToString());
					if (secondParentId == firstId)
					{
						Node secondNode = new Node(secondId, channelName, secondDr["title"].ToString(), secondDr["call_index"].ToString());
						firstNode.AddChild(secondNode);
						//add child to second layer channel
						foreach (DataRow thirdDr in thirdLayerDr)
						{
							int thirdId = Int32.Parse(secondDr["id"].ToString());
							int thirdParentId = Int32.Parse(thirdDr["parent_id"].ToString());
							if (thirdParentId == secondId)
							{
								Node thirdNode = new Node(thirdId, channelName, thirdDr["title"].ToString(), thirdDr["call_index"].ToString());
								secondNode.AddChild(thirdNode);
							}
						}

					}
				}
			}
		return node;
		}
	}
}
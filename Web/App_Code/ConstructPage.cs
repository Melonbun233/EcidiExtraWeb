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


		/// <summary>Construct an aside navigation using HTML tags</summary>
		/// <param name="channelId">ID of the channel used to construct aside navigation</param>
		/// <returns>Set of HTML tags of the aside navigation</returns>
		public static string ConstructAsideNav(int channelId)
		{
			string channelName = Utils.GetChannelName(channelId);
			string strSQL = "select id, title, call_index, parent_id, class_list, class_layer from " + Base.ArticleCategory + " where channel_id = " + channelId;
			DataTable dt = Base.ExecuteSql4Dt(strSQL);
			Node asideNav = ConstructTree(dt, channelName);     //construct a tree
			string html = Node.ConstructNavHtml(asideNav);

			return html; 
		}

		/// <summary>
		/// Construct a URL that has unique query string for a list page
		/// </summary>
		/// <param name="articleCateId">ID of article category</param>
		/// <returns></returns>
		public static string ConstructListURL(int articleCateId)
		{
			string url;
			string strSQL = "select channel_id, call_index from " + Base.ArticleCategory + " where id = " + articleCateId;
			DataTable dt = Base.ExecuteSql4Dt(strSQL);

			string channelId = dt.Rows[0][0].ToString();
			string articleCateName = dt.Rows[0][1].ToString();

			url = "list.aspx?articleCateId=" + articleCateId + "&channelId=" + channelId + "&articleCateName=" + articleCateName;
			
			return url;
		}

		/// <summary>
		/// Construct a Url that has unique query string for a detail page
		/// </summary>
		/// <param name="articleId">ID of the article</param>
		/// <returns></returns>
		public static string ConstructDetailURL(int articleId)
		{
			string url;
			string strSQL = "select channel_id, category_id from " + Base.ArticleInfo + " where id = " + articleId;
			DataTable dt = Base.ExecuteSql4Dt(strSQL);

			string channelId = dt.Rows[0][0].ToString();
			string categoryId = dt.Rows[0][1].ToString();

			url = "detail.aspx?articleId=" + articleId + "&channelId=" + channelId + "&articleCateId=" + categoryId;

			return url;
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
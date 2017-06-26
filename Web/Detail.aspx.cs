using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Common;
using System.Configuration;

public partial class Detail : System.Web.UI.Page
{
	public static int articleId;
	public static int channelId;
	public static int articleCateId;
	public static string articleTitle;
	public static string asideNavHtml;
	public static string articleTime;
	public static string articleContent;
	public static string articleAttach;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			articleId = Int32.Parse(Request.QueryString["articleId"].ToString());
			channelId = Int32.Parse(Request.QueryString["channelId"].ToString());
			articleCateId = Int32.Parse(Request.QueryString["articleCateId"].ToString());

			asideNavHtml = ConstructPage.ConstructAsideNav(channelId);

			GetArticle();
		}
	}

	protected void GetArticle()
	{
		string strSQL = "select * from " + Base.ArticleInfo + " where id =" + articleId;
		DataTable dt = Base.ExecuteSql4Dt(strSQL);
		if (dt.Rows.Count != 0)
		{
			articleTitle = dt.Rows[0]["title"].ToString();
			articleTime = dt.Rows[0]["add_time"].ToString();
			articleContent = dt.Rows[0]["content"].ToString();
			string[] allAttach = GetAttachment(dt.Rows[0]["id"].ToString());
			articleAttach = allAttach[0];
			articleAttchUrl.Value = allAttach[1];
		}
	}

	protected string[] GetAttachment(string id)
	{
		string url = "http://" + HttpContext.Current.Request.Url.Host;
		string strSQL = "select * from " + ConfigurationManager.AppSettings["AttachInfo"].ToString() + " where article_id=" + id;
		DataTable dt = Base.ExecuteSql4Dt(strSQL);
		string strRet = "<p style=\"margin-top:10px;font-weight:bold;\">相关附件</p>";
		string strUrl = "";
		if (dt.Rows.Count != 0)
		{
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				string fileurl = url + dt.Rows[i]["file_path"].ToString();
				strRet += "<p class=\"attach\">" + dt.Rows[i]["file_name"].ToString() + "&nbsp;&nbsp;<a href=\"javascript:viewFile('" + fileurl + "');\">[查看]</a>&nbsp;<a href=\"" + fileurl + "\">[下载]</a></p>";
				strUrl += fileurl + ",";
			}
			strRet = strRet.Remove(strRet.Length - 1);
			strUrl = strUrl.Remove(strUrl.Length - 1);
		}
		string[] arr = new string[2];
		arr[0] = strRet;
		arr[1] = strUrl;
		return arr;

	}
}
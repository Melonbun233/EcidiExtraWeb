using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using Common;

public partial class List : System.Web.UI.Page
{
	public static string articleCateName;
	public static int channelId;
	public static string channelName;
	public static int articleCateId;
	public static string asideNavHtml;
	public static string title;
	public static string channelViewName;
	public readonly static int PAGESIZE = 15;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			articleCateId = Int32.Parse(Request.QueryString["articleCateId"].ToString());
			articleCateName = Request.QueryString["articleCateName"];
			channelId = Int32.Parse(Request.QueryString["channelId"].ToString());
			channelName = Utils.GetChannelName(channelId);
			title = Utils.GetArticleCateTitle(articleCateId);
			channelViewName = ConfigurationManager.AppSettings[channelName + "Info"];
			asideNavHtml = ConstructPage.ConstructAsideNav(channelId);

			BindData();

		}
	}

	protected void BindData()
	{
		string strSQL = "select count(*) from " + channelViewName + " where category_id=" + articleCateId;
		int count = Base.ExecuteSql4Value(strSQL);
		ListPager.RecordCount = count;
		if (count == 0)
		{
			noInfo.Text = "No Information";
			noInfo.Visible = true;
		}

		ListPager.PageSize = PAGESIZE;
		strSQL = "select top " + PAGESIZE + " * from " + channelViewName + "  where status=0 and category_id=" + articleCateId + " and id not in (select Top " + (ListPager.CurrentPageIndex - 1) * PAGESIZE + " id from " + channelViewName + " where status=0 and category_id=" + articleCateId + " order by sort_id desc,add_time desc) order by sort_id desc,add_time desc";

		try
		{
			DataList.DataSource = Base.ExecuteSql4Ds(strSQL);
			DataList.DataBind();
		} catch (Exception e)
		{
			throw new Exception(e.Message);
		}
	}

	protected void ListPager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
	{
		ListPager.CurrentPageIndex = e.NewPageIndex;
		BindData();
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

public partial class Pages_Ecidi_Tech_and_Talent_Invention : System.Web.UI.Page
{
	public static string AsideNavigation;
	private static int ChannelId;
	private static string ChannelName;
	private static string Title;


	protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
		{
			Title = "发明";
			string id = Request.QueryString["id"];
			ChannelId = ConstructPage.GetChannelId(Title);
			ChannelName = ConstructPage.GetChannelName(ChannelId);
			AsideNavigation = ConstructPage.GetAsideNav(ChannelName, ChannelId);
		}
	}

	

	
}
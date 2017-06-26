using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using Common;

public partial class SingleContentPage : System.Web.UI.MasterPage
{
	public static string introUrl;
	public static string organizationUrl;
	public static string certificationUrl;
	public static string honorUrl;
	public static string managerUrl;
	public static string proUrl;
	public static string trainUrl;
	public static string innovationUrl;
	public static string recruitUrl;
	public static string supervisionUrl;
	public static string biddingUrl;
	public static string contractingUrl;
	public static string agentUrl;
	public static string newsUrl;
	public static string conceptUrl;
	public static string partyUrl;
	public static string teamStoryUrl;
	public static string staffStoryUrl;
	public static string responsibilityUrl;

	protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
		{
			GetUrl();
		}
    }

	protected void GetUrl()
	{
		introUrl = ConstructPage.ConstructListURL(Int32.Parse(ConfigurationManager.AppSettings["Introduction"]));
		organizationUrl = ConstructPage.ConstructListURL( Int32.Parse(ConfigurationManager.AppSettings["Organization"]));
		certificationUrl = ConstructPage.ConstructListURL( Int32.Parse(ConfigurationManager.AppSettings["Certification"]));
		honorUrl = ConstructPage.ConstructListURL( Int32.Parse(ConfigurationManager.AppSettings["Honor"]));
		managerUrl = ConstructPage.ConstructListURL( Int32.Parse(ConfigurationManager.AppSettings["ManagerTeam"]));
		proUrl= ConstructPage.ConstructListURL( Int32.Parse(ConfigurationManager.AppSettings["ProfessorTeam"]));
		trainUrl = ConstructPage.ConstructListURL( Int32.Parse(ConfigurationManager.AppSettings["Train"]));
		innovationUrl = ConstructPage.ConstructListURL( Int32.Parse(ConfigurationManager.AppSettings["Innovation"]));
		recruitUrl = ConstructPage.ConstructListURL( Int32.Parse(ConfigurationManager.AppSettings["Recruit"]));
		supervisionUrl = ConstructPage.ConstructListURL( Int32.Parse(ConfigurationManager.AppSettings["Supervision"]));
		biddingUrl = ConstructPage.ConstructListURL( Int32.Parse(ConfigurationManager.AppSettings["BiddingAgent"]));
		contractingUrl = ConstructPage.ConstructListURL( Int32.Parse(ConfigurationManager.AppSettings["ProjectContracting"]));
		agentUrl = ConstructPage.ConstructListURL( Int32.Parse(ConfigurationManager.AppSettings["ProjectManagementAgentConstruction"]));
		newsUrl = ConstructPage.ConstructListURL( Int32.Parse(ConfigurationManager.AppSettings["News"]));
		conceptUrl = ConstructPage.ConstructListURL( Int32.Parse(ConfigurationManager.AppSettings["Concept"]));
		partyUrl = ConstructPage.ConstructListURL( Int32.Parse(ConfigurationManager.AppSettings["PartyConstruction"]));
		teamStoryUrl = ConstructPage.ConstructListURL( Int32.Parse(ConfigurationManager.AppSettings["TeamStory"]));
		staffStoryUrl = ConstructPage.ConstructListURL( Int32.Parse(ConfigurationManager.AppSettings["StaffStory"]));
		responsibilityUrl = ConstructPage.ConstructListURL( Int32.Parse(ConfigurationManager.AppSettings["Responsibility"]));
	}
}


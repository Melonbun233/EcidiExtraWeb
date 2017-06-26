using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using System.Data;

public partial class Pages_Default : System.Web.UI.Page
{
	public static string Photo;
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			Photo = "";
			GetPhoto();
		}
	}

	protected void GetPhoto()
	{
		string strSQL = "select top 5 id, title, img_url, zhaiyao from " + Base.Ecidi_NewsInfo + " where status=0 and img_url!='' order by sort_id desc, add_time desc";
		DataTable dt = Base.ExecuteSql4Dt(strSQL);
		if(dt.Rows.Count != 0)
		{
			foreach(DataRow row in dt.Rows)
			{
				int id = Int32.Parse(row["id"].ToString());
				Photo += "<li><a href='" + ConstructPage.ConstructDetailURL(id) + "'><img src='" + GetFirstImage(row["img_url"].ToString()) + "' alt='" + row["zhaiyao"].ToString() + "' /></a></li>";
			}
		} else
		{
			Photo = "No Info";
		}
	}

	private string GetFirstImage(string str)
	{
		string url = "http://" + HttpContext.Current.Request.Url.Host;
		str = str.Replace("D:", url);
		str = str.Replace("\\", "/");
		string[] arrImg = str.Split(',');
		string imgUrl = "";
		int length = arrImg.Length;
		if (length != 0)
		{
			imgUrl = arrImg[0];
		}
		return imgUrl;
	}
}

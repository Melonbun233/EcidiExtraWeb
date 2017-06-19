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
using DBBase;

public partial class content : System.Web.UI.Page
{
    public static string ttitle;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ttitle = "";
            SqlIn.StartProcessRequest();
            string cata = Request.QueryString["id"] == null ? "" : Request.QueryString["id"];
            string cataid = Request.QueryString["cataid"] == null ? "" : Request.QueryString["cataid"];
            if (cata != "" || cataid != "")
            {
                string param = "pkid";
                string key = cata;
                if (cataid != "")
                {
                    param = "catalogid";
                    key = cataid;
                }

                string strSQL = "select top 1 * from " + Base.CatalogInfo + " where " + param + "='" + key + "'";
                DataTable dt = Base.ExecuteSql4Dt(strSQL);
                if (dt.Rows.Count != 0)
                {
                    //rtitle.Text = dt.Rows[0]["title"].ToString();
                    ttitle = dt.Rows[0]["title"].ToString();
                    //pTime.Text = Convert.ToDateTime(dt.Rows[0]["recorddate"].ToString()).ToShortDateString();
                    rcontent.Text = dt.Rows[0]["content"].ToString();
                    if (dt.Rows[0]["attachmentName"].ToString() != "")
                    {
                        attach.Text = GetAttachment(dt.Rows[0]["attachmentPath"].ToString(), dt.Rows[0]["attachmentName"].ToString());
                    }
                }
            }
        }
    }
    private string GetAttachment(string str, string strName)
    {
        string url = "http://" + HttpContext.Current.Request.Url.Host;
        //string url = "http://web.simulate.com";
        str = str.Replace("D:", url);
        str = str.Replace("\\", "/");
        string[] arrAttach = str.Split(',');
        string[] arrName = strName.Split(',');
        string strRet = "<p style=\"margin-top:10px;font-weight:bold;\">相关附件</p>";
        int iLength = arrAttach.Length;
        if (iLength != 0)
        {
            for (int i = 0; i < iLength; i++)
            {
                strRet += "<p class=\"attach\"><a href=\"" + arrAttach[i] + "\" target=\"_blank\">" + arrName[i] + "</a></p>";
            }
            strRet = strRet.Remove(strRet.Length - 1);
        }
        return strRet;
    }
}

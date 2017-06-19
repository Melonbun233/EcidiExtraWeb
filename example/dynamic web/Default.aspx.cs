using System;
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

public partial class _Default : System.Web.UI.Page 
{
    public static string photo;
    public static string catagory;
    public static string notify;
    public static string news;
    public static string file;
    public static string marqueen;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetCookie();
            photo = "";
            catagory = "";
            notify = "";
            news = "";
            file = "";
            marqueen = "";
            GetPhotos();
            //GetNotify();
            GetNews();
            GetFile();
            GetPioneer();
            //GetCatagory();
        }
    }
    private void SetCookie()
    {
        string strX1 = Request.QueryString["X1"] == null ? "qJhJeLmI4LoLlL" : Request.QueryString["X1"];
        string strX2 = Request.QueryString["X2"] == null ? "dMrEpBmDtDnEpFpEwCzEmACSwMmEoDrBtCrC" : Request.QueryString["X2"];
        if (strX1 != "")
        {
            Request.Cookies.Clear();
            HttpCookie cookie = HttpContext.Current.Request.Cookies["60anniversary"];
            if (cookie == null)
            {
                cookie = new HttpCookie("60anniversary");
            }
            cookie["X1"] = strX1;
            cookie["X2"] = strX2;
            cookie.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.AppendCookie(cookie);
        }        
    }
    protected void GetPhotos()
    {
        string strSQL = "select top 5 pkid,title,content,attachmentpictpath from " + Base.CatalogInfo + " where catalogid='2' order by recorddate desc,pkid desc";
        DataTable dt = Base.ExecuteSql4Dt(strSQL);
        if (dt.Rows.Count != 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                photo += "<li><a href='detail.aspx?id="+row["pkid"].ToString()+"' title=\"" + row["title"].ToString() + "\"><img src=\"" + GetFirstImage(row["attachmentpictpath"].ToString()) + "\" alt=\"" + Common.Utils.CutString(row["title"].ToString(), 24) + "\" text=\"" + Common.Utils.DropHTML(row["content"].ToString(), 95) + "\" width=\"218\"  height=\"174\"/></a></li>";
            }
        }
        else
        {
            photo = "暂无内容";
        }
    }
    protected void GetNotify()
    {
        string strSQL = "select top 6 pkid,title from " + Base.CatalogInfo + " where catalogid='9' order by recorddate desc,pkid desc";
        DataTable dt = Base.ExecuteSql4Dt(strSQL);
        if (dt.Rows.Count != 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                notify += "<li><a href='detail.aspx?id=" + row["pkid"].ToString() + "' title=\"" + row["title"].ToString() + "\">·" + Common.Utils.CutString(row["title"].ToString(),28) + "</a></li>";
            }
        }
        else
        {
            notify = "暂无内容";
        }
    }
    protected void GetNews()
    {
        string strSQL = "select top 7 pkid,title,recorddate,flag from " + Base.CatalogInfo + " where catalogid='3' order by flag desc,recorddate desc,pkid desc";
        DataTable dt = Base.ExecuteSql4Dt(strSQL);
        if (dt.Rows.Count != 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                string title = Common.Utils.CutString(row["title"].ToString(), 56);
                if (row["flag"].ToString() == "置顶")
                    title = "<b>" + Common.Utils.CutString(row["title"].ToString(), 56) + "</b>";
                news += "<li><span>"+Convert.ToDateTime(row["recorddate"]).ToShortDateString()+"</span><a href='detail.aspx?id=" + row["pkid"].ToString() + "' title=\"" + row["title"].ToString() + "\">·" + title + "</a></li>";
            }
        }
        else
        {
            news = "暂无内容";
        }
    }
    //科技论坛
    protected void GetFile()
    {
        string strSQL = "select top 4 pkid,title,recorddate,flag from " + Base.CatalogInfo + " where catalogid='21' order by flag desc,recorddate desc,pkid desc";
        DataTable dt = Base.ExecuteSql4Dt(strSQL);
        if (dt.Rows.Count != 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                string title = Common.Utils.CutString(row["title"].ToString(), 56);
                if (row["flag"].ToString() == "置顶")
                    title = "<b>" + Common.Utils.CutString(row["title"].ToString(), 56) + "</b>";
                file += "<li><a href='detail.aspx?id=" + row["pkid"].ToString() + "' title=\"" + row["title"].ToString() + "\">·" + title + "</a></li>";
            }
        }
        else
        {
            file = "暂无内容";
        }
    }
    protected void GetCatagory()
    {
        string strSQL = "select top 6 title,link from " + Base.CatalogInfo + " where catalogid='12' order by recorddate desc,pkid desc";
        DataTable dt = Base.ExecuteSql4Dt(strSQL);
        if (dt.Rows.Count != 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                string strUrl = row["link"].ToString();
                if (strUrl.IndexOf("?") != -1)
                    strUrl += "&X1=" + Common.Utils.GetCookie("partyconstruction", "X1") + "&X2=" + Common.Utils.GetCookie("partyconstruction", "X2");
                else
                    strUrl += "?X1=" + Common.Utils.GetCookie("partyconstruction", "X1") + "&X2=" + Common.Utils.GetCookie("partyconstruction", "X2"); 
                catagory += "<li><a href=\"javascript:openwin('" + strUrl + "')\">" + row["title"].ToString() + "</a></li>";
            }
        }
        else
        {
            catagory = "暂无内容";
        }
    }
    //我与华东院
    protected void GetPioneer()
    {
        string strSQL = "select top 7 pkid,title,recorddate,flag from " + Base.CatalogInfo + " where catalogid='22' order by flag desc, recorddate desc,pkid desc";
        DataTable dt = Base.ExecuteSql4Dt(strSQL);
        if (dt.Rows.Count != 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                string title = Common.Utils.CutString(row["title"].ToString(), 56);
                if (row["flag"].ToString() == "置顶")
                    title = "<b>" + Common.Utils.CutString(row["title"].ToString(), 56) + "</b>";
                marqueen += "<li><span>" + Convert.ToDateTime(row["recorddate"]).ToShortDateString() + "</span><a href='detail.aspx?id=" + row["pkid"].ToString() + "' title=\"" + row["title"].ToString() + "\">·" + title + "</a></li>";
            }
        }
        else
        {
            marqueen = "暂无内容";
        }
    }

    private string GetFirstImage(string str)
    {
        if (str.Trim() == "")
            return "images/sample.jpg";
        else
        {
            string url = "http://" + HttpContext.Current.Request.Url.Host;
            //string url = "http://web.simulate.com";
            str = str.Replace("D:", url);
            str = str.Replace("\\", "/");
            string[] arrImg = str.Split(',');
            string strRet = "";
            int iLength = arrImg.Length;
            if (iLength != 0)
            {
                strRet = arrImg[0];
            }
            return strRet;
        }
    }
}

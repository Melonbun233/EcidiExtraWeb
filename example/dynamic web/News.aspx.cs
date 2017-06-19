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

public partial class News : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindData();
    }
    protected void BindData()
    {
        string cata = "3";
        string strCount = "select count(*) from " + Base.CatalogInfo + " where catalogid='" + cata + "'";
        int iCount = Base.ExecuteSql4Value(strCount);
        pager.RecordCount = iCount;//总记录条数;
         if (iCount == 0)
        {
            noinfo.Text = "暂无信息！";
            noinfo.Visible = true;
        }
        pager.PageSize = 15;//每页12条记录;
        string strSQL = "select top " + pager.PageSize + " * from " + Base.CatalogInfo + " where catalogid='" + cata + "' and pkid not in (select Top " + (pager.CurrentPageIndex - 1) * pager.PageSize + " pkid from " + Base.CatalogInfo + " where catalogid='" + cata + "' order by flag desc, recorddate desc,pkid desc) order by flag desc, recorddate desc,pkid desc";
        try
        {
            DataList1.DataSource = Base.ExecuteSql4Ds(strSQL);
            DataList1.DataBind();
        }

        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

    }
    protected void pager_PageChanging1(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        pager.CurrentPageIndex = e.NewPageIndex;
        BindData();
    }
}

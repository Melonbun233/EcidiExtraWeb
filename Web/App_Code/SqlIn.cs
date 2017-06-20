using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Class1 的摘要说明
/// </summary>
public class SqlIn
{
	public SqlIn()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static void StartProcessRequest()
    {
        try
        {
            string getkeys = "";
            string sqlErrorPage = "SqlInError.aspx";//转向的错误提示页面 
            if (System.Web.HttpContext.Current.Request.QueryString != null)
            {
                //System.Web.HttpContext.Current.Response.End();

                for (int i = 0; i < System.Web.HttpContext.Current.Request.QueryString.Count; i++)
                {
                    getkeys = System.Web.HttpContext.Current.Request.QueryString.Keys[i];
                    //----------
                     bool ReturnValue = true;
                     string Str = System.Web.HttpContext.Current.Request.QueryString[getkeys];
                     if (Str.Trim() != "")
                     {
                         string SqlStr = "and|'|<|>|exec|insert|select|delete|update|count|*|chr|mid|master|truncate|char|declare";
                         string[] anySqlStr = SqlStr.Split('|');
                         foreach (string ss in anySqlStr)
                         {
                             if (Str.ToLower().IndexOf(ss) >= 0)
                             {
                                 ReturnValue = false;
                                 break;
                             }
                         }
                     }
                    //----------
                    if (!ReturnValue)
                    {
                        System.Web.HttpContext.Current.Response.Redirect(sqlErrorPage);
                        System.Web.HttpContext.Current.Response.End();
                    }
                }
            }
            if (System.Web.HttpContext.Current.Request.Form != null)
            {
                for (int i = 0; i < System.Web.HttpContext.Current.Request.Form.Count; i++)
                {
                    getkeys = System.Web.HttpContext.Current.Request.Form.Keys[i];
                    if (getkeys == "__VIEWSTATE") continue;
                    //---------
                    bool ReturnValue = true;
                    string Str = System.Web.HttpContext.Current.Request.Form[getkeys];
                    if (Str.Trim() != "")
                    {
                        string SqlStr = "and|'|<|>|exec|insert|select|delete|update|count|*|chr|mid|master|truncate|char|declare";
                        string[] anySqlStr = SqlStr.Split('|');
                        foreach (string ss in anySqlStr)
                        {
                            if (Str.ToLower().IndexOf(ss) >= 0)
                            {
                                ReturnValue = false;
                                break;
                            }
                        }
                    }
                    //---------
                    if (!ReturnValue)
                    {
                        System.Web.HttpContext.Current.Response.Redirect(sqlErrorPage);
                        System.Web.HttpContext.Current.Response.End();
                    }
                }
            }
        }
        catch
        {
            // 错误处理: 处理用户提交信息! 
        }
    }
   
}

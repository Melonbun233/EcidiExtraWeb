<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        //在应用程序启动时运行的代码
        string str1 = "";
        string path = Server.MapPath("~/count.txt");
        System.IO.StreamReader str = new System.IO.StreamReader(path);
        
        string ss = str.ReadLine();
        int x = Int32.Parse(ss);
        str.Close();

        //在应用程序启动时运行的代码
        Application.Lock();      //临界变量,使用加锁功能,其他用户不能访问。
        Application["UserCount"] = 0;
        Application.UnLock();     //临界变量被解锁。

        Application.Lock();      //临界变量,使用加锁功能,其他用户不能访问。
        Application["StatCount"] = x;
        Application.UnLock();     //临界变量被解锁。
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //在应用程序关闭时运行的代码
        //      string path = Server.MapPath("~/count.txt");
        //    string str=Application["StatCount"].ToString() ;
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        //在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e) 
    {
        //在新会话启动时运行的代码
        Application.Lock();      //临界变量,使用加锁功能,其他用户不能访问。
        Application["UserCount"] = Int32.Parse(Application["UserCount"].ToString()) + 1;
        Application.UnLock();       //临界变量被解锁。

        //测试某一页的访问量※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※
        //      String pageurl = Request.Url.ToString();//获取用户访问的页面

        //     if(pageurl.EndsWith ("index.aspx")) //判断访问的是否是默认页
        //      {
        //锁定变量
        Application.Lock();
        //页面访问量加一
        Application["StatCount"] = Int32.Parse(Application["StatCount"].ToString()) + 1;
        //解锁
        
        
        string path = Server.MapPath("~/count.txt");
        System.IO.StreamWriter sw = new System.IO.StreamWriter(path,false);
        sw.Write(Application["StatCount"]);
        sw.Close();

        Application.UnLock();
        //     }
 
    }

    void Session_End(object sender, EventArgs e) 
    {
        //在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式 
        //设置为 StateServer 或 SQLServer，则不会引发该事件。
        Application.Lock();
        Application["UserCount"] = Int32.Parse(Application["UserCount"].ToString()) - 1;
        Application.UnLock();
    }
       
</script>

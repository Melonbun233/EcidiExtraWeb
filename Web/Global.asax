<%@ Application Language="C#" %>

<script runat="server">

	void Application_Start(object sender, EventArgs e)
	{
		string path = Server.MapPath("~/count.txt");
		System.IO.StreamReader strReader = new System.IO.StreamReader(path);

		string str = strReader.ReadLine();
		int visitedNum = Int32.Parse(str);
		strReader.Close();

		// set current user number
		Application.Lock();
		Application["CurrentUserNum"] = 0;
		Application.UnLock();

		// set visited user number
		Application.Lock();
		Application["VisitorNum"] = visitedNum;
		Application.UnLock();

	}

	void Application_End(object sender, EventArgs e)
	{
		//  在应用程序关闭时运行的代码

	}

	void Application_Error(object sender, EventArgs e)
	{
		// 在出现未处理的错误时运行的代码

	}

	void Session_Start(object sender, EventArgs e)
	{
		// add current user number
		Application.Lock();
		Application["CurrentUserNum"] = Int32.Parse(Application["CurrentUserNum"].ToString()) + 1;
		Application.UnLock();

		// add visitors number
		Application.Lock();
		Application["VisitorNum"] = Int32.Parse(Application["VisitorNum"].ToString()) + 1;

		// write to count.txt
		string path = Server.MapPath("~/count.txt");
		System.IO.StreamWriter strReader = new System.IO.StreamWriter(path, false);
		strReader.Write(Application["VisitorNum"]);
		strReader.Close();

		Application.UnLock();

	}

	void Session_End(object sender, EventArgs e)
	{
		// 在会话结束时运行的代码。 
		// 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
		// InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer
		// 或 SQLServer，则不引发该事件。


	}

</script>

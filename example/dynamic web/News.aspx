<%@ Page Language="C#" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="News" %>

<%@ Register src="top.ascx" tagname="top" tagprefix="uc1" %>

<%@ Register src="footer.ascx" tagname="footer" tagprefix="uc2" %>

<%@ Register src="Left.ascx" tagname="Left" tagprefix="uc3" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title><%=ConfigurationManager.AppSettings["siteInfo"].ToString() %></title>
<link rel="stylesheet" href="css/index.css" />
<script type="text/javascript" src="js/jquery.js"></script>
<!--[if IE 6]>
		<script src="js/pngAlaph.js"></script>
		<script>
			DD_belatedPNG.fix('*');
		</script>
<![endif]-->

</head>
<body>
    <form id="form1" runat="server">
<div id="Container">
    <div id="header">
    	<uc1:top ID="top1" runat="server" />    	                
    </div>
    <div id="content">
    	<div class="sub-left box color">        	
            <uc3:Left ID="Left1" runat="server" />
        </div>
        <div class="sub-right">
        	<div class="listtitle"><h3>院庆动态</h3></div>
                <div class="listcontent sublist">
                    <asp:Label ID="noinfo" runat="server" Visible="false"></asp:Label>
                    <ul>
                        <asp:Repeater ID="DataList1" runat="server">
                            <ItemTemplate>
                                <li><span><%#Eval("recorddate","{0:yyyy/MM/dd}")%></span><a href="detail.aspx?id=<%#Eval("pkid") %>" title="<%#Eval("title").ToString() %>">·<%#Common.Utils.DropHTML(Eval("title").ToString(),Eval("flag").ToString(),90) %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>    
                    </ul>      
                    <div class="pagerbar">
                            <cc1:AspNetPager HorizontalAlign="Right" ID="pager" runat="server" FirstPageText="首页"
                                        LastPageText="尾页" NextPageText=">" OnPageChanging="pager_PageChanging1" PrevPageText="<"
                                        Width="100%" UrlPaging="True" CssClass="anpager" CurrentPageButtonClass="cpb" ShowFirstLast="False" />
                     </div>                
                </div>
        </div>
        <div class="clearfix"></div>
    </div>
    <div id="footer">
    	<uc2:footer ID="footer1" runat="server" />
    </div>
</div>

    </form>

</body>
</html>

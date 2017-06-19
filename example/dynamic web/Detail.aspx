<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Detail.aspx.cs" Inherits="Detail" %>

<%@ Register src="top.ascx" tagname="top" tagprefix="uc1" %>

<%@ Register src="footer.ascx" tagname="footer" tagprefix="uc2" %>

<%@ Register src="Left.ascx" tagname="Left" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title><%=ConfigurationManager.AppSettings["siteInfo"].ToString() %></title>
<link rel="stylesheet" href="css/index.css" />
<script type="text/javascript" src="js/jquery.js"></script>
<script type="text/javascript" src="js/resizeimg.js"></script>
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
        	<div class="listtitle"><span style="float:right;padding:0 10px 0 0;"><a href="javascript:window.history.go(-1);">『返回』</a></span><h3>详细内容</h3></div>
            <div class="detail">           
            	<p align="center" style="font-weight:bold;">
                    <asp:Label runat="server" ID="rtitle" style="font-size:14px;"></asp:Label><br />            
                    <span style="text-align:center;font:12px;color:#999;font-weight:normal;"><asp:Label ID="pTime" runat="server"></asp:Label></span>
                    <hr style="size:1px;color:#999;width:100%;height:1px;border:1px dashed #999;margin-bottom:10px;"/>
                </p>
            	<asp:Label runat="server" ID="rcontent"></asp:Label>
            	<asp:Label runat="server" ID="attach"></asp:Label>
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
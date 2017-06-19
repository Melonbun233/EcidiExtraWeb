<%@ Page Language="C#" AutoEventWireup="true" CodeFile="history.aspx.cs" Inherits="history" %>

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
        	<div class="listtitle"><h3>甲子华东-华东勘测设计研究院志</h3></div>
                <div class="listcontent sublist">                    
                    <ul>
                        <li><span>2014/12/31</span><a href="javascript:openwin('http://public.ecidi.com/catalog/Public_ViewFilesFrame.asp?htmlurl=../PublicArticls/2014/2014-12/210738.html&ID=210738&DisplayName=甲子华东-华东勘测设计研究院志——综合卷&StrFolder=TSDAZX_HDYZ&strCataName=华东院志')" title="">甲子华东-华东勘测设计研究院志（综合卷）</a></li>
                        <li><span>2014/12/31</span><a href="javascript:openwin('http://public.ecidi.com/catalog/Public_ViewFilesFrame.asp?htmlurl=../PublicArticls/2014/2014-12/210740.html&ID=210740&DisplayName=甲子华东-华东勘测设计研究院志——典型工程卷&StrFolder=TSDAZX_HDYZ&strCataName=华东院志')" title="">甲子华东-华东勘测设计研究院志（典型工程卷）</a></li>   
                    </ul>                 
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

<%@ Page Title="" Language="C#" MasterPageFile="SingleContentPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Pages_Default" %>

<asp:Content ID="head" ContentPlaceHolderID="Head" Runat="Server">
	<title>华东咨询外部网站</title>
	<script type="text/javascript" src=<%=ResolveClientUrl("~/assets/js/myfocus-2.0.4.min.js") %>></script>
	<script type="text/javascript" src=<%=ResolveClientUrl("~/assets/js/mf-pattern/mF_kdui.js")%>></script>
	<link rel="stylesheet" type="text/css" href=<%=ResolveClientUrl("~/assets/js/mf-pattern/mF_kdui.css") %>>

	<script type="text/javascript">
		$(document).ready(function () {
			if ($("#boxID").find("li").length > 0) {
				myFocus.set({
					pattern: 'mF_kdui',
					id: 'boxID',
					time: 5,
					trigger: 'click',
					textHeight: 'default',
					width: 1000,
					height: 600
				});
			}
		});
	</script>
</asp:Content>

<asp:Content ID="ContentPlaceHolder" ContentPlaceHolderID="Section" Runat="Server">
	<!-- Content -->
	<div class="grid clearfix" id="content">
		<div id="boxID">
			<div class="pic">
				<ul>
					<%=Photo %>
				</ul>
			</div>
		</div>
	</div>
	<!-- End of Content -->
</asp:Content>


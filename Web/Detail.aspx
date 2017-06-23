<%@ Page Title="" Language="C#" MasterPageFile="~/SingleContentPage.master" AutoEventWireup="true" CodeFile="Detail.aspx.cs" Inherits="Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
	<title><%=articleTitle %></title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Section" Runat="Server">
	<!-- Content -->
	<div class="fluid-container" id="content">
	<div class="grid clearfix">

		<!-- Aside -->
		<div class="col-4" id="aside">
			<%=asideNavHtml %>
		</div>
		<!-- End of Aside	-->

		<div class="col-11" id="detail">
			<div id="detail-head-container">
				<h5 class="back"><a href="javascript:window.history.go(-1);">返回</a></h5>
				<h2>详细内容</h2>
			</div>
			<div id="detail-content-container">
				<h3><%=articleTitle %></h3>
				<h5>发布日期: <%=articleTime %></h5>
				<%=articleContent %>
				<p><%=articleAttach %></p>
				<asp:HiddenField runat="server" ID="articleAttchUrl" />
			</div>
		</div>
	</div>
	</div>
	<!-- End of Content -->

</asp:Content>


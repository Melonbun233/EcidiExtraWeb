<%@ Page Title="" Language="C#" MasterPageFile="~/SingleContentPage.master" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="List" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
	<title><%=title %></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Section" Runat="Server">
	<div class="grid clearfix" id="content">

		<!-- Aside -->
		<div class="col-4" id="aside">
			<%=asideNavHtml %>
		</div>
		<!-- End of Aside	-->
		
		<!-- List	-->
		<div class="col-11" id="list">
			<div id="list-head-container">
				<h2>动态</h2>
			</div>
			<div id="list-content-conatiner">
				<asp:Label ID="noInfo" runat="server" Visible="false"></asp:Label>
				<ul class="list">
					<asp:Repeater ID="DataList" runat="server">
						<ItemTemplate>
							<li>
								<span><h5><%#Eval("add_time", "{0:yyyy/MM/dd}") %></h5></span>
								<a href="detail.aspx?articleId=<%#Eval("id") %>&channelId=<%#Eval("channel_id") %>&articleCateId=<%#Eval("category_id") %>">
									<h3><%#Common.Utils.DropHTML(Eval("title").ToString(), 90) %></h3>
								</a>
							</li>
						</ItemTemplate>
					</asp:Repeater>
				</ul>
				<div class="pagebar">
					<cc1:AspNetPager HorizontalAlign="Center" ID="ListPager" runat="server" FirstPageText="首页" LastPageText="尾页" NextPageText=">" OnPageChanging="ListPager_PageChanging" PrevPageText="<" Width="100%" UrlPaging="True" CssClass="anpager" CurrentPageButtonClass="cpb" ShowFirstLast="False" />
				</div>
			</div>
		</div>
		<!-- End of List	-->
	</div>
</asp:Content>


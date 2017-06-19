<%@ Control Language="C#" AutoEventWireup="true" CodeFile="top.ascx.cs" Inherits="top" %>
<div id="topimg">
        	<div style="background:url(images/banner.jpg) 0 0 no-repeat;height:267px;width:1000px;margin:0 auto;"></div>
        </div>
    	<div id="top">
        	<div class="topnavi">
                <div class="navi">            	               
                    <div class="menu">
                        <ul>
                            <li><a href="default.aspx">院庆首页</a></li>
                            <li><a href="news.aspx">院庆动态</a></li>
                            <li class="pm"><a href="javascript:;">光辉历程</a>
                                <ul class="sub sub1">
                                    <li><a href="content.aspx?cataid=5">综述</a></li>
                                    <li><a href="content.aspx?cataid=6">发展历程</a></li>
                                    <li><a href="content.aspx?cataid=7">体制改革与管理</a></li>
                                    <li><a href="content.aspx?cataid=8">专业发展与技术进步</a></li>
                                    <li><a href="content.aspx?cataid=9">工程业绩</a></li>
                                    <li><a href="content.aspx?cataid=10">党工团建设及企业文化</a></li>
                                </ul>
                            </li>
                            <li class="pm"><a href="javascript:;">今天的华东院</a>
                            	<ul class="sub">
                                    <li><a href="content.aspx?cataid=12">华东院简介</a></li>
                                    <li><a href="content.aspx?cataid=13">组织架构</a></li>
                                    <li><a href="content.aspx?cataid=14">业绩分布</a></li>
                                    <li><a href="content.aspx?cataid=15">战略目标</a></li>
                                </ul>
                            </li>
                            
                            <li class="pm"><a href="javascript:;">企业文化</a>
                            	<ul class="sub sub2">
                                    <li><a href="content.aspx?cataid=17">华东院企业理念</a></li>
                                    <li><a href="content.aspx?cataid=18">员工行为规范</a></li>
                                    <li><a href="javascript:openCatalog('5');">员工行为案例</a></li>
                                    <li><a href="activity.aspx">“文化提升，青年先行”活动</a></li>
                                </ul>
                            </li>
                            <li><a href="ScientificForum.aspx">科技论坛</a></li>
                            <li><a href="myhdy.aspx">人物专访</a></li>
                            <li><a href="javascript:openCatalog('4');">记忆中的老照片</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
<script>
var x1="<%=Common.Utils.GetCookie("60anniversary", "X1") %>";
var x2="<%=Common.Utils.GetCookie("60anniversary", "X2") %>"
function openwin(url){
            var sw=screen.availWidth;
            var w=950;
            var h=700;
            if(sw>1024)
			w = 1200;
			var top=parseInt((screen.availHeight-h)/2);
			var left=parseInt((screen.availWidth-w)/2);
			if(url.indexOf("?")==-1){
			    url=url+"?X1="+x1+"&X2="+x2;
			}
			else
			    url=url+"&X1="+x1+"&X2="+x2;
            
		window.open(url, "" , "width="+w+", height="+h+",top="+top+",left="+left+",toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes");

}

function openCatalog(type){
    var url="";
    switch(type)
    {
        case "1":
        url="project.aspx";
        break;
        case "2":
        url="history.aspx";
        break;
        case "3":
        url="http://web.ecidi.com/websitesubsys/gallery/index.html";
        break;
        case "4"://老照片
        url="http://web.ecidi.com/pictwall/index.html";
        break;
        case "5"://员工行为案例 
        url="http://web.ecidi.com/StaffBehaviorCase/Default.aspx";
        break;
    }
    if(url!="")
    openwin(url);
    else
    alert("栏目正在策划中，敬请期待！");
}
$(document).ready(function(){
    $(".pm").hover(function(){
        $(this).find(".sub").show();
    },function(){
        $(this).find(".sub").hide();
    });	

});
</script>
<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register src="top.ascx" tagname="top" tagprefix="uc1" %>

<%@ Register src="footer.ascx" tagname="footer" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title><%=ConfigurationManager.AppSettings["siteInfo"].ToString() %></title>
<link rel="stylesheet" href="css/index.css" />
<script type="text/javascript" src="js/jquery.js"></script>
<script type="text/javascript" src="js/myfocus-2.0.4.min.js"></script>
<!--[if IE 6]>
		<script src="js/pngAlaph.js"></script>
		<script>
			DD_belatedPNG.fix('*');
		</script>
<![endif]-->
<script type="text/javascript">
myFocus.set({
    id:'boxID',//焦点图盒子ID
    pattern:'mF_kdui',//风格应用的名称
    time:5,//切换时间间隔(秒)
    trigger:'click',//触发切换模式:'click'(点击)/'mouseover'(悬停)
    width:220,//设置图片区域宽度(像素)
    height:200,//设置图片区域高度(像素)
    txtHeight:'default'//文字层高度设置(像素),'default'为默认高度，0为隐藏
});
$(document).ready(function() {
    $(".pm").hover(function() {
        $(this).find(".sub").show();
    }, function() {
        $(this).find(".sub").hide();
    });

//    $("#ac1").hover(function() {
//        $(this).find("img").attr("src", "images/gcpx_s.jpg");
//    }, function() {
//        $(this).find("img").attr("src", "images/gcpx.jpg");
//    });

//    $("#ac2").hover(function() {
//        $(this).find("img").attr("src", "images/rwpx_s.jpg");
//    }, function() {
//        $(this).find("img").attr("src", "images/rwpx.jpg");
//    });

//    $("#ac3").hover(function() {
//        $(this).find("img").attr("src", "images/shz_s.jpg");
//   }, function() {
//        $(this).find("img").attr("src", "images/shz.jpg");
//    });
});
</script>
</head>
<body>
<div id="Container">
    <div id="header">
    	<uc1:top ID="top1" runat="server" />    
        
    </div>
    <div id="content">
    	<div class="left">
        	<div class="box slider">
            	<div id="boxID"><!--焦点图盒子-->
                  <div class="loading"><img src="images/loading.gif" alt="请稍候..." /></div><!--载入画面(可删除)-->
                  <div class="pic"><!--内容列表(li数目可随意增减)-->
                    <ul>
                       <%=photo %>
                    </ul>
                  </div>
                </div>
            </div>
            <div class="quickbtn">
            	<a id="ac1" href="javascript:openCatalog('1');"><img src="images/gcpx.jpg" /></a>
                <a id="ac2" href="javascript:openCatalog('2');"><img src="images/jzhd.jpg" /></a>
            </div>
            <div style="margin-top:15px;">
            	<div class="listtitle3"><h3>企业文化——</h3><span>传承优秀文化&nbsp;&nbsp;汇聚转型力量</span></div>
                <div class="catalog newbox">
                    <ul>
                        <li>                           
                            <a href="content.aspx?cataid=17">华东院企业理念</a>
                        </li> 
                        <li>                           
                            <a href="content.aspx?cataid=18">员工行为规范</a>
                        </li> 
                        <li>                           
                            <a href="javascript:openCatalog('5');">员工行为案例</a>
                        </li> 
                          
                        <li>                           
                            <a href="mms://media.ecidi.com/movie2/ztp/qywh.wmv">企业文化巡回宣讲视频点播</a>
                        </li>  
                        <li>                           
                            <a href="activity.aspx">“文化提升，青年先行”活动</a>
                        </li>          
                    </ul>                
                </div>
            </div>
        </div>
        <div class="center">
        	<div class="list">
                <div class="listtitle"><span><a class="more" href="news.aspx"></a></span><h3>院庆动态</h3></div>
                <div class="listcontent" style="height:195px;">
                    <ul>
                        <%=news %>
                    </ul>                
                </div>
            </div>
            <div style="margin-top:20px;">
            	<img src="images/ghlc.jpg" usemap="#Map" border="0" />
                <map name="Map" id="Map">
                  <area shape="rect" coords="48,46,217,74" href="content.aspx?cataid=5" />
                  <area shape="rect" coords="276,46,443,74" href="content.aspx?cataid=6" />
                  <area shape="rect" coords="49,79,217,105" href="content.aspx?cataid=7" />
                  <area shape="rect" coords="276,78,445,106" href="content.aspx?cataid=8" />
                  <area shape="rect" coords="48,111,217,139" href="content.aspx?cataid=9" />
                  <area shape="rect" coords="276,111,444,138" href="content.aspx?cataid=10" />
                </map>
            </div>
          <div class="list" style="margin-top:20px;">
                <div class="listtitle"><span><a class="more" href="myhdy.aspx"></a></span><h3>人物专访——<font style="font-size:12px;color:#3c3c3c;">感怀流金岁月&nbsp;&nbsp;见证发展足迹</font></h3></div>
                <div class="listcontent">
                    <ul>
                        <%=marqueen%>        
                    </ul>                
                </div>
            </div>
        </div>
        <div class="right">
        	<div>
            	<div class="listtitle2"><h3>今天的华东院——</h3><span>六十载沧桑砥砺&nbsp;&nbsp;新华东再启征程</span></div>
                <div class="catalog newbox">
                    <ul>
                        <li>                           
                            <a href="content.aspx?cataid=12">华东院简介</a>
                        </li> 
                        <li>                           
                            <a href="content.aspx?cataid=13">组织架构</a>
                        </li> 
                        <li>                           
                            <a href="content.aspx?cataid=14">业绩分布</a>
                        </li> 
                        <li>                           
                            <a href="content.aspx?cataid=15">战略目标</a>
                        </li>         
                    </ul>                
                </div>
            </div>
            <div style="margin-top:20px;">
            	<div class="listtitle2"><h3><a href="ScientificForum.aspx">科技论坛</a>——</h3><span>攻坚克难求卓越&nbsp;&nbsp;自主创新立品牌</span></div>
                <div class="listcontent newbox" style="margin-top:0;padding:5px 10px;height:120px;">
                    <ul class="borders">
                        <%=file %>
                    </ul>                
                </div>
            </div>
            
            <div style="margin-top:20px;">
            	<a href="Article.aspx"><div class="listtitle2"><h3>院庆征文——</h3><span>我与华东院</span></div></a>
            </div>
            
            <div class="quickbtn2">
            	<a id="ac3" href="javascript:openCatalog('3');"><img src="images/shz.jpg" /></a>
                <a href="javascript:openCatalog('4');"><img src="images/lzp.jpg" /></a>
            </div>
        </div>
        <div class="clearfix"></div>
        
    </div>
    <div id="footer">
    	<uc2:footer ID="footer1" runat="server" />
    </div>
</div>

</body>
</html>
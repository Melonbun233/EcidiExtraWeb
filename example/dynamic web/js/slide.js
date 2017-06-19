// written by shen_sn 20130620
$.fn.extend({
	render:function(pagecount,t,dur,targ){
		var html="";
		var tpl="<a hidefocus class=\"circle\" href=\"javascript:;\"></a>";	
		for(var i=1;i<=pagecount;i++){
			html+="<a hidefocus rel=\""+i+"\" class=\"circle\" href=\"javascript:;\"></a>";
		}
		var itemwidth=21;
		var perwidth=237;
		var left=Math.ceil((750-itemwidth*(pagecount-1))/2);
		this.css("left",left);
		this.append(html);
		this.find("a[rel=1]").addClass("circlehov");
		var index=this.find(".circlehov").attr("rel");
		this.find("a").bind("click",function(e){
			obj=$(this);
			e.preventDefault();
			var sibling=$(this).siblings();
			sibling.removeClass("circlehov").attr("disabled",true);
			obj.addClass("circlehov");
			var newindex=$(this).attr("rel");
			if(newindex>index){
				targ.find("li").animate({top:"-="+perwidth*(newindex-index)+"px"},dur,function(){
					index=newindex;	
					sibling.attr("disabled",false);
				})
			}
			else if(newindex<index){
				targ.find("li").animate({top:"+="+perwidth*(index-newindex)+"px"},dur,function(){
					index=newindex;	
					sibling.attr("disabled",false);
				})	
			}
		})
	},
	Slide:function(settings){		
		var per=settings.pagecount||4;
		var t=settings.t||3000;
		var dur=settings.dur||500;
		var targ=$("#"+settings.targ);
		var itemlength=targ.find("li").length;
		var obj=this;
		if(itemlength!=0){
			var pagecount=itemlength/per;
			this.render(pagecount,t,dur,targ);	
			//var inter=window.setInterval(function(){obj.start(pagecount,t,dur,targ);},t);
//			targ.hover(function(){
//				window.clearInterval(inter);	
//			},function(){
//				inter=window.setInterval(function(){obj.start(pagecount,t,dur,targ);},t);	
//			})
//			obj.hover(function(){
//				window.clearInterval(inter);	
//			},function(){
//				inter=window.setInterval(function(){obj.start(pagecount,t,dur,targ);},t);	
//			})
		}
	},
	start:function(pagecount,t,dur,targ){	
		var obj=this;
		var index=obj.find(".circlehov").attr("rel");	
		var newindex=obj.find(".circlehov").attr("rel");	
		obj.find("a").removeClass("circlehov");
		if(newindex==pagecount){
			targ.find("li").animate({top:0},dur,function(){
				obj.find("a:eq(0)").addClass("circlehov");
				index=1;	
			})	
		}
		else{				
			targ.find("li").animate({top:"-=237px"},dur,function(){										
				obj.find("a:eq("+(newindex)+")").addClass("circlehov");
				index++;	
			})
		}
				
	}	
})
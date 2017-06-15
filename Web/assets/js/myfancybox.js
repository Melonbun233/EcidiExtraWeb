document.write("<script src='jquery.js'></script>);


function dropDown(contentPlace){
	hover(
		function(){
			$("contentPlace").fadeIn(500);}
		,function(){
			$("contentPlace").fadeOut(100);}
		);
}
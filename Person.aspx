<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Person.aspx.cs" Inherits="Web.Person" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/Person.css" rel="stylesheet" />
    <link href="http://cdn.bootcss.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet"/>
    <title></title>
    <style type="text/css">
		html,body{
			width: 100%;
			height: 100%;
			/*overflow: hidden;*/
		}
		body { background-color:#0F8A5F;}
	</style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="all">
            <div class="head">
                <div class="welcome">
                    欢迎你<br /> 亲爱的会员
                </div>
                <div class="userNav">
                    <ul>
                        <li><a href="PersonUpdate.aspx" target="main">个人信息</a></li>
                        <li><a href="Concern.aspx" target="main">我的关注</a></li>
                        <li><a href="PersonMsg.aspx" target="main">我的消息</a></li>
                    </ul>
                </div>
            </div>
            <div class="main">
               <iframe name="main" id="main" frameborder="0" style="width:800px;height:900px;">

               </iframe>
            </div>
            <div class="foot">
                湖心小筑 个人中心
            </div>    
        </div>
        <script src="js/jquery-1.11.0.min.js" type="text/javascript"></script>
	<script type="text/javascript" src="js/jquery.snow.js"></script>
	<script type="text/javascript">
	    var snowEffectInterval = jQuery.fn.snow({
	        // min size of element (default: 20)
	        minSize: 10,

	        // max size of element (default: 50)
	        maxSize: 50,

	        // flake fall time multiplier (default: 20)
	        fallTimeMultiplier: 20,

	        // flake fall time difference (default: 10000)
	        fallTimeDifference: 10000,

	        // interval (miliseconds) between new element spawns (default: 500)
	        spawnInterval: 500,

	        // jQuery element to apply snow effect on (should work on any block element) (default: body)
	        target: jQuery("body"),

	        //elements to use in generating snow effect
	        elements: [

              // Element #1
              {
                  // html element to be spawned for this element
                  html: '<i class="fa fa-snowflake-o" aria-hidden="true"></i>',
                  // hex color for this element - works only for font based icons
                  color: '#ffffff'
              },

              // Element #2
              {
                  // html element to be spawned for this element
                  html: '<i class="fa fa-bell-o" aria-hidden="true"></i>',
                  // hex color for this element - works only for font based icons
                  color: '#ed9b40'
              },

              // Element #3
              {
                  // html element to be spawned for this element
                  html: '<i class="fa fa-snowflake-o" aria-hidden="true"></i>',
                  // hex color for this element - works only for font based icons
                  color: '#ffffff'
              },

              // Element #4
              {
                  // html element to be spawned for this element
                  html: '<i class="fa fa-music" aria-hidden="true"></i>',
                  // hex color for this element - works only for font based icons
                  color: '#cc2037'
              },

              // Element #5
              {
                  // html element to be spawned for this element
                  html: '<i class="fa fa-snowflake-o" aria-hidden="true"></i>',
                  // hex color for this element - works only for font based icons
                  color: '#ffffff'
              },
	        ]
	    });
	</script>
    </form>
</body>
</html>

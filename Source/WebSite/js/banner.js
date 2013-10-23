 var swf_width='1205'; 
		 var swf_height='229'; 
		 var configtg='0xffffff:文字颜色|2:文字位置|0x000000:文字背景颜色|30:文字背景透明度|0xffffff:按键文字颜色|0x4f6898:按键默认颜色|0x000033:按键当前颜色|8:自动播放时间|3:图片过渡效果|1:是否显示按钮|_blank:打开新窗口'; 
		 var files='images/banner1.jpg|images/banner1.jpg|images/banner1.jpg|images/banner1.jpg'
         var links='#|#|#|#'; 
		 var texts='|||'; 
		 document.write('<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="'+ swf_width +'" height="'+ swf_height +'">'); 
		 document.write('<param name="movie" value="images/slideflash.swf"><param name="quality" value="high">');
		  document.write('<param name="menu" value="false"><param name=wmode value="opaque">'); 
		  document.write('<param name="FlashVars" value="bcastr_file='+files+'&bcastr_link='+links+'&bcastr_title='+texts+'&bcastr_config='+configtg+'">'); 
		  document.write('<embed src="images/slideflash.swf" wmode="opaque" FlashVars="bcastr_file='+files+'&bcastr_link='+links+'&bcastr_title='+texts+'&bcastr_config='+configtg+'& menu="false" quality="high" width="'+ swf_width +'" height="'+ swf_height +'" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />'); 
		  document.write('</object>');  
 var swf_width='1205'; 
		 var swf_height='229'; 
		 var configtg='0xffffff:������ɫ|2:����λ��|0x000000:���ֱ�����ɫ|30:���ֱ���͸����|0xffffff:����������ɫ|0x4f6898:����Ĭ����ɫ|0x000033:������ǰ��ɫ|8:�Զ�����ʱ��|3:ͼƬ����Ч��|1:�Ƿ���ʾ��ť|_blank:���´���'; 
		 var files='images/banner1.jpg|images/banner1.jpg|images/banner1.jpg|images/banner1.jpg'
         var links='#|#|#|#'; 
		 var texts='|||'; 
		 document.write('<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="'+ swf_width +'" height="'+ swf_height +'">'); 
		 document.write('<param name="movie" value="images/slideflash.swf"><param name="quality" value="high">');
		  document.write('<param name="menu" value="false"><param name=wmode value="opaque">'); 
		  document.write('<param name="FlashVars" value="bcastr_file='+files+'&bcastr_link='+links+'&bcastr_title='+texts+'&bcastr_config='+configtg+'">'); 
		  document.write('<embed src="images/slideflash.swf" wmode="opaque" FlashVars="bcastr_file='+files+'&bcastr_link='+links+'&bcastr_title='+texts+'&bcastr_config='+configtg+'& menu="false" quality="high" width="'+ swf_width +'" height="'+ swf_height +'" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />'); 
		  document.write('</object>');  
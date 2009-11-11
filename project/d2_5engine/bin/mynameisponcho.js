var ELFLASH = "mynameisponcho.swf"
var anchura = "1000"
var altura = "650"
var color="#000000"
var nombre = "flash"
var r=""

document.write('<table width="100%" height="100%"><tr><td valign="middle" align="center">')
document.write('<object id="contingut" classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0" width="'+anchura+'" height="'+altura+'" id="" align="middle">')
document.write('<param name="allowScriptAccess" value="sameDomain" />')
document.write('<param name=bgcolor VALUE=' + color + '>')
document.write('<param name="movie" value="'+ELFLASH+'" />')
document.write('<param name="FlashVars" value="'+( ((r=="")?(""):(r)) )+'" />')
document.write('<param name="loop" value="true" />')
document.write('<param name="menu" value="false" />')
document.write('<param name="scale" value="noscale" />')
document.write('<embed id="econtingut" bgcolor="'+color+'" src="'+ELFLASH+'" FlashVars="'+( ((r=="")?(""):(r)) )+'" loop="true" menu="false" quality="high" scale="noscale" width="'+anchura+'" height="'+altura+'" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />')
document.write('</object>')
document.write('</td></tr></table>')


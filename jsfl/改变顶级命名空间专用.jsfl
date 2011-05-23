/**
 * 输入原顶级命名空间，再输入新的命名空间，程序可以替换命名空间
 * @author fanflash.cn
 */
 
var document=fl.getDocumentDOM();
var library=document.library;

var oldTopNS=prompt("请输入现顶级命名空间(如'stage.':");
var newTopNS=prompt("请输入现顶级命名空间(如'swf.'):");

if((oldTopNS!=null) && (newTopNS!=null)){
	trace("开始搜索...")
for(var i in library.items){
	var item=library.items[i];
	
	if(item.linkageClassName!=null){
	    if(item.linkageClassName.substr(0,oldTopNS.length)==oldTopNS){
		    trace(item.name+"元件的类链接‘"+item.linkageClassName+"’被改为"+ newTopNS+item.linkageClassName);
			item.linkageClassName=newTopNS+item.linkageClassName;
	    }
	}
}
trace("替换完毕")
}

//测试输出
function trace(str){
	fl.trace(str);
}
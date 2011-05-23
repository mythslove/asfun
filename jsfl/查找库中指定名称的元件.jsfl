/**
 * 输入链接名，查找元件
 * @author fanflash.cn
 */
 
var document=fl.getDocumentDOM();
var library=document.library;

var idName=prompt("请输入元件名:");

for(var i in library.items){
	var item=library.items[i];
	var tarr=item.name.split("/")
	var tname=tarr[tarr.length-1];
	
	if(tname != null){
		if(tname == idName){
			trace(item.name);
		}
	}
}

//测试输出
function trace(str){
	fl.trace(str);
}
/**
 * 输入链接名，查找元件
 * @author fanflash.cn
 */
 
var document=fl.getDocumentDOM();
var library=document.library;

var idName=prompt("请输入链接名:");

for(var i in library.items){
	var item=library.items[i];
	var idStr=item.linkageIdentifier;
	
	if(idStr != null){
		if(idStr == idName){
			//library.selectItem(item.name);
			trace(item.name);
		}
	}
}

//测试输出
function trace(str){
	fl.trace(str);
}
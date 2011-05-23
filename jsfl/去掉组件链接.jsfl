/**
 * ...
 * @author fanflash.cn
 */

var document=fl.getDocumentDOM();
var library=document.library;

for(var i in library.items){
	var item=library.items[i];
	
	if(item.linkageClassName!=null && item.linkageClassName!=""){
		trace(item.name+".linkageClassName = "+item.linkageClassName+", linkageIdentifier = "+ item.linkageIdentifier +" is delete");
		item.linkageClassName="";
	}
}

//测试输出
function trace(str){
	fl.trace(str);
}
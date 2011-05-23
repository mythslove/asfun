/**
 * 输入新旧类名，库中，只要发现有资源链接中使用旧的类，程序就会把他替换为新的类
 * @author fanflash.cn
 */
 
var document=fl.getDocumentDOM();
var library=document.library;

var oldClasses=prompt("请输入需要被替换的类:");
var newClasses=prompt("请输入要要替换成的类:");

for(var i in library.items){
	var item=library.items[i];
	
	if(item.linkageClassName!=null){
		
		if(item.linkageClassName == oldClasses){
			trace(item.name)
			item.linkageClassName=newClasses;
		}
	}
}

//测试输出
function trace(str){
	fl.trace(str);
}
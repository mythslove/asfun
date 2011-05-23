/**
 * 输入类的名字，查找所绑定的元件
 * @author fanflash.cn
 */
 
var document=fl.getDocumentDOM();
var library=document.library;

var className=prompt("请输入类的名字:");
for(var i in library.items){
	var item=library.items[i];
	
	if(item.linkageClassName!=null){
		
		
	    var classNameArr=item.linkageClassName.split(".")
	    var className2=classNameArr[classNameArr.length-1];
	    if(className2 == className){
	    	trace(item.name);
	    }
	
	}
}

//测试输出
function trace(str){
	fl.trace(str);
}
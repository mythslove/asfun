
/**
 * 生成ClassUtils用的代码。
 * @author fanflash.cn
 */
 
var document=fl.getDocumentDOM();
var library=document.library;
var classList=new Object();

for(var i in library.items){
	var item=library.items[i];
	
	if(item.linkageClassName!=null && item.linkageClassName!=""){
		if(classList[item.linkageClassName]==null)classList[item.linkageClassName]=new Array();
		classList[item.linkageClassName].push(item.linkageIdentifier);
	}
}

var importStr="";
var codeStr="";
for(var i in classList){
	importStr=importStr+"import "+i+";\n";
	
	var t="";
	for(var j in classList[i]){
		t=t+"\"" +classList[i][j]+"\", "
	}
	
	t=t.substr(0,t.length-2);
	
	var tt=i.split(".");
	codeStr=codeStr+"		registerClass("+tt[tt.length-1]+", "+t+");\n";
}

trace("------------导入的类---------------\n")
trace(importStr)
trace("\n\n\n---------------代码---------------\n");
trace(codeStr);

//测试输出
function trace(str){
	fl.trace(str);
}
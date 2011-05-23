/**
 * 制作标准的SKIN文件
 * @author fanflash.cn
 */
 
var document=fl.getDocumentDOM();
var library=document.library;
var selectItem=library.getSelectedItems()[0];
var selectName=selectItem.name;

var isOk=confirm("你想要选择的资源是："+selectName+" ?");

if(!isOk){
	alert("请重新选择，然后执行脚本");
}else{
	
	//先删除舞台中原有的所有对象
	document.selectAll();
	if(document.getSelectionRect()!=0)document.deleteSelection();
	
	//如果没有链接名：
	if(selectItem.linkageIdentifier==null || selectItem.linkageIdentifier==""){
		var t=prompt("请为"+selectItem.name+"输入链接名:",selectItem.name);
		if(t==null){
			selectItem.linkageIdentifier="";
		}else{
			selectItem.linkageIdentifier=t;
		}
	}
	
	//如果没有类名
	if(selectItem.linkageClassName==null || selectItem.linkageClassName==""){
		var t=prompt("请为"+selectItem.name+"(id:"+selectItem.linkageIdentifier+")输入类路径:",selectItem.name);
		if(t==null){
			selectItem.linkageClassName="";
		}else{
			selectItem.linkageClassName=t;
		}
	}
	
	//加入说明文字
    document.addNewText({left:12, top:13.3, right:529.0, bottom:85});
    document.setElementProperty('autoExpand', false);
     var skinName = "";
	 var oldName = selectItem.name;
	 for(var i=0;i<oldName.length;i++){
		 if((oldName.charCodeAt(i)<97) && (i!=0))skinName=skinName+" ";
		 skinName=skinName+oldName.substr(i,1);
	 }
	 
    document.setTextString("Skin name:   "+ skinName + "\nLink name:   " + selectItem.linkageIdentifier + "\nClass name: " + selectItem.linkageClassName + "\n备注：");
	
	//把组件加入到舞台
	document.library.addItemToDocument({x:239, y:208});
    document.align('horizontal center', true);
    document.align('vertical center', true);
	
	
	 //设置库中项目信息
	selectItem.linkageExportForAS=true;
	selectItem.linkageExportForRS=true;
	selectItem.linkageExportInFirstFrame=true;
	var swfName=document.name.split(".")[0]+".swf"
	selectItem.linkageURL="skin/"+swfName;
	selectItem.linkageClassName="";
	
	//将发布的路径复杂到剪贴板
	fl.clipCopyString("../bin/skin/"+swfName);
}


//测试输出
function trace(str){
	fl.trace(str);
}
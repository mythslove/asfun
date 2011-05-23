/**
 * 输入链接名，查找元件,这个功能共有三个文件: 
 * 查找库中元件.jsfl,查找库中元件.xml,findLibraryItem.as
 * 有这三个文件才能正常运行
 * bug报告:fanflash@msn.com
 * @author fanflash.cn
 */
 
 
//清空输出面板
fl.outputPanel.clear();
 

var document=fl.getDocumentDOM();
var library=document.library;


/**
 * 主函数
 */
function main(){
	
	var xmlUIPath=fl.configURI+"Commands/查找库中的元件.xml";

	//检查是否有这个文件夹
	if(!FLfile.exists(xmlUIPath)){
		alert("错误！缺少界面文件(XUL):"+xmlUIPath);
		return;
	}
	
	document.xmlPanel(xmlUIPath)
}

/**
 * 安装
 */
function setup() {
	
}

//测试输出
function trace(str){
	fl.trace(str);
}

main();
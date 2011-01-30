/*=============================================
 * flash工具
 * @author fanflash.cn
 * @date 2011.1.30
 ===============================================*/


/**
 * 将元件的位置设置为整数
 */
function roundXY(){
	var doc = fl.getDocumentDOM();
	roundPropy(doc,"x");
	roundPropy(doc,"y");
}

/**
 * 将元件的大小设置为整数
 */
function roundSize(){
	var doc = fl.getDocumentDOM();
	roundPropy(doc,"width");
	roundPropy(doc,"height");
}

/**
 * 移动到注册点
 */
function moveToZero(){
	var doc = fl.getDocumentDOM();
	doc.setElementProperty("x", 0);
	doc.setElementProperty("y", 0);
}

/**
 * 将元件件的属性四舍五入
 * @param	doc
 * @param	name
 */
function roundPropy(doc,name){
	var t = doc.getElementProperty(name);
	if(t != 0)doc.setElementProperty(name, Math.round(t));
}
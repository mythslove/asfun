/**
 * 输入链接名，查找元件的代码文件
 * bug报告:fanflash@msn.com
 * @author fanflash.cn
 */

/**
 * 主函数
 */
function main() {
}

var document=fl.getDocumentDOM();
var library=document.library;


function findNextBtnHandler(){
	if (!checkValue()) {
		return;
	}
	
	
	var info = findItem(getCurFindType(), getKeyName(), getCurStartIndex(), getMaxIndex());
	
	if (info == null) {
		alert("从索引" + getCurStartIndex() + "到" + getMaxIndex() + "没有找到关键字为" + getKeyName() + "的元件");
		return;
	}
	
	setCurStartIndex(info.index + 1);
	selectItem(info.item.name);
	trace(info.item.name);
	
}

function findPreBtnHandler() {
	if (!checkValue()) {
		return;
	}
	
	var info = findItem(getCurFindType(), getKeyName(), getCurStartIndex(), 0);
	
	if (info == null) {
		alert("从索引" + getCurStartIndex() + "到0没有找到关键字为" + getKeyName() + "的元件");
		return;
	}
	
	setCurStartIndex(info.index - 1);
	selectItem(info.item.name);
	trace(info.item.name);
}

function closeBtnHandler(){
	fl.xmlui.accept()
}

/**
 * 选择项，并展开所有的文件夹
 * @param	path 元件的路径以名字
 */
function selectItem(path) {
	
	if (path == null) return;
	
	var pathArr = path.split("/");
	var len = pathArr.length;
	if (len < 2) return;
	for (var i = 0; i < len - 1; i++) {
		
		var pathStr = "";
		for (var j = 0; j <= i; j++ ) {
			
			if (j == i) {
				pathStr = pathStr + pathArr[j];
			}else {
				pathStr = pathStr + pathArr[j] + "/";
			}
			
		}
		
		fl.getDocumentDOM().library.expandFolder(true, false, pathStr);
	}
	
	
	fl.getDocumentDOM().library.selectItem(path);
}

/**
 * 检查值
 * @return true 表示没有错误，false表示有错误
 */
function checkValue() {
	
	var keyNameStr = getKeyName();
	if (keyNameStr.length < 1) {
		alert("请输入查询关键字");
		return false;
	}
	
	var id = getCurStartIndex();
	if (isNaN(id)) {
		alert("你起始索引值有误，系统自动帮你设置成默认值0");
		id = 0;
		setCurStartIndex(0);
	}else {
		setCurStartIndex(id);
	}
	
	var maxID = getMaxIndex();
	if (id > maxID) {
		alert("我输入的索引值超过库最大索引，系统自动帮你设置成最大值" + maxID);
		setCurStartIndex(maxID);
	}
	
	return true;
}

/**
 * 返回最大的索引值
 */
function getMaxIndex() {
	return fl.getDocumentDOM().library.items.length - 1;
}

/**
 * 得到当前起始ID
 */
function getCurStartIndex() {
	return Number(fl.xmlui.get("startindex"));
}

function setCurStartIndex(id) {
	fl.xmlui.set("startindex", id);
}

/**
 * 得到用户输入的名字
 */
function getKeyName() {
	return fl.xmlui.get("keyname");
}

/**
 * 得到当前的搜索类型
 */
function getCurFindType() {
	return(fl.xmlui.get("findtype"))
}

/**
 * 跟据库里面元件的名字，找元件，如果开始索引比结束索引大的话，那么就是反向搜索
 * @param	n　元件名字
 * @param   start 起始索引，可选参数，默认为０
 * @param   end  结束索引，可选参数，默认为最大值
 * @return  {item:库中的资源项, index:库中资源的索引}
 */
function findItemForName(n, start, end) {
	
	start = Number(start)
	end = Number(end);
	
	var items = fl.getDocumentDOM().library.items;
	
	if (isNaN(start)) start = 0;
	if (isNaN(end)) {
		end = items.length;
	}else if (end > items.length) {
		end = items.length;
	}
	
	var forFun = function(i) {
		var item = items[i];
		var tarr = item.name.split("/");
		var tname = tarr[tarr.length - 1];
		
		if (tname != null) {
			if (tname == n) return { item:item, index:i };
		}
		
		return null;
	}
	
	if (start < end) {
		
		if (end != items.length) end++;
		for (var i = start; i < end; i++ ) {
			var info = forFun(i);
			if (info != null) {
				return info;
			}
		}
	}else {
		
		for (var i = start ; i >= end; i-- ) {
			var info = forFun(i);
			if (info != null) {
				return info;
			}
		}
	}
	
	return null;
}

/**
 * 跟据库里面元件的链接名，找元件，如果开始索引比结束索引大的话，那么就是反向搜索
 * @param	n　链接名
 * @param   start 起始索引，可选参数，默认为０
 * @param   end  结束索引，可选参数，默认为最大值
 * @return  {item:库中的资源项, index:库中资源的索引}
 */
function findItemForLinkName(n, start, end) {
	
	start = Number(start)
	end = Number(end);
	
	var items = fl.getDocumentDOM().library.items;
	
	if (isNaN(start)) start = 0;
	if (isNaN(end)) {
		end = items.length;
	}else if (end > items.length) {
		end = items.length;
	}
	
	var forFun = function(i) {
		var item = items[i];
		var idStr = item.linkageIdentifier;
		
		if (idStr != null) {
			if (idStr == n) return { item:item, index:i };
		}
		
		return null;
	}
	
	if (start < end) {
		
		if (end != items.length) end++;
		for (var i = start; i < end; i++ ) {
			var info = forFun(i);
			if (info != null) {
				return info;
			}
		}
	}else {
		
		for (var i = start ; i >= end; i-- ) {
			var info = forFun(i);
			if (info != null) {
				return info;
			}
		}
	}
	
	return null;
}

/**
 * 跟据库里面元件的类名，找元件，如果开始索引比结束索引大的话，那么就是反向搜索
 * @param	n 类的字符串
 * @param   start 起始索引，可选参数，默认为０
 * @param   end  结束索引，可选参数，默认为最大值
 * @return  {item:库中的资源项, index:库中资源的索引}
 */
function findItemForClassName(n, start, end) {
	
	start = Number(start)
	end = Number(end);
	
	var items = fl.getDocumentDOM().library.items;
	
	if (isNaN(start)) start = 0;
	if (isNaN(end)) {
		end = items.length;
	}else if (end > items.length) {
		end = items.length;
	}
	
	var forFun = function(i) {
		var item = items[i];
		var classStr = item.linkageClassName;
		
		if (classStr != null) {
			if (classStr == n) return { item:item, index:i };
		}
		
		return null;
	}
	
	if (start < end) {
		
		if (end != items.length) end++;
		for (var i = start; i < end; i++ ) {
			var info = forFun(i);
			if (info != null) {
				return info;
			}
		}
	}else {
		
		for (var i = start ; i >= end; i-- ) {
			var info = forFun(i);
			if (info != null) {
				return info;
			}
		}
	}
	
	return null;
	
	
	return findLibrary(n, start, end, forFun);
}

/**
 * 遍历库元件
 * 本来想用这函数的，可是处理函数forFun变成参数形式传进来后，速度会变的很慢，于是，不用了。
 * @param	n 类的字符串
 * @param   start 起始索引，可选参数，默认为０
 * @param   end  结束索引，可选参数，默认为最大值
 * @param   forFun 返回null则继续循环，否则结速查找
 * @return  {item:库中的资源项, index:库中资源的索引}
 */
function findLibrary(n, start, end, forFun) {
	
	if (forFun == null) return;
	
	start = Number(start)
	end = Number(end);
	
	var items = fl.getDocumentDOM().library.items;
	
	if (isNaN(start)) start = 0;
	if (isNaN(end)) {
		end = items.length;
	}else if (end > items.length) {
		end = items.length;
	}
	
	if (start < end) {
		
		if (end != items.length) end++;
		for (var i = start; i < end; i++ ) {
			var info = forFun(i);
			if (info != null) {
				return info;
			}
		}
	}else {
		
		for (var i = start ; i >= end; i-- ) {
			var info = forFun(i);
			if (info != null) {
				return info;
			}
		}
	}
	
	return null;
}

/**
 * 搜索
 * @param	type
 * @param	n
 * @param	start
 * @param	end
 */
function findItem(typeName, n, start, end) {
	
	switch(typeName) {
		
		case "元件名":
		return findItemForName(n, start, end);
		
		case "链接名":
		return findItemForLinkName(n, start, end);
		
		case "类名":
		return findItemForClassName(n, start, end);
	}
}

//测试输出
function trace(str){
	fl.trace(str);
}
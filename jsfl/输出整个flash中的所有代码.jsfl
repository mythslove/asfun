/**
 * 输出整个flash中所有的代码
 * @version 1.0
 * @author fanflash.cn
 */

 //清空输出面板
 fl.outputPanel.clear();
 
 
var document=fl.getDocumentDOM();
var library=document.library;
var codeHashMap=new Object();


/**
 * 输出对象的全部代码
 * @param	item document对像或库中的对象
 */
function outputObjAllCode(item){
	
	//输出代码
	var outCodeStr="";
	
	//时间轴
	var timeline;
	if(item.timeline){
		//库项目
		timeline=item.timeline;
	}else{
		//document
		timeline=item.getTimeline();
	}
	
	//图层数
	var layerCount=timeline.layerCount;
	
	//遍历所有层及帧
	for(var i=0; i<layerCount; i++){
		
		//选择指定的层
		timeline.setSelectedLayers(i);
		
		var frameCount=timeline.getLayerProperty("frameCount");
		var frameName=timeline.getLayerProperty("name");
		
		//输出
		var isHaveCode=false;
		var codeStr="//////////////////////////////////////////////////////////////"+getNewline();
		codeStr+="//第"+i+"层,层名称\""+frameName+"\"的代码"+getNewline();
		codeStr+="//////////////////////////////////////////////////////////////"+getNewline(3);
		
		//遍历帧
		for(var j=0;j<frameCount;j++){
			//timeline.setSelectedFrames(j,j);
			
			var keyFrameID=timeline.getFrameProperty("startFrame",j);
			//如果是关键帧
			if(j==keyFrameID){
				
				var tIsHaveCode=false;
				var tCodeStr="";
				tCodeStr+="/*******************************************************"+getNewline();
				tCodeStr+="  第"+j+"帧的代码"+getNewline();
				tCodeStr+="*******************************************************/"+getNewline(3);
				
				//代码字符串
				var asStr=timeline.getFrameProperty("actionScript",j)
				
				//输出帧上面的附加代码
				if(asStr!=""){
					
					isHaveCode=true;
					tIsHaveCode=true;
					tCodeStr+="//-----------------------------------"+getNewline();
					tCodeStr+="//时间轴代码,字符数:"+asStr.length+getNewline();
					tCodeStr+="//-----------------------------------"+getNewline()
					tCodeStr+=asStr+getNewline(3);
				}
				
				//这个帧中的所有对象
				var elements=timeline.getFrameProperty("elements",j);
				var len=elements.length;
				for(var k=0;k<len;k++){
					
					//参考帮助SymbolInstance对象
					//trace(elements[k].instanceType)
					//trace(elements[k].libraryItem);
					//trace(elements[k].actionScript);
					
					//输出对象上的附加代码
				    var asStr=elements[k].actionScript;
					if(asStr!="" && asStr!=null){
						
						isHaveCode=true;
						tIsHaveCode=true;
						tCodeStr+="//-----------------------------------"+getNewline();
						if(elements[k].name.length>0){
							tCodeStr+="//实例"+elements[k].name;
						}else{
							tCodeStr+="//无名实例";
						}
						
						tCodeStr+="(库元件路径\""+elements[k].libraryItem.name+"\")上的代码,字符数:"+asStr.length+getNewline();
						tCodeStr+="//-----------------------------------"+getNewline();
						tCodeStr+=asStr+getNewline();
					}
				}
				
				if(tIsHaveCode){
					codeStr+=tCodeStr;
				}
			}
		}
		
		if(isHaveCode){
			outCodeStr+=codeStr+getNewline(5);
		}
	}
	
	return outCodeStr;
}

/**
 * 加入库中每个有链接的元件的全部代码
 * @param	lib 库对像
 */
function addLibraryCode(lib){
	
	var len=lib.items.length
	var allowType={"movie clip":true,"button":true};
	for(var i=0;i<len;i++){
		
		var item=lib.items[i];
		if(!allowType[item.symbolType])continue;
		if(!item.linkageIdentifier)continue;
		if(item.linkageIdentifier.length<1)continue;
		
		var codeStr=outputObjAllCode(item);
		if(codeStr.length>0){
			codeStr="//这个元件的库文件名是:"+item.name+getNewline(2)+codeStr;
			codeHashMap[item.linkageIdentifier + "的代码"]=codeStr;
		}
	}
}


/**
 * 写入文件
 */
function writeFile(){
	
	var folderUrl=fl.browseForFolderURL("请选择用于输出FLA代全部代码的目录(提示:如果操作中发现同名文件,则会被覆盖)");
	if(folderUrl==null)return;
	
	for(var i in codeHashMap){
		FLfile.write( folderUrl+"/"+i+".as", codeHashMap[i]);
	}
}

/**
 * 得到新行
 * @param	lib 库对像
 */
function getNewline(t){
	if(t==null)t=1;
	var out="\r\n";
	for(var i=1;i<t;i++){
		out+="\r\n"
	}
	
	return out;
}


/**
 * 主类
 */
function main(){
	codeHashMap["root的代码"]=outputObjAllCode(document);
	addLibraryCode(library);
	writeFile();
}


//测试输出
function trace(str){
	fl.trace(str);
}


main();
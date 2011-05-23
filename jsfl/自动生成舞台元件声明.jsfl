fl.outputPanel.clear()

var doc = fl.getDocumentDOM()
var asVer = doc.asVersion
var timeline = doc.getTimeline()

fl.trace(getCode())

// Element -> Instance -> SymbolInstance -> ComponentInstance
//                     -> CompiledClipInstance
//                     -> BitmapInstance
//		   -> Text
//         -> Shape

function getCode(){
	
	//var el = fl.getDocumentDOM().getTimeline().layers[0].frames[0].elements[0];
	var layerCount = timeline.layerCount;
	var importStr = ""
	var varStr = ""
	var nameList = "[";
	var varList = {};
	
	//导入字符串哈希表
	var importMap = {}
	
	var defCls = {}
	if(asVer >2){
		defCls["btn"] = "flash.display.SimpleButton";
		defCls["mc"] = "flash.display.MovieClip";
		defCls["sp"] =  "flash.display.Sprite";
	}else{
		defCls["btn"] = "MovieClip";
		defCls["mc"] = "MovieClip";
		defCls["sp"] = "MovieClip";
	}
	
	//增加声明
	var addVar = function(nameStr, impStr){
		var types = impStr.split(".")
		var typeStr = types[types.length - 1]
		if(varList[typeStr] == null) varList[typeStr] = "";
		varList[typeStr] += "public var " + nameStr + ":" + typeStr + ";\n"
		
		nameList += "\"" + nameStr + "\", ";
		
		if(types.length <2)return;
		if(importMap[impStr])return
		importMap[impStr] = true
		importStr += "import " + impStr + ";\n";
	}
	
	for(var i = 0;i<layerCount;i++){
		
		var els = timeline.layers[i].frames[timeline.currentFrame].elements
		var len = els.length
		for(var j = 0;j<len;j++){
			
			var element = els[j]
			var eName = element.name
			
			//fl.trace("target:" + element + ", name:" + element.name + ", type:" + element.elementType);
			
			if(eName.length > 0){
				switch(element.elementType){
					case "text":
						addVar(eName,"flash.text.TextField");
					break
					case "instance":
						var item = element.libraryItem
						
						//是否大于一帧
						var mcStr = "sp";
						if(item.timeline!=null && item.timeline.frameCount>1)mcStr = "mc"
						
						if(item.linkageClassName == null || item.linkageClassName == "" ){
							if(item.itemType == "button"){
								addVar(eName,defCls["btn"]);
							}else{
								addVar(eName,defCls[mcStr]);
							}
						}else{
							addVar(eName,item.linkageClassName)
						}
						
					break
				}
			}
		}
	}
	
	//组合字符串
	importStr += "\n"
	for(var i in varList){
		importStr += varList[i] + "\n";
	}
	
	return importStr + "\n" + nameList.slice(0,nameList.length-2) + "]";
}
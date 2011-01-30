import mx.controls.Button;
/**
 * ...
 * @author fanflash.cn
 */
class Main extends MovieClip
{
	private static var SCRIPT_PATH:String = "FFlashTool/jsfl/FFlashTool.jsfl";
	
	private var setXYBtn:Button;
	private var setSizeBtn:Button;
	private var resetXYBtn:Button;
	private var urlBtn:MovieClip;
	
	public function Main() 
	{
		Stage.scaleMode = "noScale";
		Stage.align = "TL";
		Stage.addListener(this);
		this.onRelease();
	}
	
	private function onLoad() {
		
		var local:Main = this;
		this.setXYBtn.onPress = function() {
			local.runFunction("roundXY");
		}
		
		this.setSizeBtn.onPress = function() {
			local.runFunction("roundSize");
		}
		
		this.resetXYBtn.onPress = function() {
			local.runFunction("moveToZero");
		}
		
		this.urlBtn.onPress = function() {
			_root.getURL("http://www.fanflash.cn");
		}
	}
	
	private function runFunction():String {
		var params:Array = arguments;
		var functionName:String = params.shift().toString();		
		
		var args:Array = [];
		var l:Number = params.length;
		for (var i:Number=0; i<l; i++) {
			if (params[i] == undefined) { params[i] = ""; }
			args.push("'" + params[i].split("'").join("\'") + "'");
		}
		var scriptPath:String;
		if (params.length == 0) {
			scriptPath = "fl.runScript(fl.configURI + '"+SCRIPT_PATH+"', '"+functionName+"');";
		} else {
			scriptPath = "fl.runScript(fl.configURI + '"+SCRIPT_PATH+"', '"+functionName+"', "+args.join(",")+");";
		}
		return MMExecute(scriptPath);		
	}
	
	private function onResize() {
		this.urlBtn._x = Stage.width - this.urlBtn._width -20;
		this.urlBtn._y = Stage.height - this.urlBtn._height - 5;
	}
}
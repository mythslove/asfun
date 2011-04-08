import mx.controls.Button;
import mx.controls.CheckBox;
import mx.controls.TextInput;
/**
 * ...
 * @author fanflash.cn
 */
class Main 
{
	
	private var prjNameTI:TextInput;
	private var autoSetCB:CheckBox;
	private var dirNameTI:TextInput;
	private var projPathTI:TextInput;
	private var selBtn:Button;
	private var createDirCB:CheckBox;
	private var createBtn:Button;
	private var infoTxt:TextField;
	
	public function Main() 
	{
		Stage.addListener(this);
		Stage.align = "TL";
		Stage.scaleMode = "noScale";
		
		this.infoTxt.autoSize = true;
		this.infoTxt.wordWrap = true;
		this.infoTxt.multiline = true;
		this.infoTxt.text = "";
	}
	
	private function onLoad() {
		
		this.dirNameTI.enabled = false;
		this.prjNameTI.addEventListener("change", this.prjNameHandler);
		this.autoSetCB.addEventListener("change", this.autoSetHandler);
		this.onResize();
	}
	
	private function prjNameHandler() {
		
		if (autoSetCB.selected) {
			
			this.dirNameTI.text = this.prjNameTI.text;
		}
	}
	
	private function autoSetHandler() {
		
	}
	
	private function createBtnHandler() {
		
	}
	
	private function onResize() {
		
		var sw:Number = Stage.width;
		if (sw < 320) sw = 320;
		

		this.prjNameTI.setSize(sw - 93 - 87, 22, true);
		this.dirNameTI.setSize (this.prjNameTI.width, 22, true);
		this.projPathTI.setSize (this.prjNameTI.width, 22, true);
		
		this.autoSetCB._x = this.selBtn._x = this.createBtn._x = this.prjNameTI._x + this.prjNameTI.width + 5;
		this.createDirCB._x = this.autoSetCB._x - 5 - 98;
		
		this.infoTxt._width = sw - 20;
	}
	
}
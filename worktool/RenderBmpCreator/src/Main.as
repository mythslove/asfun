package 
{
	import fl.controls.Button;
	import fl.controls.CheckBox;
	import fl.controls.ColorPicker;
	import fl.controls.NumericStepper;
	import fl.controls.RadioButton;
	import fl.controls.RadioButtonGroup;
	import fl.controls.TextInput;
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.MovieClip;
	import flash.display.Sprite;
	import flash.events.Event;
	import flash.events.MouseEvent;
	import flash.filesystem.File;
	import flash.filesystem.FileMode;
	import flash.filesystem.FileStream;
	import flash.filters.GlowFilter;
	import flash.geom.Matrix;
	import flash.text.TextField;
	import flash.text.TextFieldAutoSize;
	import flash.text.TextFormat;
	import flash.utils.ByteArray;
	import flash.utils.Timer;
	
	/**
	 * 生成占位图的程序
	 * @author fanflash.cn
	 */
	public class Main extends Sprite 
	{
		
		private var file:File;
		private var bgColor:uint;
		private var defaultPath:String;
		
		/*
		private var widthNS:NumericStepper;
		private var heightNS:NumericStepper;
		private var quickbtn1:Button;
		private var quickbtn2:Button;
		private var quickbtn3:Button;
		private var customColorRB:RadioButton;
		private var colorPicker:ColorPicker;
		private var alphaColorRB:RadioButton;
		private var blackColorRB:RadioButton;
		private var whiteColorRB:RadioButton;
		private var radomColorRB:RadioButton;
		private var mixColorRB:RadioButton;
		private var showTxtCB:CheckBox;
		private var nameTxt:TextInput;
		private var sizeCB:CheckBox;
		private var saveFolderTxt:TextInput;
		private var chosenBtn:Button;
		private var createBtn:Button;
		*/
		
		//画文字时用的
		private var drawTxt:TextField;
		
		public function Main():void 
		{
			this.init();
		}
		
		
		
		private function init() {
			this.file = File.desktopDirectory.clone();
			this.file.nativePath = this.file.nativePath + File.separator + "占位图" + Math.floor(Math.random() * 100).toString() + ".png";
			this.defaultPath = this.file.nativePath;
			this.saveFolderTxt.text = this.file.nativePath;
			
			this.drawTxt = new TextField();
			this.drawTxt.defaultTextFormat = new TextFormat(null, 12);
			this.drawTxt.filters = [new GlowFilter(0xffffff, 1, 2, 2, 255)];
			this.drawTxt.selectable = false;
			this.drawTxt.mouseEnabled = false;
			this.drawTxt.autoSize = TextFieldAutoSize.LEFT;
			//this.drawTxt.multiline = true;
			//this.drawTxt.wordWrap = true;
			
			//一些事件的监听
			this.quickbtn1.addEventListener(MouseEvent.CLICK, this.btnClickHandler);
			this.quickbtn2.addEventListener(MouseEvent.CLICK, this.btnClickHandler);
			this.quickbtn3.addEventListener(MouseEvent.CLICK, this.btnClickHandler);
			
			var rbGroup:RadioButtonGroup = new RadioButtonGroup("RadioButtonGroup");
			rbGroup.addEventListener(Event.CHANGE, this.rbHandler);
			
			this.colorPicker.addEventListener(Event.CHANGE, this.colorHandler);
			this.chosenBtn.addEventListener(MouseEvent.CLICK, this.btnClickHandler);
			this.createBtn.addEventListener(MouseEvent.CLICK, this.btnClickHandler);
			
			this.file.addEventListener(Event.SELECT, this.checkFileName);
		}
		
		private function colorHandler(e:Event) {
			this.bgColor = this.colorPicker.selectedColor;
		}
		
		private function rbHandler(e:Event) {
			
			this.colorPicker.enabled = e.target.selection == this.customColorRB;
			
			switch(e.target.selection) {
				
				case this.alphaColorRB:
				this.bgColor = 0xffffff + 1;
				break;
				
				case this.blackColorRB:
				this.bgColor = 0;
				break;
				
				case this.whiteColorRB:
				this.bgColor = 0xffffff;
				break;
				
				case this.radomColorRB:
				this.bgColor = 0xffffff + 2;
				break;
				
				case this.mixColorRB:
				this.bgColor = 0xffffff + 3;
				break;
				
			}
			
		}
		
		private function btnClickHandler(e:Event) {
			
			switch(e.target) {
				
				case this.quickbtn1:
				this.setImageSize(32, 32);
				break;
				
				case this.quickbtn2:
				this.setImageSize(40, 40);
				break;
				
				case this.quickbtn3:
				this.setImageSize(64, 64);
				break;
				
				case this.chosenBtn:
				this.file.browseForSave("保存文件");
				break;
				
				case this.createBtn:
				this.crate()
				break;
				
			}
		}
		
		private function setImageSize(w:int = 1, h:int = 1) {
			this.widthNS.value = w;
			this.heightNS.value = h;
		}
		
		private function crate() {
			
			var url:String = this.saveFolderTxt.text;
			
			if (url == "") {
				this.showMsg("你还没有输入需要保存的文件路径,程序已经把文件名设置为默认文件名，请检查");
				this.setDefaultPath();
				return;
			}
			
			try {
				this.file.nativePath = url;
			}catch (e:Error) {
				this.setDefaultPath();
				this.showMsg("你输入的文件路径格式有错误，程序已经把文件名设置为默认文件名，请检查");
				return;
			}
			
			
			if (this.file.name == null) {
				this.setDefaultPath();
				this.showMsg("你还没有输入文件名，程序已经把文件名设置为默认文件名，请检查");
				return;
			}
			
			if (!this.checkFileName()) {
				this.showMsg("你输入的文件路径有些许错误，程序已经修正，你可以检查路径后，再点生成按钮生成图片");
				return;
			}
			
			
			
			
			
			var bmp:BitmapData = new BitmapData(this.widthNS.value, this.heightNS.value, true, 0);
			
			switch(this.bgColor) {
				case (0xffffff + 1):
				//透明
				break;
				case (0xffffff + 2):
				//随机
				bmp.fillRect(bmp.rect, Math.floor(Math.random() * 0xffffff));
				break;
				case (0xffffff +3):
				//杂色
				bmp.perlinNoise(bmp.width, bmp.height, 6, Math.floor(Math.random() * 10), false, false);
				break;
				
				default:
				bmp.fillRect(bmp.rect, this.bgColor);
			}
			
			//文字
			this.drawTxt.text = this.nameTxt.text;
			bmp.draw(this.drawTxt);
			this.drawTxt.text = bmp.width + " x " + bmp.height;
			var mart:Matrix = new Matrix();
			mart.tx = 0
			mart.ty = this.drawTxt.height;
			bmp.draw(drawTxt, mart);
			
			/*
			var mybmp:Bitmap = this.getChildByName("mybmp") as Bitmap;
			if (mybmp == null) {
				mybmp = new Bitmap();
				mybmp.name="bmp"
			}
			
			mybmp.bitmapData = bmp;
			this.addChild(mybmp);
			*/
			
			var pngByte:ByteArray = PNGEncoder.encode(bmp);
			var fs:FileStream = new FileStream();
			fs.open(this.file, FileMode.WRITE);
			fs.writeBytes(pngByte);
			fs.close();
			
			this.showMsg("占位图已经保存在: " + this.file.nativePath);
		}
		
		private function showMsg(msg:String) {
			
			var msgBG:Sprite = this.getChildByName("msgBG") as Sprite;
			if (msgBG == null) {
				msgBG = new Sprite();
				msgBG.name = "msgBG";
				msgBG.graphics.beginFill(0, 0.5);
				msgBG.graphics.drawRect(0, 0, 526, 400);
				msgBG.addEventListener(MouseEvent.MOUSE_DOWN, this.hideMsg);
			}
			
			var msgTxt:TextField = this.getChildByName("msgTxt") as TextField
			if (msgTxt == null) {
				msgTxt = new TextField();
				msgTxt.name = "msgTxt";
				msgTxt.width = 300;
				msgTxt.autoSize = TextFieldAutoSize.CENTER;
				msgTxt.wordWrap = true;
				msgTxt.multiline = true;
				msgTxt.x = 113;
				msgTxt.filters = [new GlowFilter(0xffffff, 1, 2, 2, 255)];
				msgTxt.mouseEnabled = false;
				msgTxt.tabEnabled = false;
				msgTxt.selectable = false;
				
				var tf:TextFormat = new TextFormat(null, 14);
				tf.align = TextFieldAutoSize.CENTER;
				msgTxt.defaultTextFormat = tf;
			}
			
			msgTxt.text = msg + "\n(点击屏幕关闭提示！)";
			msgTxt.y = (400 - msgTxt.height) * 0.4;
			this.addChild(msgBG);
			this.addChild(msgTxt);
		}
		
		
		private function hideMsg(e:Event=null) {
			var msgBG:Sprite = this.getChildByName("msgBG") as Sprite;
			if (msgBG != null) {
				msgBG.graphics.clear();
				this.removeChild(msgBG);
			}
			
			var msgTxt:TextField = this.getChildByName("msgTxt") as TextField
			if (msgTxt != null) {
				this.removeChild(msgTxt);
			}
		}
		
		/**
		 * 检查文件名是否正确
		 * @param	e
		 * @return
		 */
		private function checkFileName(e:Event = null):Boolean {
			
			var isTrue:Boolean = true;
			if (this.file.extension != "png") {
				this.file.nativePath = this.file.nativePath + ".png";
				isTrue = false;
			}
			
			this.saveFolderTxt.text = this.file.nativePath;
			
			return isTrue;
		}
		
		private function setDefaultPath() {
			this.file.nativePath = this.defaultPath;
			this.saveFolderTxt.text = this.file.nativePath;
		}
	}
}
package org.asfun.richTextEditor.insertItem {
	import flash.events.Event;
	import flash.events.TextEvent;
	import flash.text.TextField;
	import flash.text.TextFieldAutoSize;
	import flash.text.TextFieldType;
	import flash.utils.Dictionary;
	
	/**
	 * 插入的文字项
	 * @author www.fanflash.cn
	 */
	public class TextItem extends InsertItemBase{
		
		private var txt:TextField;
		public function TextItem(isAuto:Boolean = true, initStr:String = "") {
			
			this.txt = new TextField();
			this.txt.type = TextFieldType.INPUT;
			this.txt.multiline = true;
			this.txt.wordWrap = true;
			this.txt.autoSize = TextFieldAutoSize.LEFT;
			this.txt.text = initStr;
			this.txt.backgroundColor = 0xeeeeee;
			this.txt.background = true;
			this.addChild(this.txt);
			
			//this.txt.addEventListener(Event.CHANGE, this.txtChangeHandler);
			this.txt.addEventListener(TextEvent.TEXT_INPUT, this.txtInputHandler);
			
			this.addCharInsertFlag("//插入图片//");
			this.addCharInsertFlag("//上传图片//");
			this.addCharInsertFlag("//选择图片//");
		}
		
		override public function draw():void {
			this.txt.width = this._width;
			this.txt.height = this._heigth;
		}
		
		//private function txtChangeHandler(e:Event) {}
		
		/**
		 * 用户输入文字
		 * @param	e
		 */
		private function txtInputHandler(e:TextEvent) {
			
			for (var flagStr:String in this.flagHashMap) {
				trace(e.text);
			}
		}
		
		/**
		 * 输入指定文字后,引发事件
		 * @param	flagStr
		 * @param	func
		 */
		private var flagHashMap:Dictionary;
		public function addCharInsertFlag(flagStr:String,func:Function = null) {
			if (this.flagList == null) this.flagHashMap = new Dictionary();
			this.flagHashMap[flagStr] = { handler:func, inputArr:new Array() }
		}
	}
}
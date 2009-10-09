package org.asfun.richTextEditor.insertItem {
	import flash.events.Event;
	import flash.events.TextEvent;
	import flash.text.TextField;
	import flash.text.TextFieldAutoSize;
	import flash.text.TextFieldType;
	
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
			
			this.txt.addEventListener(Event.CHANGE, this.txtChangeHandler);
			this.txt.addEventListener(TextEvent.TEXT_INPUT, this.txtInputHandler);
			
			this.addCharInsertFlag("//插入图片//");
			this.addCharInsertFlag("//上传图片//");
			this.addCharInsertFlag("//选择图片//");
		}
		
		override public function draw():void {
			this.txt.width = this._width;
			this.txt.height = this._heigth;
		}
		
		private function txtChangeHandler(e:Event) {
		}
		
		private function txtInputHandler(e:TextEvent) {
			
		}
		
		/**
		 * 
		 */
		public function addCharInsertFlag(flagStr:String) {
			
		}
	}
}
package org.asfun.richTextEditor.insertItem {
	import flash.text.TextField;
	import flash.text.TextFieldType;
	
	/**
	 * 插入的文字项
	 * @author www.fanflash.cn
	 */
	public class TextItem extends InsertItemBase{
		
		private var txt:TextField;
		public function TextItem() {
			
			this.txt = new TextField();
			this.txt.type = TextFieldType.INPUT;
		}
		
		override public function draw():void {
			this.txt.width = this._width;
			this.txt.height = this._heigth;
		}
		
	}
}
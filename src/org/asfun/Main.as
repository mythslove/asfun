package org.asfun {
	import flash.display.Sprite;
	import flash.events.Event;
	import org.asfun.richTextEditor.RichTextEditor;
	
	/**
	 * ...
	 * @author www.fanflash.cn
	 */
	public class Main extends Sprite {
		
		public function Main():void {
			if (stage) init();
			else addEventListener(Event.ADDED_TO_STAGE, init);
		}
		
		private function init(e:Event = null):void {
			removeEventListener(Event.ADDED_TO_STAGE, init);
			// entry point
			
			this.testRichTextEditor();
		}
		
		/**
		 * 测试富文本编辑框
		 */
		public function testRichTextEditor() {
			
			var t:RichTextEditor = new RichTextEditor();
			this.addChild(t);
			
			t.width = 400;
			t.height = 600;
		}
		
	}
	
}
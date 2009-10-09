package org.asfun.demo {
	import flash.display.Sprite;
	import flash.events.Event;
	import org.asfun.richTextEditor.RichTextEditor;
	
	/**
	 * ...
	 * @author www.fanflash.cn
	 */
	public class RichTextEditorDemo extends Sprite{
		
		public function RichTextEditorDemo() {
			if (stage) init();
			else addEventListener(Event.ADDED_TO_STAGE, init);
		}
		
		private  function init(e:Event = null) {
			removeEventListener(Event.ADDED_TO_STAGE, init);
			
			var t:RichTextEditor = new RichTextEditor();
			t.width = 400;
			t.height = 300;
			t.isEditor = true;
			
			this.addChild(t);
		}
	}
}
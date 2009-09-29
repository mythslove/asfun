package org.asfun.richTextEditor {
	import flash.display.Shape;
	import flash.display.Sprite;
	import org.asfun.core.UIComponent;
	import org.fanflash.utils.DrawUtil;
	
	/**
	 * 富文本编辑器
	 * @author www.fanflash.cn
	 */
	public class RichTextEditor extends UIComponent {
		
		private var bg:Shape;
		
		public function RichTextEditor() {
			
			this.init();
		}
		
		private function init() {
			this.bg = Shape(DrawUtil.drawRect("Shape"));
		}
		
		/**
		 * 绘画界面
		 */
		override public function draw():void {
			
			this.bg.width
		}
	}
}
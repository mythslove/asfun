package org.asfun.richTextEditor {
	import flash.display.Shape;
	import flash.display.Sprite;
	import org.fanflash.utils.DrawUtil;
	
	/**
	 * 富文本编辑器
	 * @author www.fanflash.cn
	 */
	public class RichTextEditor extends Sprite {
		
		private var bg:Shape;
		
		public function RichTextEditor() {
			
			this.init();
		}
		
		private function init() {
			this.bg = Shape(DrawUtil.drawRect("Shape"));
		}
		
		/**
		 * 设置蔌获取组件的宽
		 */
		private var _width:Number;
		override public function get width():Number { return this._width; }
		override public function set width(dt:Number):void {
			this._width = dt;
		}
		
		/**
		 * 设置或获取组件高
		 */
		private var _height:Number;
		override  public function get height():Number { return this._height; }
		override public function set height(dt:Number):void {
			this._height = dt;
		}
		
		/**
		 * 组件渲染器
		 */
		private function render() {
			
		}
	}
}
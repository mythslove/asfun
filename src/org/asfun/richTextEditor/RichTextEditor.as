package org.asfun.richTextEditor {
	import flash.display.Shape;
	import flash.display.Sprite;
	import flash.geom.ColorTransform;
	import org.asfun.core.UIComponent;
	import org.asfun.richTextEditor.insertItem.InsertItemBase;
	import org.fanflash.utils.DrawUtil;
	
	/**
	 * 富文本编辑器
	 * @author www.fanflash.cn
	 */
	public class RichTextEditor extends UIComponent {
		
		private var dataList:Array;
		//内容的容器
		private var itemContent:Sprite;
		private var currentFocusItem:InsertItemBase;
		
		public function RichTextEditor() {
			
			this.dataList = new Array();
			this.itemContent = new Sprite();
			this.addChild(this.itemContent);
		}
		
		/**
		 * 初始化时，配置界面
		 */
		override public function configUI():void { }
		
		/**
		 * 增加项目
		 */
		public function addItem(dt:InsertItemBase) {
			this.dataList.push(dt);
			this.itemContent.addChild(dt);
		}
		
		/**
		 * 背景的颜色
		 */
		private var _bgColor:uint;
		public function get bgColor():uint { return this._bgColor; }
		public function set bgColor(dt:uint) { 
			if (dt == this._bgColor) return;
			this._bgColor = dt;
			if (this.getChildByName("colorBG")) {
				var t:ColorTransform = new ColorTransform();
				t.color = dt;
				this.getChildByName("colorBG").transform.colorTransform = t;
			}
		}
		
		/**
		 * 设置是否显示背景
		 */
		public function get isShowBG():Boolean { return this.getChildByName("colorBG") != null; }
		public function set isShowBG(dt:Boolean) {
			if (this.isShowBG == dt) return;
			if (dt) {
				if (this.getChildByName("colorBG") == null) {
					var t:Shape = DrawUtil.drawRect("Shape", this._bgColor);
					t.name = "colorBG";
					this.addChild(t);
					this.invalidata();
				}
			}else {
				if (this.getChildByName("colorBG") != null) this.removeChild(this.getChildByName("colorBG"));
			}
		}
		
		/**
		 * 绘画界面
		 */
		override public function draw():void {
			
			if (this.isShowBG) {
				this.getChildByName("colorBG").width = this.width;
				this.getChildByName("colorBG").height = this.height;
			}
		}
	}
}
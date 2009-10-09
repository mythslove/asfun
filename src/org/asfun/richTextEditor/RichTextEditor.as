package org.asfun.richTextEditor {
	import flash.display.Shape;
	import flash.display.Sprite;
	import flash.geom.ColorTransform;
	import org.asfun.core.UIComponent;
	import org.asfun.richTextEditor.insertItem.InsertItemBase;
	import org.asfun.richTextEditor.insertItem.TextItem;
	//import org.fanflash.utils.DrawUtil;
	
	/**
	 * 富文本编辑器
	 * @author www.fanflash.cn
	 */
	public class RichTextEditor extends UIComponent {
		
		private var dataList:Array;
		//是不是第一次渲染
		private var isFristRender:Boolean = true;
		
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
					//var t:Shape = DrawUtil.drawRect("Shape", this._bgColor);
					var t:Shape = new Shape();
					t.graphics.beginFill(this._bgColor);
					t.graphics.drawRect(0, 0, 100, 100);
					t.name = "colorBG";
					this.addChild(t);
					this.invalidata();
				}
			}else {
				if (this.getChildByName("colorBG") != null) this.removeChild(this.getChildByName("colorBG"));
			}
		}
		
		/**
		 * 是否为编辑模式
		 */
		private var _isEditor:Boolean = false;
		public function get isEditor():Boolean { return this._isEditor; }
		public function set isEditor(dt:Boolean){
			this._isEditor = dt;
			this.invalidata();
		}
		
		/**
		 * 是否使用字符串快捷插入内容形式
		 */
		private var _isUseCharInsert:Boolean = true;
		public function get isUseCharInsert():Boolean { return this._isUseCharInsert; }
		public function set isUseCharInsert(dt:Boolean) {
			this._isUseCharInsert = dt;
		}
		
		public function addCharInsertFlag() {
			//;///image:
		}
		
		
		/**
		 * 绘画界面
		 */
		override public function draw():void {
			
			if (this.isShowBG) {
				this.getChildByName("colorBG").width = this.width;
				this.getChildByName("colorBG").height = this.height;
			}
			
			//如果是编辑模式,并且是第一次渲染,并且用户没有设置数据的话
			if (this._isEditor && this.isFristRender && (this.dataList.length == 0)) {
				trace("我加入了初始数据");
				this.isFristRender = false;
				this.addItem(new TextItem());
			}
			
			this.updateItemSize();
			
		}
		
		/**
		 * 更新插入项的大小
		 */
		private function updateItemSize() {
			
			var len:int = this.itemContent.numChildren;
			for (var i:int; i < len; i++ ) {
				this.itemContent.getChildAt(i).width = this._width;
			}
		}
	}
}
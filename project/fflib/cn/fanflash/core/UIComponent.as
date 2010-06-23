package cn.fanflash.core 
{
	import flash.display.Sprite;
	import flash.events.Event;
	import flash.utils.Dictionary;
	/**
	 * UI组件的基类
	 * @author fanflash
	 */
	public class UIComponent extends Sprite
	{
		//是否停止滞后函数执行
		public static var inCallLaterPhase:Boolean=false;
		
		
		
		
		
		///////////////////////////////////////////////////////////////////
		//                  Protected property
		///////////////////////////////////////////////////////////////////
		
		//渲染属性哈希列表
		protected var invalidHash:Object;
		//滞后执行函数哈希表
		protected var callLaterMethods:Dictionary;
		
		
		
		
		///////////////////////////////////////////////////////////////////
		//                   Private property
		///////////////////////////////////////////////////////////////////
		
		//是否初始化完成
		private var initialized:Boolean = false;
		
		private var _width:Number = Number.NaN;
		private var _height:Number = Number.NaN;
		
		public function UIComponent() 
		{
			this.addEventListener(Event.ADDED_TO_STAGE, this.init);
		}
		
		final function init(e:Event):void {
			
			if (this._width == Number.NaN) { this._width = this.width; }
			if (this._height == Number.NaN) { this._height = this.height; }
			
			this.initialized = true;
			this.configUI();	
		}
		
		
		/**
		 * 使数据无效，并在下一帧重画他
		 * @param	property
		 * @param	callLater
		 */
		public function invalidate(property:String=InvalidationType.ALL,callLater:Boolean=true):void {
			this.invalidHash[property] = true;
			if (callLater) { this.callLater(draw); }
		}
		
		
		
		
		
		///////////////////////////////////////////////////////////////////
		//                 Protected methods
		///////////////////////////////////////////////////////////////////
		
		/**
		 * 标记数据生效了
		 */
		protected function validate():void {
			invalidHash = {};
		}
		
		/**
		 * 用于子类覆盖实现
		 */
		protected function draw():void {
			//每次重画完，重完列表必然清空,所以每一次执行完draw方法，记得在最后调用一次this.validate();
			validate();
		}
		
		/**
		 * 滞后执行函数
		 * @param	fn
		 */
		protected function callLater(fn:Function):void {
			if (inCallLaterPhase) { return; }
			
			//加入执行列表
			this.callLaterMethods[fn] = true;
			if (this.stage != null) {
				this.stage.addEventListener(Event.RENDER, this.callLaterDispatcher, false, 0, true);
				this.stage.invalidate();				
			} else {
				this.addEventListener(Event.ADDED_TO_STAGE, this.callLaterDispatcher, false, 0, true);
			}
		}
		
		/**
		 * 测试属性是否需要重画
		 * @param	property 属性值
		 * @param	...properties 属性值列表
		 * @return
		 */
		protected function isInvalid(property:String, ...properties:Array):Boolean {
			if (invalidHash[property] || invalidHash[InvalidationType.ALL]) { return true; }
			while (properties.length > 0) {
				if (invalidHash[properties.pop()]) { return true; }
			}
			return false
		}
		
		
		///////////////////////////////////////////////////////////////////
		//                  private methods
		///////////////////////////////////////////////////////////////////
		
		
		private function callLaterDispatcher(event:Event):void {
			if (event.type == Event.ADDED_TO_STAGE) {
				this.removeEventListener(Event.ADDED_TO_STAGE, this.callLaterDispatcher);
				
				//监听render事件是为了执行stage.invalidata画面重新被渲染时会调用我们监听的函数
				this.stage.addEventListener(Event.RENDER, this.callLaterDispatcher, false, 0, true);
				this.stage.invalidate();
				
				return;
			} else {
				event.target.removeEventListener(Event.RENDER, this.callLaterDispatcher);
				if (stage == null) {
					//有可能接收到reder事件，但stage还没有初始化
					this.addEventListener(Event.ADDED_TO_STAGE, this.callLaterDispatcher, false, 0, true);
					return;
				}
			}
			
			inCallLaterPhase = true;
			
			var methods:Dictionary = this.callLaterMethods;
			for (var method:Object in methods) {
				method();
				delete(methods[method]);
			}
			inCallLaterPhase = false;
		}
		
		/**
		 * 用于子类覆盖实现，这个方法将在显示对象加入显示列表时被调用
		 */
		private function configUI() { }
		
		
	}

}
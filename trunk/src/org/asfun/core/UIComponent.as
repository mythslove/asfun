package org.asfun.core {
	import flash.display.Sprite;
	import flash.events.Event;
	import flash.events.TimerEvent;
	import flash.utils.Timer;
	
	/**
	 * 组件的基类
	 * @author www.fanflash.cn
	 */
	public class UIComponent extends Sprite {
		
		//用来定义时间间隔的时间器
		private var invalidationTimer:Timer;
		
		public function UIComponent():void {
			if (this.stage) this.init();
			else this.addEventListener(Event.ADDED_TO_STAGE, this.onload);
		}
		
		/**
		 * 当显示对象出现在stage时
		 */
		private function onload(e:Event = null) {
			this.removeEventListener(Event.ADDED_TO_STAGE, this.onload);
			
			if (this._width == 0 && this._heigth == 0) this.setSize(super.width, super.height);
			this.configUI();
			//马上重绘
			this.validateNow();
		}
		
		//组件的宽
		private var _width:Number = 0;
		//组件的高
		private var _heigth:Number = 0;
		
		/**
		 * 
		 * @param	width
		 * @param	height
		 */
		public function setSize(width:Number, height:Numberb):void {
			
			if (this._width == width && _heigth == height) return;
			
			this._width = width;
			this._heigth = height;
			this.invalidata();
		}
		
		/**
		 * 设置或获取组件的高
		 */
		override public function get width():Number { return this._width; }
		override public function set width(value:Number):void {
			this.setSize(value, super.width || this._width);
		}
		
		/**
		 * 设置或获组件的高
		 */
		override public function get height():Number { return this._heigth; }
		override public function set height(value:Number):void {
			this.setSize(super.width || this._width, value);
		}
		
		/**
		 * 获取或设置组件是否禁用
		 */
		public var _disabled:Boolean = true;
		public function get disabled():Boolean { return this._disabled };
		public function set disabled(value:Boolean):void {
			this._disabled = value;
			this.useHandCursor = false;
			this.mouseEnabled = false;
			this.invalidata();
		}
		
		/**
		 * 让多人同一时间发生的属性改变只会发生一次重绘
		 */
		public function invalidata():void {
			
			//如果时间器已经在运行了，则退出
			if (this.invalidationTimer) return;
			this.invalidationTimer = new Timer(1, 1);
			this.invalidationTimer.addEventListener(TimerEvent.TIMER, this.validateNow);
			this.invalidationTimer.start();
		}
		
		/**
		 * 现在刷新生效果
		 */
		public function validateNow(e:TimerEvent = null):void {
			if (!this.invalidationTimer) return;
			this.invalidationTimer.removeEventListener(TimerEvent.TIMER, this.validateNow);
			this.invalidationTimer.stop();
			this.invalidationTimer = null;
			delete this.invalidationTimer;
			this.draw();
		}
		
		/**
		 * 用于其它类复写, 重绘组件时执行
		 */
		public function draw():void { }
		
		/**
		 * 用于其它类复写，当组件显示在stage时执行
		 */
		public function configUI():void {}
	}
	
}
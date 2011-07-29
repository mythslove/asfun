package org.fanflash.utils
{
	import flash.display.Sprite;
	import flash.events.Event;
	import flash.filters.GlowFilter;
	import flash.system.System;
	import flash.text.TextField;
	import flash.text.TextFieldAutoSize;
	import flash.utils.getTimer;

	/**
	 *用于显示swf的FPS和内存使用信息 
	 * @author fanflash.org
	 * 
	 */	
	public class SystemFPS extends Sprite
	{
		
		private var infoTxt:TextField;
		private var curTime:Number;
		
		public function SystemFPS()
		{
			this.init();
			this.initListener();
			
			
		}
		
		private function init():void{
			
			this.curTime = getTimer();
			
			this.infoTxt = new TextField();
			this.infoTxt.textColor = 0xffffff;
			this.infoTxt.selectable = false;
			this.infoTxt.autoSize = TextFieldAutoSize.LEFT;
			this.infoTxt.multiline = false;
			
			var gf:GlowFilter = new GlowFilter()
			gf.color = 0;
			gf.blurX = 2;
			gf.blurY = 2;
			gf.strength = 255;
			this.infoTxt.filters = [gf];
			
			this.addChild(this.infoTxt);
		}
		
		private function initListener():void {
			this.addEventListener(Event.ENTER_FRAME, this.enterFrameHandler);
		}
		
		
		private function enterFrameHandler(e:Event):void {
			
			//1000毫秒（一秒）/ 一帧所需要的毫秒数 = fps
			var t:int =getTimer()
			var fps:int = Math.round(1000 / (t - this.curTime));
			this.curTime = t;
			
			//1048576 = 1024*1024
			var mem:Number = Math.round(System.totalMemory / 104857.6) / 10;
			
			this.infoTxt.text = "FPS:" + fps.toString() + ", 内存:" + mem.toString() + "MB";
		}
	}
}
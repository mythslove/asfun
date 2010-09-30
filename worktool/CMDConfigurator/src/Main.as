package 
{
	import fl.controls.Button;
	import flash.display.Sprite;
	import flash.events.Event;
	import view.paraView.ParameterView;
	import flash.text.TextFormat;
	
	/**
	 * ...
	 * @author fanflash.cn
	 */
	public class Main extends Sprite 
	{
		
		public function Main():void 
		{
			if (stage) init();
			else addEventListener(Event.ADDED_TO_STAGE, init);
		}
		
		private function init(e:Event = null):void 
		{
			removeEventListener(Event.ADDED_TO_STAGE, init);
			// entry point
			
			var t:ParameterView = new ParameterView();
			t.setSize(550, 370);
			this.addChild(t);
			
			var addBtn:Button = new Button();
			addBtn.x = 5;
			addBtn.y = 375;
			addBtn.label = "增加参数";
			this.addChild(addBtn);
			
			var devBtn:Button = new Button();
			devBtn.x = addBtn.getRect(this).right + 5;
			devBtn.y = addBtn.y;
			devBtn.label = "减少参数";
			this.addChild(devBtn);
			
			addBtn.setStyle("textFormat", new TextFormat(null, 12));
			devBtn.setStyle("textFormat", new TextFormat(null, 12));
		}
	}
}
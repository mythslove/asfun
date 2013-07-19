package
{
	import flash.display.Graphics;
	import flash.display.Sprite;
	import flash.events.MouseEvent;
	import flash.geom.Point;
	import flash.text.TextField;
	import flash.text.TextFieldAutoSize;
	import flash.text.TextFormat;
	import flash.utils.Dictionary;
	
	import spark.primitives.Graphic;

	public class CViewer extends Sprite
	{
		private static var ShareSelectID:uint = 0;
		
		private var label:TextField;
		private var classList:Vector.<String>;
		private var clsViewerMap:Dictionary;
		private var hw:int;
		private var hh:int;
		private var color:uint;
		private var selected:Boolean;
		private var curSelectID:int = -1;
		
		public var cwidth:int = 150;
		public var cheight:int = 100;
		
		public var className:String;
		public var superName:String;
		
		public function CViewer()
		{
			/*
			this.graphics.beginFill(0xff0000);
			this.graphics.drawRect(0,0,150,100);
			this.graphics.endFill();
			*/
			
			this.label = new TextField();
			this.label.width = this.cwidth - 20;
			this.label.x = 10;
			this.label.wordWrap = true;
			this.label.selectable = false;
			this.label.autoSize = flash.text.TextFieldAutoSize.LEFT;
			this.label.border = true;
			
			var tf:TextFormat = new TextFormat();
			tf.align = TextFieldAutoSize.CENTER;
			this.label.defaultTextFormat = tf;
			this.addChild(this.label);
			
			this.hw = this.cwidth/2;
			this.hh = this.cheight/2;
			
			this.selected = false;
			this.addEventListener(MouseEvent.MOUSE_DOWN,this.mouseHandler);
		}
		
		/**
		 *设置信息 
		 * @param classInfo	本类的数据
		 * @param clsMap 所有类的表
		 * @param color	这个类的线的颜色
		 * 
		 */		
		public function setData(classInfo:ClassInfo, clsMap:Dictionary, color:uint = 0):void{
			
			this.label.text = classInfo.className;
			this.label.y = (this.cheight - this.label.height)/2;
			this.className = classInfo.className;
			this.superName = classInfo.superName;
			
			this.classList = new Vector.<String>();
			var clsMap:Dictionary = classInfo.useClassMap;
			for(var clsName:String in clsMap){
				this.classList.push(clsName);
			}
			classInfo.dispose();
			
			this.clsViewerMap = clsMap;
			this.color = color;
		}
		
		/**
		 *显示全部的关系线 
		 * 
		 */		
		public function showAllLine():void{
			this.drawLine(this.color);
		}
		
		public function selectCV(color:uint,isSelect:Boolean, selectID:int):void{
			
			if(this.curSelectID == selectID)return;
			
			this.curSelectID = selectID;
			
			if(isSelect){
				this.drawLine(color);
				this.parent.setChildIndex(this,this.parent.numChildren - 1);
			}else{
				this.drawLine(this.color);
			}
			
			var len:int = this.classList.length;
			
			for(var i:int = 0;i<len;i++){
				
				var clsName:String = this.classList[i];
				var clsViewer:CViewer = this.clsViewerMap[clsName];
				clsViewer.selectCV(color,isSelect,selectID);
			}
			
			var clsViewer2:CViewer = this.clsViewerMap[this.superName];
			if(clsViewer2 == null){
				trace("类为空：", this.superName);
				return;
			}
			clsViewer2.selectCV(color,isSelect,selectID);
		}
		
		private function drawLine(color:uint = 0):void{
			
			var g:Graphics = this.graphics;
			g.clear();
			g.lineStyle(1,color);
			var p:Point = new Point(this.hw,this.hh);
			
			var len:int = this.classList.length;
			
			for(var i:int = 0;i<len;i++){
				
				var clsName:String = this.classList[i];
				this.drawLineByName(clsName);
			}
			
			this.drawLineByName(this.superName);
			
		}
		
		private function drawLineByName(name:String):void{
			
			var g:Graphics = this.graphics;
			var clsViewer:CViewer = this.clsViewerMap[name];
			if(clsViewer == null){
				trace("类为空：", name);
				return;
			}
			
			var cx:int = clsViewer.x - this.x + this.hw;
			var cy:int = clsViewer.y - this.y + this.hh;
			
			g.moveTo(this.hw,this.hh);
			g.lineTo(cx,cy);
			g.beginFill(color);
			g.drawCircle(cx,cy,3);
			g.endFill();
		}
		
		protected function mouseHandler(event:MouseEvent):void
		{
			
			
			this.selected = !this.selected;
			this.selectCV(0xff0000,this.selected,ShareSelectID);
			
			
			ShareSelectID++;
		}
		
	}
}
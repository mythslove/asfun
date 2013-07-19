package
{
	import flash.events.MouseEvent;
	import flash.utils.Dictionary;
	
	import mx.core.UIComponent;

	/**
	 *类图查看器 
	 * @author Administrator
	 * 
	 */	
	public class ClassesViewer extends UIComponent
	{
		private var crMap:Dictionary;
		
		public function ClassesViewer()
		{
			
		}
		
		
		public function setData(classInfoList:Vector.<ClassInfo>):void{
			
			this.crMap = new Dictionary();
			
			var len:int = classInfoList.length;
			if(len <1)return;
			
			var num:int =  Math.ceil(Math.sqrt(len));
			var wid:int = 0;
			var yid:int = 0;
			
			var additon:int = Math.floor((0xffffff - 1) / len);
			var curColor:int = 1;
			
			for(var i:int= 0; i<len;i++){
				
				if(wid>= num){
					wid = 0;
					yid++;
				}
				
				var cv:CViewer = new CViewer();
				cv.setData(classInfoList.pop(),this.crMap,curColor);
				this.crMap[cv.className] = cv;
				cv.x= (cv.cwidth + 10) * wid;
				cv.y = cv.cheight * yid;
				this.addChild(cv);
				curColor += additon;
				wid++;
			}
			
		}
		
		
		/**
		 *重置这个显示示图 
		 * 
		 */		
		public function reset():void{
			
			
			
		}
		
	}
}
package
{
	
	/**
	 * 
	 * @author	fanflash.cn
	 * @date	2010-9-7
	 */
	public class DrugsInfo
	{
		public var priceOffset:Number = 0;
		public var infos:Array;
		
		public function DrugsInfo(){
			
			this.infos = [];
		}
		
		public function addInfo(price:Number,count:int):void{
			this.infos.push([price,count]);
		}
		
		public function toString():String {
			
			var t:String = "";
			
			var len:uint = infos.length;
			for(var i:int = 0;i<len;i++){
				var info:Array = this.infos[i];
				t += "价格为[" + info[0] + "]元的药品[" + info[1] + "]件。\n";
			}
			
			t +="总价值误差：" + priceOffset + "元";
				
			return t;
		}
	}
}
package view.paraView 
{
	import flash.display.MovieClip;
	
	/**
	 * 虚线
	 * @author fanflash.cn
	 */
	public class DashLineView extends MovieClip
	{
		
		public function DashLineView() 
		{
			
		}
		
		public function setMode(dt:Object) {
			this.gotoAndStop(dt);
		}
		
	}
	
}
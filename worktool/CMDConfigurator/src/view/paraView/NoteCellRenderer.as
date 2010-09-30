package view.paraView 
{
	import fl.controls.TextArea;
	import fl.controls.listClasses.ICellRenderer;
    import fl.controls.listClasses.ListData;
	import flash.events.MouseEvent;
	
	/**
	 * ...
	 * @author fanflash.cn
	 */
	public class NoteCellRenderer extends TextArea implements ICellRenderer
	{
		
        private var _listData:ListData;
        private var _data:Object;
		private var _selected:Boolean;
		
		public function NoteCellRenderer() 
		{
			
		}
		
        public function set data(d:Object):void {
            _data = d;
        }
		
        public function get data():Object {
            return _data;
        }
		
        public function set listData(ld:ListData):void {
            _listData = ld;
        }
		
        public function get listData():ListData {
            return _listData;
        }
		
        public function set selected(s:Boolean):void {
            _selected = s;
        }
		
        public function get selected():Boolean {
            return _selected;
        }
		
		public function setMouseState(state:String):void {
			
		}
	}
}
package view.paraView 
{
	import fl.controls.ComboBox;
	import fl.controls.listClasses.ICellRenderer;
    import fl.controls.listClasses.ListData;
	
	/**
	 * 参数类型渲染器
	 * @author fanflash.cn
	 */
	public class TypeCellRenderer extends ComboBox implements ICellRenderer
	{
		
        private var _listData:ListData;
        private var _data:Object;
		private var _selected:Boolean;
		
		public function TypeCellRenderer() 
		{
			this.addItem( { label:"Number" } );
			this.addItem( { label:"String" } );
			this.addItem( { label:"Array" } );
			this.addItem( { label:"Object" } );
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
		
		override protected function draw():void 
		{
			this.list.rowHeight = this.height;
			super.draw();
		}
	}
}
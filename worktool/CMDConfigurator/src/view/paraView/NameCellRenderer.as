﻿package view.paraView 
{
	
	import fl.controls.Button;
	import flash.display.Sprite;
	import flash.display.MovieClip;
    import flash.text.TextField;
    import fl.controls.listClasses.ICellRenderer;
    import fl.controls.listClasses.ListData;
	
	/**
	 * ...
	 * @author fanflash.cn
	 */
	public class NameCellRenderer extends Sprite implements ICellRenderer
	{
		
        private var _listData:ListData;
        private var _data:Object;
        private var _selected:Boolean;
		
		/*
		private var bg:MovieClip;
		*/
		
        public function NameCellRenderer() {
			
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
		
        public function setSize(width:Number, height:Number):void {
			
			this.bg.width = width;
			this.bg.height = height;
        }
		
        public function setStyle(style:String, value:Object):void {
        }
		
		
		public function setMouseState(state:String):void {
			
		}
	}
	
}
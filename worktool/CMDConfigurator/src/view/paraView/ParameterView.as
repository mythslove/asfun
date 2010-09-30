package view.paraView 
{
	import fl.controls.DataGrid;
	import flash.display.Sprite;
	import fl.data.DataProvider;
	import flash.text.TextFormat;
	
	
	/**
	 * 参数配置视图
	 * @author fanflash.cn
	 */
	public class ParameterView extends DataGrid
	{
		//表示修改了标题头
		private static var CHANGE_TITLE_TEXT:Number = 0;
		
		/**
		 * 须要修改的属性的haspmap
		 */
		private var changeHashMap:Object;
		
		public function ParameterView() 
		{
			
			this.changeHashMap = new Object();
			this.init();
		}
		
		/**
		 * 初始化
		 */
		private function init() {
			
			//设置标题头
			this.columns = ["op", "name", "type", "notes"];
			this.getColumnAt(0).width = 46;
			this.getColumnAt(0).resizable = false;
			this.getColumnAt(0).cellRenderer = OpCellRenderer;
			this.getColumnAt(1).cellRenderer = NameCellRenderer;
			this.getColumnAt(2).cellRenderer = TypeCellRenderer;
			this.getColumnAt(3).cellRenderer = NoteCellRenderer;
			this.rowHeight = 28;
			
			//设置显示出来的标题名
			this.setTitleTxt("操作", "参数名", "参数类型", "注释");
			//不能点击标题进行排序
			this.sortableColumns = false;
			//设置标题的字体
			this.setStyle("headerTextFormat", new TextFormat(null, 12));
		    //执行编辑模式
			this.doEidtorMode();
		}
		
		/**
		 * 测试标题文字
		 */
		public function setTitleTxt(opStr:String,nameStr:String, typeStr:String, noteStr:String) {
			
			//这樯设置索引还是英文的
			this.getColumnAt(0).headerText = opStr;
			this.getColumnAt(1).headerText = nameStr;
			this.getColumnAt(2).headerText = typeStr;
			this.getColumnAt(3).headerText = noteStr;
		}
		
		
		override protected function draw():void 
		{
			super.draw();
			for (var i:String in this.changeHashMap) {
				this.changeProperty(i);
			}
		}
		
		/**
		 * 更改属性
		 * @param	id
		 */
		private function changeProperty(id:String) {
			
			switch (id) 
			{
				case CHANGE_TITLE_TEXT.toString() :
				
				break;
				default :
				//没有发现空上更改值，所以，下面的消息回收不执行了。
				return;
			}
			
			this.changeHashMap[id] = null
			delete this.changeHashMap[id];
		}
		
		/**
		 * 执行编辑模式
		 */
		private function doEidtorMode() {
			this.addItem( { name:"", type:"", notes:"" } );
		}
		
	}	
}
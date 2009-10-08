package org.asfun.richTextEditor.insertItem {
	import org.asfun.core.UIComponent;
	
	/**
	 * 文本内容项基类
	 * @author www.fanflash.cn
	 */
	public class InsertItemBase extends UIComponent{
		
		public function InsertItemBase() {
			
		}
		
		//上一个插入对像
		public var preItem:InsertItemBase;
		//下一个插入对像
		public var nextItem:InsertItemBase;
		
		/**
		 * 在对角中间插入新的对像
		 * @param	id
		 * @param	dt
		 */
		public function insertItem(id:uint, dt:InsertItemBase) {
			
		}
	}
}
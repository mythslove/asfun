package cn.fanflash.core 
{
	/**
	 * InvalidationType 类定义组件invalidate方法property参数要使用的值，可以使用这些常量来指定要重绘组件的那一个部分。
	 * @author fanflash
	 */
	public class InvalidationType
	{
		/**
		 * 改变组件的全部
		 */
		public static const ALL:String = "all";
		
		/**
		 * 改变组件的位置
		 */
		public static const SIZE:String = "size";
		
		/**
		 * 改变组件的样式
		 */
		public static const STYLES:String = "styles";
		
		/**
		 * 渲染组件样式
		 */
		public static const RENDERER_STYLES:String = "rendererStyles";		
		
		/**
		 * 渲染组件状态
		 */
		public static const STATE:String = "state";
		
		/**
		 * 渲染组件数据
		 */
		public static const DATA:String = "data";
		
		/**
		 * 对组件的滚动进行渲染
		 */
		public static const SCROLL:String = "scroll";
		
		/**
		 * 对组件的选择进行渲染
		 */
		public static const SELECTED:String = "selected";
	}

}
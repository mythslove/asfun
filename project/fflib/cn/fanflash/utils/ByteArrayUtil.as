package cn.fanflash.utils
{
	import flash.utils.ByteArray;
	
	
	/**
	 * 字节操作工具
	 * @author fanflash
	 */
	public class ByteArrayUtil
	{
		
		public static function byteIndexOf(byte:ByteArray,findByte:ByteArray,startIndex:uint):int{
			
			return -1;
		}
		
		
		/**
		 * 从后面查找一个字节数组
		 * @param byte			源字节数组
		 * @param findByte		要查找的字节数组
		 * @param startIndex	开始查找的位置
		 * @return 
		 * 
		 */		
		public static function byteLastIndexOf(byte:ByteArray,findByte:ByteArray,startIndex:uint = int.MAX_VALUE):int{
			
			if(byte == null)return -1;
			if(findByte == null)return -1;
			if(findByte.length > byte.length)return -1;
			if(startIndex > byte.length )startIndex = byte.length - 1;
			
			var lastIndex:uint = findByte.length -1;
			var stopIndex:int = lastIndex -1;
			
			
			for(var i:int = startIndex-1;i > stopIndex;i--){
				if(findByte[lastIndex] == byte[i] ){
					var si:int = i - lastIndex -1;
					var tf:int = stopIndex;
					var isFind:Boolean= true;
					for(var j:int = i-1;j>si;j-- ){
						if(byte[j] != findByte[tf--]){
							isFind = false;
							break;
						}
					}
					
					if(isFind)return i-lastIndex;
				}
			}
			
			return -1;
		}
	}
}
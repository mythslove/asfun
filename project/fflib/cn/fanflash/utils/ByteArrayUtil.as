package cn.fanflash.utils
{
	import flash.utils.ByteArray;
	
	/**
	 * 字节操作工具
	 * @author fanflash
	 */
	public class ByteArrayUtil
	{
		public function ByteArrayUtil()
		{
		}
		
		
		public function byteIndexOf(byte:ByteArray,findByte:ByteArray,startIndex:uint):int{
			return -1;
		}
		
		public function byteLastIndexOf(byte:ByteArray,findByte:ByteArray,startIndex:uint = int.MAX_VALUE):int{
			
			if(byte == null)return -1;
			if(findByte == null)return -1;
			if(startIndex > byte.length )startIndex = byte.length;
			
			for(var i:int = startIndex-1;i>-1;i--){
				
			}
			
			return -1;
		}
	}
}
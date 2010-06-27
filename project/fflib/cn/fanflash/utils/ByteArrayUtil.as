package cn.fanflash.utils
{
	import flash.utils.ByteArray;
	
	
	/**
	 * 字节操作工具
	 * @author fanflash.cn
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
		
		/**
		 *用zlib压缩字节数组 
		 * @param byte		源字节数组
		 * @param offset	压缩偏移，在哪里开始压缩
		 * @param length	压缩多长的字节串，如果为0，则压缩从offset到结速的字节串。
		 * 
		 */		
		public static function compress(byte:ByteArray, offset:uint = 0, length:uint = 0):void
		{
			var pos:uint = byte.position;
			
			if (offset == 0 && length == 0) {
				byte.compress();
			}
			else {
				var temp:ByteArray = new ByteArray();
				temp.writeBytes(byte, offset, length);
				temp.compress();
				temp.position = temp.length - 1;
				if (length != 0 && (offset + length) < byte.length) {
					temp.writeBytes(byte, offset + length);
				}
				byte.length = offset;
				byte.position = offset;
				byte.writeBytes(temp);
				temp.length = 0;
			}
			
			byte.position = pos;
		}
	}
}
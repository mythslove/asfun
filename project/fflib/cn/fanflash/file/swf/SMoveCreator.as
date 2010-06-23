/**
 * 创建SWF格式的影片
 * 格式参考资料：http://the-labs.com/MacromediaFlash/SWF-Spec/SWFfilereference.html
 */

package cn.fanflash.file.swf
{
	
	import com.adobe.images.JPGEncoder;
	
	import flash.display.BitmapData;
	import flash.utils.ByteArray;
	
	import org.libspark.swfassist.io.*;
	import org.libspark.swfassist.swf.io.*;
	import org.libspark.swfassist.swf.structures.*;
	import org.libspark.swfassist.swf.tags.*; 
	
	public class SMoveCreator
	{
		private var _quality:uint;
		private var _width:uint;
		private var _height:uint;
		private var _fps:uint;
		private var _jpgEnc:JPGEncoder;
		private var _swf:SWF;
		private var _frame:uint;
		
		private var _tagSCR:StyleChangeRecord;
		private var _tagSER1:StraightEdgeRecord;
		private var _tagSER2:StraightEdgeRecord;
		private var _tagSER3:StraightEdgeRecord;
		private var _tagSER4:StraightEdgeRecord;
		private var _tagSF:ShowFrame; 
		
		public function SMoveCreator(width:uint=320,height:uint=240,fps:uint=12,quality:uint=50) {
			
			_width = width;
			_height = height;
			_quality = quality;
			_fps = fps; 
			
			_tagSCR = new StyleChangeRecord();
			_tagSCR.stateFillStyle1=true;
			_tagSCR.stateMoveTo = true;
			_tagSCR.moveDeltaX = _width;
			_tagSCR.moveDeltaY = _height;
			_tagSCR.fillStyle1=1;
			_tagSCR.fillStyle0=0; 
			
			_tagSER1= new StraightEdgeRecord();
			_tagSER1.generalLine=false;
			_tagSER1.verticalLine=false;
			_tagSER1.deltaX=-_width;
			_tagSER1.deltaY=0; 
			
			_tagSER2= new StraightEdgeRecord();
			_tagSER2.generalLine=false;
			_tagSER2.verticalLine=true;
			_tagSER2.deltaX=0;
			_tagSER2.deltaY=-_height; 
			
			_tagSER3= new StraightEdgeRecord();
			_tagSER3.generalLine=false;
			_tagSER3.verticalLine=false;
			_tagSER3.deltaX=_width;
			_tagSER3.deltaY=0; 
			
			_tagSER4= new StraightEdgeRecord();
			_tagSER4.generalLine=false;
			_tagSER4.verticalLine=true;
			_tagSER4.deltaX=0;
			_tagSER4.deltaY=_height; 
			
			_tagSF = new ShowFrame();
			_jpgEnc = new JPGEncoder(_quality);
			
			start();
		}
		
		/**
		 *开始制作SWF 
		 * 
		 */		
		private function start():void{
			_swf = new SWF();
			_swf.header.version = 8;
			_swf.header.frameSize.xMax = _width;
			_swf.header.frameSize.yMax = _height;
			_swf.header.isCompressed = true;
			_swf.header.frameRate = _fps;
			_swf.tags.addTag(new SetBackgroundColor());
			_frame = 1;
		}
		
		/**
		 *得到SWF文件的帧频 
		 * @return 
		 * 
		 */		
		public function get frame():uint{
			return _frame
		}
		
		
		/**
		 *加入帧 
		 * @param bmpData 帧数据
		 * 
		 */		
		public function addFrame(bmpData:BitmapData):void {
			
			//这个tag表示有渐变的JPG
			var tagDBJ:DefineBitsJPEG2 = new DefineBitsJPEG2();
			tagDBJ.characterId = (_frame-1)*2+1;
			tagDBJ.jpegData = _jpgEnc.encode(bmpData);
			
			//一点资料都没有，好不容易猜出来怎么用的。。。
			//var tt:ExportAssets = new ExportAssets();
			//var ta:Asset = new Asset();
			//ta.characterId = tagDBJ.characterId
		    //ta.name = "test"
			//tt.assets =[ta];
			
			var tagDS:DefineShape = new DefineShape();
			tagDS.shapeId = (_frame-1)*2+2;
			tagDS.shapeBounds.xMin = 0;
			tagDS.shapeBounds.xMax = _width;
			tagDS.shapeBounds.yMin = 0;
			tagDS.shapeBounds.yMax = _height;
			
			var tagFS:FillStyle = new FillStyle();
			tagFS.color.fromUint(0xff000000);
			tagFS.fillStyleType = 67;
			tagFS.bitmapId = (_frame-1)*2+1;
			tagFS.bitmapMatrix.hasScale = true;
			tagFS.bitmapMatrix.scaleX = 20;
			tagFS.bitmapMatrix.scaleY = 20;
			
			tagDS.shapes.shapeRecords = [_tagSCR,_tagSER1,_tagSER2,_tagSER3,_tagSER4];
			tagDS.shapes.fillStyles.fillStyles = [tagFS];
			
			var tagPO:PlaceObject2 = new PlaceObject2();
			tagPO.hasCharacter = true;
			tagPO.hasMatrix = true;
			tagPO.depth=_frame;
			tagPO.characterId = (_frame-1)*2+2;
			
			_swf.tags.addTag(tagDBJ);
			_swf.tags.addTag(tagDS);
			_swf.tags.addTag(tagPO);
			_swf.tags.addTag(_tagSF);
			//_swf.tags.addTag(tt);
			
			_frame++;
		}
		
		/**
		 *完成制作，最后调用 
		 * @return 
		 * 
		 */		
		public function getSWF():ByteArray {
			var data:ByteArray = new ByteArray();
			var swfWrriter:SWFWriter = new SWFWriter();
			var out:ByteArrayOutputStream = new ByteArrayOutputStream(data);
			var context:WritingContext = new WritingContext();
			swfWrriter.writeSWF(out,context,_swf);
			
			return data
		}
		
	}
}
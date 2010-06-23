package cn.fanflash.file.swf
{
	import com.adobe.images.JPGEncoder;
	
	import flash.display.BitmapData;
	import flash.utils.ByteArray;
	
	import org.libspark.swfassist.io.ByteArrayOutputStream;
	import org.libspark.swfassist.swf.io.SWFWriter;
	import org.libspark.swfassist.swf.io.WritingContext;
	import org.libspark.swfassist.swf.structures.Asset;
	import org.libspark.swfassist.swf.structures.FillStyle;
	import org.libspark.swfassist.swf.structures.SWF;
	import org.libspark.swfassist.swf.structures.StraightEdgeRecord;
	import org.libspark.swfassist.swf.structures.StyleChangeRecord;
	import org.libspark.swfassist.swf.tags.DefineBitsJPEG2;
	import org.libspark.swfassist.swf.tags.DefineShape;
	import org.libspark.swfassist.swf.tags.ExportAssets;
	import org.libspark.swfassist.swf.tags.PlaceObject2;
	import org.libspark.swfassist.swf.tags.SetBackgroundColor;
	import org.libspark.swfassist.swf.tags.ShowFrame;

	public class SwfUtils
	{
		
		/**
		 *得到swf格式的图片 
		 * @param bmp 图片的数据
		 * @return swf文件的字节流
		 * 
		 */		
		public static function getSwfImage(bmp:BitmapData,identifier:String="", quality:int = 80 ):ByteArray{
			
			var tagSCR:StyleChangeRecord = new StyleChangeRecord();
			tagSCR.stateFillStyle1=true;
			tagSCR.stateMoveTo = true;
			tagSCR.moveDeltaX = bmp.width;
			tagSCR.moveDeltaY = bmp.height;
			tagSCR.fillStyle1=1;
			tagSCR.fillStyle0=0; 
			
			var tagSER1:StraightEdgeRecord = new StraightEdgeRecord();
			tagSER1.generalLine=false;
			tagSER1.verticalLine=false;
			tagSER1.deltaX=-bmp.width;
			tagSER1.deltaY=0; 
			
			var tagSER2:StraightEdgeRecord = new StraightEdgeRecord();
			tagSER2.generalLine=false;
			tagSER2.verticalLine=true;
			tagSER2.deltaX=0;
			tagSER2.deltaY=-bmp.height; 
			
			var tagSER3:StraightEdgeRecord = new StraightEdgeRecord();
			tagSER3.generalLine=false;
			tagSER3.verticalLine=false;
			tagSER3.deltaX=bmp.width;
			tagSER3.deltaY=0; 
			
			var tagSER4:StraightEdgeRecord = new StraightEdgeRecord();
			tagSER4.generalLine=false;
			tagSER4.verticalLine=true;
			tagSER4.deltaX=0;
			tagSER4.deltaY=bmp.height; 
			
			var tagSF:ShowFrame = new ShowFrame();
			
			//文件头
			var swf:SWF = new SWF();
			swf.header.version = 8;
			swf.header.frameSize.xMax = bmp.width;
			swf.header.frameSize.yMax = bmp.height;
			swf.header.isCompressed = true;
			swf.header.frameRate = 1;
			swf.tags.addTag(new SetBackgroundColor(0xffffff));
			
			var jpg:JPGEncoder = new JPGEncoder(quality);
			
			//这个tag表示有渐变的JPG
			var tagDBJ:DefineBitsJPEG2 = new DefineBitsJPEG2();
			tagDBJ.characterId = 1;
			tagDBJ.jpegData = jpg.encode(bmp);
			
			//一点资料都没有，好不容易猜出来怎么用的。。。
			var asset:Asset = new Asset();
			asset.characterId = 1;
			asset.name = identifier;
			var tagEA:ExportAssets = new ExportAssets();
			tagEA.assets = [asset];
			
			var tagDS:DefineShape = new DefineShape();
			tagDS.shapeId = 2
			tagDS.shapeBounds.xMin = 0;
			tagDS.shapeBounds.xMax = bmp.width;
			tagDS.shapeBounds.yMin = 0;
			tagDS.shapeBounds.yMax = bmp.height;
			
			var tagFS:FillStyle = new FillStyle();
			tagFS.color.fromUint(0xff000000);
			tagFS.fillStyleType = 67;
			tagFS.bitmapId = 1;
			tagFS.bitmapMatrix.hasScale = true;
			tagFS.bitmapMatrix.scaleX = 20;
			tagFS.bitmapMatrix.scaleY = 20;
			
			tagDS.shapes.shapeRecords = [tagSCR,tagSER1,tagSER2,tagSER3,tagSER4];
			tagDS.shapes.fillStyles.fillStyles = [tagFS];
			
			var tagPO:PlaceObject2 = new PlaceObject2();
			tagPO.hasCharacter = true;
			tagPO.hasMatrix = true;
			tagPO.depth=1;
			tagPO.characterId = 2;
			
			swf.tags.addTag(tagDBJ);
			swf.tags.addTag(tagDS);
			swf.tags.addTag(tagPO);
			swf.tags.addTag(tagSF);
			swf.tags.addTag(tagEA);
			
			var data:ByteArray = new ByteArray();
			var swfWrriter:SWFWriter = new SWFWriter();
			var out:ByteArrayOutputStream = new ByteArrayOutputStream(data);
			var context:WritingContext = new WritingContext();
			swfWrriter.writeSWF(out,context,swf);
			
			return data
		}
	}
}
package
{
	import com.swfwire.decompiler.abc.tokens.TraitsInfoToken;
	
	import flash.utils.Dictionary;
	
	import spark.components.TextArea;

	public class ClassInfo
	{
		private var astool:ABCToActionScript;
		private var trait:TraitsInfoToken;
		private var infoTxt:TextArea;
		private var rt:ReadableTrait;
		
		public var className:String;
		public var superName:String;
		public var useClassMap:Dictionary;
		
		public function ClassInfo(trait:TraitsInfoToken,astool:ABCToActionScript,infoTxt:TextArea)
		{
			this.astool = astool;
			this.trait = trait;
			this.infoTxt = infoTxt;
			
			//赶紧为了先统计出所有的类
			astool.useClassMap = new Dictionary();
			
			var r:ReadableTrait = new ReadableTrait();
			astool.getReadableTrait(trait,r);
			this.rt = r;
			
			this.className = astool.multinameTypeToString(r.declaration);
			if((r.classInfo != null) && (r.classInfo.superName != null)){
				this.superName = astool.multinameTypeToString(r.classInfo.superName);
			}
			
			this.useClassMap = new Dictionary();
			for(var i:String in this.astool.useClassMap){
				this.useClassMap[i] = i;
				delete this.astool.useClassMap[i];
			}
			
			astool.useClassMap = null;
		}
		
		
		public function doDecode():void{
			astool.useClassMap = new Dictionary();
			
			//删除去没用的类
			delete this.useClassMap[this.className]
			for(var clsName:String in this.useClassMap){
				if(!this.astool.hasClass(clsName)){
					delete this.useClassMap[clsName];
				}
			}
			
			/*
			var r:ReadableTrait = new ReadableTrait();
			astool.getReadableTrait(trait,r);
			
			this.className = astool.multinameTypeToString(r.declaration);
			if((r.classInfo != null) && (r.classInfo.superName != null)){
				this.superName = astool.multinameTypeToString(r.classInfo.superName);
			}
			*/
			
			this.infoTxt.text = "解析" + this.className + "中";
			var classStr:String = astool.scriptTraitToString(this.rt);
			
			delete astool.useClassMap[this.className];
			
			if(this.superName)delete astool.useClassMap[this.superName]
			for(var i:String in astool.useClassMap){
				this.useClassMap[i] = i;
				delete astool.useClassMap[i];
			}
			
			astool.useClassMap = null;
		}
		
		public function dispose():void{
			this.astool = null;
			this.trait = null;
			this.infoTxt = null;
			this.rt = null;
			
			for(var item:String in this.useClassMap){
				delete this.useClassMap[item];
			}
			this.useClassMap = null;
		}
		
	}
}
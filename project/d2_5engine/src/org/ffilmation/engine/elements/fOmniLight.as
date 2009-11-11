package org.ffilmation.engine.elements {

		// Imports
		import flash.geom.*
		import flash.events.*
		import org.ffilmation.engine.core.*
		
		/**
		* <p>
		* Spot light definition. Behaves as an Omni light in 3dMax. A point projecting light in all directions
		* 投射灯光定义，表现类似3dMax中的全向光，一个点向周围投射灯光。
		* </p>
		*
		* <p>
		* Projects into planes as a circle
		* 到平面项目里，就像一个圆圈
		* </p>
		*
		* <p>
		* YOU CAN'T CREATE INSTANCES OF THIS ELEMENT DIRECTLY.
		* Use scene.createOmniLight() to add new lights to a scene.
		* 你不能直接的创建这个对象的实例
		* 必需使用scene.createOmniLight()来给场景加入新的灯光。
		* </p>
		*
		* @see org.ffilmation.engine.core.fScene#createOmniLight()
		*/
		public class fOmniLight extends fLight {
		
 		  /** @private */
 		  public static var counter:int = 0

			/** 
			* Numeric counter for fast Array lookups
			* @private
			*/
			public var counter:int

			/**
			* Contructor
			*
			* @param defObj And XML defining the light
			* @param scene The scene where the light will be
			*
			* @private
			*/
			function fOmniLight(defObj:XML,scene:fScene) {

			   this.addEventListener(fLight.INTENSITYCHANGE,this.newIntensity,false,0,true)
			   this.addEventListener(fLight.COLORCHANGE,this.newIntensity,false,0,true)

			   super(defObj,scene)
			   
				 // Counter
				 this.counter = this.scene.lights.length

			}
			
			/** @private	*/
			public function newIntensity(e:Event):void {
 			   var pc:Number = this.intensity/100

  	     this.color = new ColorTransform(this.lightColor.redMultiplier, this.lightColor.greenMultiplier, this.lightColor.blueMultiplier,pc,
  	                     								 this.lightColor.redOffset,this.lightColor.greenOffset,this.lightColor.blueOffset,0)
  	                     
			}
		
			/** @private */
			public function disposeOmniLight():void {
			   this.removeEventListener(fLight.INTENSITYCHANGE,this.newIntensity)
			   this.removeEventListener(fLight.COLORCHANGE,this.newIntensity)
				 this.disposeLight()
			}

			/** @private */
			public override function dispose():void {
				 this.disposeOmniLight()
			}



		}


}

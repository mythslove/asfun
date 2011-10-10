import ngs.GCpp;
/**
 * 拍卖行命令接口
 * @author fanflash.org
 */
class AucCmdProxy
{
	
	/**
	 * 搜索拍卖物品
	 * 所有int参数如果为空填-1
	 * @param	type			类型ID
	 * @param	name			物品名称
	 * @param	minLV			最低等级
	 * @param	maxLV			最高等级
	 * @param	starLV			星级(稀有程度)
	 * @param	isHaveMoney		是否金钱拍卖
	 * @param	isHaveEMoney	是否代币拍卖
	 */
	public static function SearchAuctionItems(type:Number, name:String, minLV:Number, maxLV:Number, starLV:Number, isHaveMoney:Boolean, isHaveEMoney:Boolean) {
		
		if (IsTest) {
			GCpp.SendEvent("RefreshAuctioPage", 0);
			GCpp.callMethod("SearchAuctionItems", type, name, minLV, maxLV, starLV, isHaveMoney, isHaveEMoney);
			return;
		}
		
		GCpp.callMethod("SearchAuctionItems", type, name, minLV, maxLV, starLV, isHaveMoney, isHaveEMoney);
	}
	
	/**
	 * 对拍卖行物品进行排序
	 * @param	sortItems	排序的数据的类别:
							0表示浏览界面数据（浏览界面）
							1表示自己竞标的数据（竞标界面）
							2表示自己拍卖的数据（拍卖界面）

	 * @param	type		排序依据类型
							0 稀有程度
							1 使用等级
							2 剩余时间
							3 出售者
							4 当前价格
							5 一口价
							6 竞标状态
							7.最高出价者

	 * @param	forward		是否是正向排序
	 */
	public static function SortAuctionItems(sortItems:Number, type:Number, forward:Boolean) {
		GCpp.callMethod("SortAuctionItems", sortItems, type, forward);
	}
	
	public static function GetAuctionCount
	
	
	/**
	 * 获取当前所有的拍卖品的信息（浏览界面）
	 * 应该是只有一页的拍卖信息
	 * @return
	 */
	public static function GetAllAuctionInfo():Array {
		
		if (IsTest) {
			
			var getItemInfo:Function = function(itemID:Number):Object {
				
				var info:Object = { };
				info.nAuctionID = itemID;			//拍卖品ID
				info.strName = "拍卖品" + itemID;	//拍卖品名字
				info.nAuctionNum = random(100) +1;	//拍卖品数量
				info.strIcon = itemID.toString();	//拍卖品图标
				info.nTime = random(64800);			//剩余时间(秒钟)
				info.bIsEmoney = random(2) == 0;	//是否是代币
				info.nBidMoney = random(1000001);	//竞价金钱或代币
				info.nMoney = random(1000001);		//一口价金钱或代币
				info.strSeller = "人物" + random(100000) + "号"		//出售者名称
				info.nStarLev = random(9) +1;		//星级(稀有程度)
				info.nUseLev = random(101);			//使用等级
				info.bBidForSelf = random(2) == 0;	//是否是自己竞价
				info.bBidName = "人物" + random(100000) + "号";		//最高出价者（NULL表示无人出价）	
				
				return info;
			}
			
			var data:Array = [];
			var itemCount:Number = random(14) +1;
			for (var i:Number = 0; i < itemCount; i++ ) {
				data.push(getItemInfo(i));
			}
			
			return data;
		}
		
		return GCpp.callMethodRA("GetAllAuctionInfo");
	}
	
	/**
	 * 获取当前所有自己竞价的拍卖品的信息（竞标界面）
	 * @return
	 */
	public static function GetAllBidAuctionInfo():Array {
		
		if (IsTest) {
			
			var getItemInfo:Function = function(itemID:Number):Object {
				
				var info:Object = { };
				info.nAuctionID = itemID;			//拍卖品ID
				info.strName = "拍卖品" + itemID;	//拍卖品名字
				info.nAuctionNum = random(100) +1;	//拍卖品数量
				info.strIcon = itemID.toString();	//拍卖品图标
				info.nTime = random(64800);			//剩余时间(秒钟)
				info.bIsEmoney = random(2) == 0;	//是否是代币
				info.nBidMoney = random(1000001);	//竞价金钱或代币
				info.nMoney = random(1000001);		//一口价金钱或代币
				info.nUseLev = random(101);			//使用等级
				info.bBidForSelf = random(2) == 0;	//是否自己是最高出价
				
				return info;
			}
			
			var data:Array = [];
			var itemCount:Number = random(14) +1;
			for (var i:Number = 0; i < itemCount; i++ ) {
				data.push(getItemInfo(i));
			}
			
			return data;
		}
		
		return GCpp.callMethodRA("GetAllBidAuctionInfo");
	}
	
	
	
	/**
	 * 获取当前所有的自己的拍卖品的信息（拍卖界面）
	 * @return
	 */
	public static function GetAllOwnAuctionInfo():Array {
		
		if (IsTest) {
			
			var getItemInfo:Function = function(itemID:Number):Object {
				
				var info:Object = { };
				info.nAuctionID = itemID;			//拍卖品ID
				info.strName = "拍卖品" + itemID;	//拍卖品名字
				info.nAuctionNum = random(100) +1;	//拍卖品数量
				info.strIcon = itemID.toString();	//拍卖品图标
				info.nTime = random(64800);			//剩余时间(秒钟)
				info.bIsEmoney = random(2) == 0;	//是否是代币
				info.nBidMoney = random(1000001);	//竞价金钱或代币
				info.nMoney = random(1000001);		//一口价金钱或代币
				info.bBidName = "人物" + random(100000) + "号";		//最高出价者（NULL表示无人出价）	
				
				return info;
			}
			
			var data:Array = [];
			var itemCount:Number = random(14) +1;
			for (var i:Number = 0; i < itemCount; i++ ) {
				data.push(getItemInfo(i));
			}
			
			return data;
		}
		
		return GCpp.callMethodRA("GetAllOwnAuctionInfo");
	}
	
	/**
	 * 获取拍卖物品的类型
	 * @return
	 */
	public static function GetAuctionItemTypeTree():Object {
		
		if (IsTest) {
			var data:Object = { label:"data",
								status:true,
								typeID:0,
								nodes:[
									{label:"武器" ,
									typeID:1,
									nodes:[
										{label:"盾枪（盾锤）", typeID:2 },
										{label:"双手剑", typeID:3 },
										{label:"双手杖", typeID:4 },
										{label:"双手斧(双手锤)", typeID:5 },
										{label:"法剑+法器", typeID:6 },
										{label:"双持剑(双持斧)", typeID:7},
										{label:"兵种武器", typeID:8}
									]},
									{label:"护甲" ,
									typeID:9,
									nodes:[
										{label:"物理系",
										typeID:10,
										nodes:[
											{label:"锁甲", typeID:11 },
											{label:"头盔", typeID:12 },
											{label:"护腕", typeID:13 },
											{label:"手套", typeID:14 },
											{label:"靴子", typeID:15 }
										]},
										{label:"法术系", 
										typeID:16,
										nodes:[
											{label:"布甲", typeID:17 },
											{label:"头盔", typeID:18 },
											{label:"护腕", typeID:19 },
											{label:"手套", typeID:20 },
											{label:"靴子", typeID:21 }
										] },
										{label:"杂项",
										typeID:22,
										nodes:[
											{label:"戒指", typeID:23 },
											{label:"饰品", typeID:24 },
											{label:"项链", typeID:25 },
											{label:"嗜好物", typeID:26 }
										]}
									]},
									{label:"商品" ,
									typeID:27,
									nodes:[
										{label:"食物和饮料",
										typeID:28,
										nodes:[
											{label:"食物成品", typeID:29 },
											{label:"食物材料", typeID:30 }
										]},
										{label:"药水", typeID:31 }
									]}
								] }
			return data;
		}
		
		return GCpp.callMethodRJ("GetAuctionItemTypeTree");
	}
	
	/**
	 * 上一页数据
	 */
	public static function ChangeAuctionPreItems() {
		GCpp.callMethod("ChangeAuctionPreItems");
	}
	
	/**
	 * 下一页数据
	 */
	public static function ChangeAuctioNextItems() {
		GCpp.callMethod("ChangeAuctioNextItems");
	}
	
	/**
	 * 一口价购买
	 * @param	auctionID	拍卖ID
	 */
	public static function BuyAuctionItem(auctionID:Number) {
		GCpp.callMethod("BuyAuctionItem", auctionID);
	}
	
	/**
	 * 竞标
	 * @param	auctionID	拍卖ID
	 * @param	money		竞标出价的金币
	 * @param	eMoney		竞标出价的代币
	 */
	public static function BidAuctionItem(auctionID:Number, money:Number, eMoney:Number) {
		GCpp.callMethod("BidAuctionItem", auctionID, money, eMoney);
	}
	
	
	/////////////////////////////////////////////////////////////////////
	//						     VC事件
	/////////////////////////////////////////////////////////////////////
	
	
	/**
	 * 通知客户端界面刷新
	 * @param	callBackName
	 * @param	thisObj
	 * @param	isRemove
	 */
	public static function Event_RefreshAuctioPage(callBackName:String, thisObj:Object, isRemove:Boolean) {
		
		//pageID,刷新界面的ID,0:浏览界面，1:竞拍界面，2:拍卖界面
		GCpp.eventListener("RefreshAuctioPage", thisObj, callBackName, isRemove);
	}
	
	
	
	
	
	/////////////////////////////////////////////////////////////////////
	//						     测试相关
	/////////////////////////////////////////////////////////////////////
	
	public static var IsTest:Boolean = false;
}
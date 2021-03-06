using System;

namespace JuanDelaCruz {
	
	public interface IMonster {

		string name {get;set;}
		int level {get;set;}
		int hitPoints { get; set; }
		MONSTER_TYPE monsterType { get; set; }
		int minDamage { get; set; }
		int maxDamage { get; set; }
		int goldReward { get; set; }
		int expReward { get; set; }
		string monsterImg {get;set;}
	}

}


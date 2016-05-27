using System;

namespace JuanDelaCruz {
	
	public interface IMonster {

		int hitPoints { get; set; }
		MONSTER_TYPE monsterType { get; set; }
		int minDamage { get; set; }
		int maxDamage { get; set; }
		int goldReward { get; set; }
		int experienceGiven { get; set; }

	}

}


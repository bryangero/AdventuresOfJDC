using System;

namespace JuanDelaCruz {
	
	public class Monster : IMonster {
		
		public int hitPoints { get; set; }
		public MONSTER_TYPE monsterType { get; set; }
		public int minDamage { get; set; }
		public int maxDamage { get; set; }
		public int goldReward { get; set; }
		public int expReward { get; set; }

	}

}


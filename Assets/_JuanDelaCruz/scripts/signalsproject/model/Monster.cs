using System;

namespace JuanDelaCruz {
	
	public class Monster : IMonster {
		
		public int hitPoints { get; set; }
		public MONSTER_TYPE monsterType { get; set; }
		public int minDamage { get; set; }
		public int maxDamage { get; set; }
		public int goldReward { get; set; }
		public int expReward { get; set; }
		public string monsterImg {get;set;}


		public void ComputeLevel(int level) {
			hitPoints += level;
			minDamage += level;
		}
	}

	public class Aswang : Monster {
		public Aswang() {
			hitPoints = 20;
			minDamage = 1;
			maxDamage = 5;
			goldReward = 30;
			expReward = 30;
			monsterImg = "dwende";
			monsterType = MONSTER_TYPE.ASWANG;
		}
	}

	public class Dracula : Monster {
		public Dracula() {
			hitPoints = 20;
			minDamage = 1;
			maxDamage = 5;
			goldReward = 30;
			expReward = 30;
			monsterImg = "dwende";
			monsterType = MONSTER_TYPE.DRACULA;
		}
	}

	public class Dwende : Monster {
		public Dwende() {
			hitPoints = 20;
			minDamage = 1;
			maxDamage = 5;
			goldReward = 30;
			expReward = 30;
			monsterImg = "dwende";
			monsterType = MONSTER_TYPE.DWENDE;
		}

		public Dwende(int level) {
			hitPoints = 20;
			minDamage = 1;
			maxDamage = 5;
			goldReward = 30;
			expReward = 30;
			monsterImg = "dwende";
			monsterType = MONSTER_TYPE.DWENDE;
		}
	}

	public class Kapre : Monster {
		public Kapre() {
			hitPoints = 20;
			minDamage = 1;
			maxDamage = 5;
			goldReward = 30;
			expReward = 30;
			monsterImg = "dwende";
			monsterType = MONSTER_TYPE.KAPRE;
		}
	}

	public class Paniki : Monster {
		public Paniki() {
			hitPoints = 20;
			minDamage = 1;
			maxDamage = 5;
			goldReward = 30;
			expReward = 30;
			monsterImg = "dwende";
			monsterType = MONSTER_TYPE.PANIKI;
		}
	}

	public class Tikbalang : Monster {
		public Tikbalang() {
			hitPoints = 20;
			minDamage = 1;
			maxDamage = 5;
			goldReward = 30;
			expReward = 30;
			monsterImg = "dwende";
			monsterType = MONSTER_TYPE.TIKBALANG;
		}
	}

	public class Tiyanak : Monster {
		public Tiyanak() {
			hitPoints = 250;
			minDamage = 30;
			maxDamage = 80;
			goldReward = 100;
			expReward = 200;
			monsterImg = "tiyanak";
			monsterType = MONSTER_TYPE.TIYANAK;
		}
	}

	public class Uwak : Monster {
		public Uwak() {
			hitPoints = 20;
			minDamage = 1;
			maxDamage = 5;
			goldReward = 30;
			expReward = 30;
			monsterImg = "dwende";
			monsterType = MONSTER_TYPE.UWAK;
		}
	}

	public class WhiteLady : Monster {
		public WhiteLady() {
			hitPoints = 20;
			minDamage = 1;
			maxDamage = 5;
			goldReward = 30;
			expReward = 30;
			monsterImg = "dwende";
			monsterType = MONSTER_TYPE.WHITE_LADY;
		}
	}
}


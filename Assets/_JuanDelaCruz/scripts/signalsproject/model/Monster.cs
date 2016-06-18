using System;

namespace JuanDelaCruz {
	
	public class Monster : IMonster {
		
		public int level {get;set;}
		public int hitPoints { get; set; }
		public MONSTER_TYPE monsterType { get; set; }
		public int minDamage { get; set; }
		public int maxDamage { get; set; }
		public int goldReward { get; set; }
		public int expReward { get; set; }
		public string monsterImg {get;set;}


		public void ComputeLevel(int level) {
			this.level = level;
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
			hitPoints = 5;
			minDamage = 1;
			maxDamage = 3;
			goldReward = 5;
			expReward = 3;
			monsterImg = "dwende";
			monsterType = MONSTER_TYPE.DWENDE;
		}

		public Dwende(int level) {
			hitPoints = 5;
			minDamage = 1;
			maxDamage = 3;
			goldReward = 5;
			expReward = 2;
			monsterImg = "dwende";
			monsterType = MONSTER_TYPE.DWENDE;
			ComputeLevel(level);
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
			monsterImg = "tikbalang";
			monsterType = MONSTER_TYPE.TIKBALANG;
		}
		public Tikbalang(int level) {
			hitPoints = 45;
			minDamage = 7;
			maxDamage = 14;
			goldReward = 50;
			expReward = 30;
			monsterImg = "tikbalang";
			monsterType = MONSTER_TYPE.TIKBALANG;
			ComputeLevel(level);
		}
	}

	public class Tiyanak : Monster {
		public Tiyanak() {
			hitPoints = 30;
			minDamage = 4;
			maxDamage = 9;
			goldReward = 50;
			expReward = 30;
			monsterImg = "tiyanak";
			monsterType = MONSTER_TYPE.TIYANAK;
		}
		public Tiyanak(int level) {
			hitPoints = 30;
			minDamage = 4;
			maxDamage = 9;
			goldReward = 50;
			expReward = 30;
			monsterImg = "tiyanak";
			monsterType = MONSTER_TYPE.TIYANAK;
			ComputeLevel(level);
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
			hitPoints = 15;
			minDamage = 2;
			maxDamage = 4;
			goldReward = 15;
			expReward = 7;
			monsterImg = "whitelady";
			monsterType = MONSTER_TYPE.WHITE_LADY;
		}
		public WhiteLady(int level) {
			hitPoints = 15;
			minDamage = 2;
			maxDamage = 4;
			goldReward = 15;
			expReward = 7;
			monsterImg = "whitelady";
			monsterType = MONSTER_TYPE.WHITE_LADY;
			ComputeLevel(level);
		}
	}
}


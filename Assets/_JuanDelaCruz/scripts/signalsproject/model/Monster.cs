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
			maxDamage += level;
			goldReward += level;
			expReward += level;
		}
	}

	public class Aswang : Monster {
		public Aswang() {
			hitPoints = 180;
			minDamage = 28;
			maxDamage = 40;
			goldReward = 60;
			expReward = 50;
			monsterImg = "aswang";
			monsterType = MONSTER_TYPE.ASWANG;
		}
		public Aswang(int level) {
			hitPoints = 180;
			minDamage = 28;
			maxDamage = 40;
			goldReward = 60;
			expReward = 50;
			monsterImg = "aswang";
			monsterType = MONSTER_TYPE.ASWANG;
			ComputeLevel(level);
		}
	}

	public class Dracula : Monster {
		public Dracula() {
			hitPoints = 90;
			minDamage = 14;
			maxDamage = 20;
			goldReward = 45;
			expReward = 35;
			monsterImg = "dracula";
			monsterType = MONSTER_TYPE.DRACULA;
		}
		public Dracula(int level) {
			hitPoints = 90;
			minDamage = 14;
			maxDamage = 20;
			goldReward = 45;
			expReward = 35;
			monsterImg = "dracula";
			monsterType = MONSTER_TYPE.DRACULA;
			ComputeLevel(level);
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
			expReward = 3;
			monsterImg = "dwende";
			monsterType = MONSTER_TYPE.DWENDE;
			ComputeLevel(level);
		}
	}

	public class Kapre : Monster {
		public Kapre() {
			hitPoints = 60;
			minDamage = 8;
			maxDamage = 18;
			goldReward = 50;
			expReward = 40;
			monsterImg = "kapre";
			monsterType = MONSTER_TYPE.KAPRE;
		}
		public Kapre(int level) {
			hitPoints = 60;
			minDamage = 8;
			maxDamage = 18;
			goldReward = 50;
			expReward = 40;
			monsterImg = "kapre";
			monsterType = MONSTER_TYPE.KAPRE;
			ComputeLevel(level);
		}
	}

	public class Paniki : Monster {
		public Paniki() {
			hitPoints = 30;
			minDamage = 4;
			maxDamage = 8;
			goldReward = 20;
			expReward = 14;
			monsterImg = "paniki";
			monsterType = MONSTER_TYPE.PANIKI;
		}
		public Paniki(int level) {
			hitPoints = 30;
			minDamage = 4;
			maxDamage = 8;
			goldReward = 20;
			expReward = 14;
			monsterImg = "paniki";
			monsterType = MONSTER_TYPE.PANIKI;
			ComputeLevel(level);
		}
	}

	public class Tikbalang : Monster {
		public Tikbalang() {
			hitPoints = 45;
			minDamage = 7;
			maxDamage = 14;
			goldReward = 35;
			expReward = 30;
			monsterImg = "tikbalang";
			monsterType = MONSTER_TYPE.TIKBALANG;
		}
		public Tikbalang(int level) {
			hitPoints = 45;
			minDamage = 7;
			maxDamage = 14;
			goldReward = 35;
			expReward = 30;
			monsterImg = "tikbalang";
			monsterType = MONSTER_TYPE.TIKBALANG;
			ComputeLevel(level);
		}
	}

	public class Tiyanak : Monster {
		public Tiyanak() {
			hitPoints = 20;
			minDamage = 1;
			maxDamage = 3;
			goldReward = 25;
			expReward = 20;
			monsterImg = "tiyanak";
			monsterType = MONSTER_TYPE.TIYANAK;
		}
		public Tiyanak(int level) {
			hitPoints = 20;
			minDamage = 1;
			maxDamage = 3;
			goldReward = 25;
			expReward = 20;
			monsterImg = "tiyanak";
			monsterType = MONSTER_TYPE.TIYANAK;
			ComputeLevel(level);
		}
	}

	public class Uwak : Monster {
		public Uwak() {
			hitPoints = 20;
			minDamage = 2;
			maxDamage = 6;
			goldReward = 10;
			expReward = 4;
			monsterType = MONSTER_TYPE.UWAK;
		}
		public Uwak(int level) {
			hitPoints = 20;
			minDamage = 2;
			maxDamage = 6;
			goldReward = 10;
			expReward = 4;
			monsterImg = "uwak";
			monsterType = MONSTER_TYPE.UWAK;
			ComputeLevel(level);
		}
	}

	public class WhiteLady : Monster {
		public WhiteLady() {
			hitPoints = 15;
			minDamage = 1;
			maxDamage = 3;
			goldReward = 15;
			expReward = 7;
			monsterImg = "whitelady";
			monsterType = MONSTER_TYPE.WHITE_LADY;
		}
		public WhiteLady(int level) {
			hitPoints = 15;
			minDamage = 1;
			maxDamage = 3;
			goldReward = 15;
			expReward = 7;
			monsterImg = "whitelady";
			monsterType = MONSTER_TYPE.WHITE_LADY;
			ComputeLevel(level);
		}
	}
}


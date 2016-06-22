using System;
using UnityEngine;

namespace JuanDelaCruz {
	
	public class Stage : IStage {
		
		public int level { get; set; }
		public Monster[] monsters { get; set; }


		public Stage() {
//			level = 1;
//			CreateLevel();
		}

		public Stage(int level) {
			this.level = level;
			CreateLevel(1);
		}

		public void LoadStage(int level, int playerLevel) {
			this.level = level;
			CreateLevel(playerLevel);
		}

		private void CreateLevel(int playerLevel) {
			int minionLevelMaxRange =  playerLevel + 2;
			int bossLevelMaxRange =  playerLevel + 3;
			switch (level) {
			case 1:
				monsters = new Monster[5];
				monsters [0] = new Dwende (UnityEngine.Random.Range (playerLevel, minionLevelMaxRange));
				monsters [0].name = "Minion 1";
				monsters [1] = new Dwende(UnityEngine.Random.Range(playerLevel, minionLevelMaxRange));
				monsters [1].name = "Minion 2";
				monsters [2] = new Dwende(UnityEngine.Random.Range(playerLevel, minionLevelMaxRange));
				monsters [2].name = "Minion 3";
				monsters [3] = new WhiteLady(UnityEngine.Random.Range(playerLevel, minionLevelMaxRange));
				monsters [3].name = "Minion 4";
				monsters [4] = new Tiyanak(UnityEngine.Random.Range(playerLevel + 1, bossLevelMaxRange));
				monsters [4].name = "Boss";
				break;
			case 2:
				monsters = new Monster[5];
				monsters [0] = new Dwende(UnityEngine.Random.Range(playerLevel, minionLevelMaxRange));
				monsters [0].name = "Minion 1";
				monsters [1] = new Dwende(UnityEngine.Random.Range(playerLevel, minionLevelMaxRange));
				monsters [1].name = "Minion 2";
				monsters [2] = new WhiteLady(UnityEngine.Random.Range(playerLevel, minionLevelMaxRange));
				monsters [2].name = "Minion 3";
				monsters [3] = new WhiteLady(UnityEngine.Random.Range(playerLevel, minionLevelMaxRange));
				monsters [3].name = "Minion 4";
				monsters [4] = new Tikbalang(UnityEngine.Random.Range(playerLevel + 1, bossLevelMaxRange));
				monsters [4].name = "Boss";
				break;
			case 3:
				monsters = new Monster[5];
				monsters [0] = new Uwak(UnityEngine.Random.Range(playerLevel, minionLevelMaxRange));
				monsters [0].name = "Minion 1";
				monsters [1] = new Uwak(UnityEngine.Random.Range(playerLevel, minionLevelMaxRange));
				monsters [1].name = "Minion 2";
				monsters [2] = new Uwak(UnityEngine.Random.Range(playerLevel, minionLevelMaxRange));
				monsters [2].name = "Minion 3";
				monsters [3] = new Paniki(UnityEngine.Random.Range(playerLevel, minionLevelMaxRange));
				monsters [3].name = "Minion 4";
				monsters [4] = new Kapre(UnityEngine.Random.Range(playerLevel + 1, bossLevelMaxRange));
				monsters [4].name = "Boss";
				break;
			case 4:
				monsters = new Monster[5];
				monsters [0] = new Uwak(UnityEngine.Random.Range(playerLevel, minionLevelMaxRange));
				monsters [0].name = "Minion 1";
				monsters [1] = new Uwak(UnityEngine.Random.Range(playerLevel, minionLevelMaxRange));
				monsters [1].name = "Minion 2";
				monsters [2] = new Paniki(UnityEngine.Random.Range(playerLevel, minionLevelMaxRange));
				monsters [2].name = "Minion 3";
				monsters [3] = new Paniki(UnityEngine.Random.Range(playerLevel, minionLevelMaxRange));
				monsters [3].name = "Minion 4";
				monsters [4] = new Dracula(UnityEngine.Random.Range(playerLevel + 1, bossLevelMaxRange));
				monsters [4].name = "Boss";
				break;
			case 5:
				monsters = new Monster[5];
				monsters [0] = new Tiyanak(UnityEngine.Random.Range(playerLevel + 1, bossLevelMaxRange));
				monsters [0].name = "Minion 1";
				monsters [1] = new Tikbalang(UnityEngine.Random.Range(playerLevel + 1, bossLevelMaxRange));
				monsters [1].name = "Minion 2";
				monsters [2] = new Kapre(UnityEngine.Random.Range(playerLevel + 1, bossLevelMaxRange));
				monsters [2].name = "Minion 3";
				monsters [3] = new Dracula(UnityEngine.Random.Range(playerLevel + 1, bossLevelMaxRange));
				monsters [3].name = "Minion 4";
				monsters [4] = new Aswang(UnityEngine.Random.Range(playerLevel + 1, bossLevelMaxRange));
				monsters [4].name = "Boss";
				break;
			}

		}


	}

}


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
			CreateLevel();
		}

		public void LoadStage(int level) {
			this.level = level;
			CreateLevel();
		}

		private void CreateLevel() {
			switch (level) {
			case 1:
				monsters = new Monster[5];
				monsters [0] = new Dwende();
				monsters [1] = new Monster ();
				monsters [1].hitPoints = 50;
				monsters [1].minDamage = 5;
				monsters [1].maxDamage = 20;
				monsters [1].goldReward = 35;
				monsters [1].expReward = 40;
				monsters [2] = new Monster ();
				monsters [2].hitPoints = 80;
				monsters [2].minDamage = 10;
				monsters [2].maxDamage = 30;
				monsters [2].goldReward = 45;
				monsters [2].expReward = 60;
				monsters [3] = new Monster ();
				monsters [3].hitPoints = 100;
				monsters [3].minDamage = 15;
				monsters [3].maxDamage = 40;
				monsters [3].goldReward = 60;
				monsters [3].expReward = 90;
				monsters [4] = new Tiyanak();
				Debug.Log ("MONSTER CREATED");
				break;
			case 2:
				monsters = new Monster[5];
				monsters [0] = new Monster ();
				monsters [0].hitPoints = 1;
				monsters [0].minDamage = 1;
				monsters [0].maxDamage = 5;
				monsters [0].goldReward = 30;
				monsters [0].expReward = 30;
				monsters [1] = new Monster ();
				monsters [1].hitPoints = 1;
				monsters [1].minDamage = 5;
				monsters [1].maxDamage = 20;
				monsters [1].goldReward = 35;
				monsters [1].expReward = 40;
				monsters [2] = new Monster ();
				monsters [2].hitPoints = 1;
				monsters [2].minDamage = 10;
				monsters [2].maxDamage = 30;
				monsters [2].goldReward = 45;
				monsters [2].expReward = 60;
				monsters [3] = new Monster ();
				monsters [3].hitPoints = 1;
				monsters [3].minDamage = 15;
				monsters [3].maxDamage = 40;
				monsters [3].goldReward = 60;
				monsters [3].expReward = 90;
				monsters [4] = new Monster ();
				monsters [4].hitPoints = 1;
				monsters [4].minDamage = 30;
				monsters [4].maxDamage = 80;
				monsters [4].goldReward = 100;
				monsters [4].expReward = 200;
				Debug.Log ("MONSTER CREATED");
				break;
			case 3:
				monsters = new Monster[5];
				monsters [0] = new Monster ();
				monsters [0].hitPoints = 1;
				monsters [0].minDamage = 1;
				monsters [0].maxDamage = 5;
				monsters [0].goldReward = 30;
				monsters [0].expReward = 30;
				monsters [1] = new Monster ();
				monsters [1].hitPoints = 1;
				monsters [1].minDamage = 5;
				monsters [1].maxDamage = 20;
				monsters [1].goldReward = 35;
				monsters [1].expReward = 40;
				monsters [2] = new Monster ();
				monsters [2].hitPoints = 1;
				monsters [2].minDamage = 10;
				monsters [2].maxDamage = 30;
				monsters [2].goldReward = 45;
				monsters [2].expReward = 60;
				monsters [3] = new Monster ();
				monsters [3].hitPoints = 1;
				monsters [3].minDamage = 15;
				monsters [3].maxDamage = 40;
				monsters [3].goldReward = 60;
				monsters [3].expReward = 90;
				monsters [4] = new Monster ();
				monsters [4].hitPoints = 1;
				monsters [4].minDamage = 30;
				monsters [4].maxDamage = 80;
				monsters [4].goldReward = 100;
				monsters [4].expReward = 200;
				Debug.Log ("MONSTER CREATED");
				break;
			case 4:
				monsters = new Monster[5];
				monsters [0] = new Monster ();
				monsters [0].hitPoints = 1;
				monsters [0].minDamage = 1;
				monsters [0].maxDamage = 5;
				monsters [0].goldReward = 30;
				monsters [0].expReward = 30;
				monsters [1] = new Monster ();
				monsters [1].hitPoints = 1;
				monsters [1].minDamage = 5;
				monsters [1].maxDamage = 20;
				monsters [1].goldReward = 35;
				monsters [1].expReward = 40;
				monsters [2] = new Monster ();
				monsters [2].hitPoints = 1;
				monsters [2].minDamage = 10;
				monsters [2].maxDamage = 30;
				monsters [2].goldReward = 45;
				monsters [2].expReward = 60;
				monsters [3] = new Monster ();
				monsters [3].hitPoints = 1;
				monsters [3].minDamage = 15;
				monsters [3].maxDamage = 40;
				monsters [3].goldReward = 60;
				monsters [3].expReward = 90;
				monsters [4] = new Monster ();
				monsters [4].hitPoints = 1;
				monsters [4].minDamage = 30;
				monsters [4].maxDamage = 80;
				monsters [4].goldReward = 100;
				monsters [4].expReward = 200;
				Debug.Log ("MONSTER CREATED");
				break;
			case 5:
				monsters = new Monster[5];
				monsters [0] = new Monster ();
				monsters [0].hitPoints = 1;
				monsters [0].minDamage = 1;
				monsters [0].maxDamage = 5;
				monsters [0].goldReward = 30;
				monsters [0].expReward = 30;
				monsters [1] = new Monster ();
				monsters [1].hitPoints = 1;
				monsters [1].minDamage = 5;
				monsters [1].maxDamage = 20;
				monsters [1].goldReward = 35;
				monsters [1].expReward = 40;
				monsters [2] = new Monster ();
				monsters [2].hitPoints = 1;
				monsters [2].minDamage = 10;
				monsters [2].maxDamage = 30;
				monsters [2].goldReward = 45;
				monsters [2].expReward = 60;
				monsters [3] = new Monster ();
				monsters [3].hitPoints = 1;
				monsters [3].minDamage = 15;
				monsters [3].maxDamage = 40;
				monsters [3].goldReward = 60;
				monsters [3].expReward = 90;
				monsters [4] = new Monster ();
				monsters [4].hitPoints = 1;
				monsters [4].minDamage = 30;
				monsters [4].maxDamage = 80;
				monsters [4].goldReward = 100;
				monsters [4].expReward = 200;
				Debug.Log ("MONSTER CREATED");
				break;
			}

		}


	}

}


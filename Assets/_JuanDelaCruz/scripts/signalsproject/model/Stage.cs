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

		private void CreateLevel() {
			Debug.Log (level);
			switch (level) {
			case 1:
				monsters = new Monster[5];
				monsters [0] = new Monster ();
				monsters [0].hitPoints = 20;
				monsters [0].minDamage = 1;
				monsters [0].maxDamage = 5;
//				monsters [1].hitPoints = 50;
//				monsters [2].hitPoints = 80;
//				monsters [3].hitPoints = 100;
//				monsters [4].hitPoints = 250;
				Debug.Log ("MONSTER CREATED");
				break;
			}
		}


	}

}


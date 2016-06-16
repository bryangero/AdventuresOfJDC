using System;
using UnityEngine;

namespace JuanDelaCruz {
	
	public class Player : IPlayer {
		
		public string name { get; set; }
		public int level { get; set; }
		public int stage { get; set; }
		public WEAPON_TYPE weapon { get; set; }
		public int gold { get; set; }
		public int currentExperience { get; set; }
		public int experienceNeeded { get; set; }
		public int hitPoints { get; set; }
		public int minDamage { get; set; }
		public int maxDamage { get; set; }
		public int lives { get; set; }

		public Player() {
			name = "Juan";
			stage = 1;
			level = 1;
			weapon = WEAPON_TYPE.NONE;
			ComputeHp();
		}

		public void SavePlayer() {
			string serializedPlayer = JsonFx.Json.JsonWriter.Serialize(this);
			PlayerPrefs.SetString("PLAYER", serializedPlayer);
			Debug.Log("SAVED Player");
		}

		public void LoadPlayer() {
			string playerPrefs;
			Player temp = new Player();
			if(PlayerPrefs.HasKey("PLAYER")) {
				playerPrefs = PlayerPrefs.GetString("PLAYER");
				temp = JsonFx.Json.JsonReader.Deserialize<Player>(playerPrefs);
				Debug.Log (playerPrefs);
			} 
			name = temp.name;
			stage = temp.stage;
			weapon = temp.weapon;
			level = temp.level;
			currentExperience = temp.currentExperience;
			experienceNeeded = temp.experienceNeeded;
			ComputeHp();
		}

		public void ReplenishLives() {
			lives = 3;
		}

		public bool ReduceLives(int val) {
			int tempLives = lives - val;
			if (tempLives <= 0) {
				return false;
			}
			return true;	
		}

		public void IncreaseExperience(int exp) {
			currentExperience += exp;
			if (currentExperience >= experienceNeeded) {
				int extraExp = currentExperience - experienceNeeded;
				currentExperience = 0;
				level++;
				ComputeHp();
				IncreaseExperience(extraExp);
				Debug.Log ("LEVEL UP");
			}
		}

		public void IncreaseGold(int gold) {
			this.gold += gold;
		}

		public bool DecreaseGold(int gold) {
			int newGoldVal = this.gold - gold;
			if (newGoldVal < 0) {
				Debug.Log ("NOT ENOUGH GOLD");
				return false;
			} else {
				gold = newGoldVal;
				return true;
			}
			return false;
		}

		private void ComputeHp() {
			switch(level) {
			case 1:
				hitPoints = 30;
				experienceNeeded = 30;
				minDamage = 5;
				maxDamage = 15;
				break;
			case 2:
				hitPoints = 50;
				experienceNeeded = 100;
				minDamage = 10;
				maxDamage = 20;
				break;
			case 3:
				hitPoints = 60;
				experienceNeeded = 200;
				minDamage = 15;
				maxDamage = 25;
				break;
			case 4:
				hitPoints = 70;
				experienceNeeded = 300;
				minDamage = 20;
				maxDamage = 30;
				break;
			case 5:
				hitPoints = 85;
				experienceNeeded = 400;
				minDamage = 25;
				maxDamage = 35;
				break;
			case 6:
				hitPoints = 100;
				experienceNeeded = 500;
				minDamage = 30;
				maxDamage = 40;
				break;
			case 7:
				hitPoints = 115;
				experienceNeeded = 600;
				minDamage = 35;
				maxDamage = 45;
				break;
			case 8:
				hitPoints = 140;
				experienceNeeded = 700;
				minDamage = 40;
				maxDamage = 50;
				break;
			case 9:
				hitPoints = 170;
				experienceNeeded = 800;
				minDamage = 45;
				maxDamage = 55;
				break;
			case 10:
				hitPoints = 200;
				experienceNeeded = 900;
				minDamage = 50;
				maxDamage = 60;
				break;
			case 11:
				hitPoints = 240;
				experienceNeeded = 1000;
				minDamage = 55;
				maxDamage = 65;
				break;
			case 12:
				hitPoints = 270;
				experienceNeeded = 1100;
				minDamage = 60;
				maxDamage = 70;
				break;
			case 13:
				hitPoints = 310;
				experienceNeeded = 1200;
				minDamage = 65;
				maxDamage = 75;
				break;
			case 14:
				hitPoints = 360;
				experienceNeeded = 1300;
				minDamage = 70;
				maxDamage = 80;
				break;
			case 15:
				hitPoints = 420;
				experienceNeeded = -1;
				minDamage = 75;
				maxDamage = 85;
				break;
			}
		}
	}
}


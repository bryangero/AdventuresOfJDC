using System;
using UnityEngine;

namespace JuanDelaCruz {
	
	public class Player : IPlayer {
		
		public string name { get; set; }
		public int level { get; set; }
		public int stage { get; set; }
		public WEAPON_TYPE weapon { get; set; }
		public bool[] weaponsBought { get; set; }
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
			weaponsBought =  new bool[6];
			for (int i = 0; i < weaponsBought.Length; i++) {
				weaponsBought[i] = false;
				if (i == (int)weapon) {
					weaponsBought[i] = true;
				}
			}
			ComputeHp();
		}

		public Player(int level) {
			name = "Juan";
			stage = 1;
			this.level = level;
			weapon = WEAPON_TYPE.NONE;
			weaponsBought =  new bool[6];
			for (int i = 0; i < weaponsBought.Length; i++) {
				weaponsBought[i] = false;
				if (i == (int)weapon) {
					weaponsBought[i] = true;
				}
			}
			ComputeHp();
		}

		public Player(int level, WEAPON_TYPE weapon) {
			name = "Juan";
			stage = 1;
			this.level = level;
			this.weapon = weapon;
			weaponsBought =  new bool[6];
			for (int i = 0; i < weaponsBought.Length; i++) {
				weaponsBought[i] = false;
				if (i == (int)weapon) {
					weaponsBought[i] = true;
				}
			}
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
			weaponsBought = temp.weaponsBought;
			gold = temp.gold;
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
				this.gold = newGoldVal;
				return true;
			}
			return false;
		}

		private void ComputeHp() {
			switch(level) {
			case 1:
				hitPoints = 10;
				experienceNeeded = 10;
				minDamage = 3;
				maxDamage = 5;
				break;
			case 2:
				hitPoints = 15;
				experienceNeeded = 25;
				minDamage = 4;
				maxDamage = 7;
				break;
			case 3:
				hitPoints = 20;
				experienceNeeded = 35;
				minDamage = 5;
				maxDamage = 10;
				break;
			case 4:
				hitPoints = 25;
				experienceNeeded = 45;
				minDamage = 7;
				maxDamage = 13;
				break;
			case 5:
				hitPoints = 30;
				experienceNeeded = 55;
				minDamage = 8;
				maxDamage = 15;
				break;
			case 6:
				hitPoints = 35;
				experienceNeeded = 65;
				minDamage = 9;
				maxDamage = 18;
				break;
			case 7:
				hitPoints = 40;
				experienceNeeded = 75;
				minDamage = 10;
				maxDamage = 20;
				break;
			case 8:
				hitPoints = 45;
				experienceNeeded = 85;
				minDamage = 19;
				maxDamage = 23;
				break;
			case 9:
				hitPoints = 50;
				experienceNeeded = 95;
				minDamage = 18;
				maxDamage = 25;
				break;
			case 10:
				hitPoints = 55;
				experienceNeeded = 105;
				minDamage = 14;
				maxDamage = 28;
				break;
			case 11:
				hitPoints = 60;
				experienceNeeded = 115;
				minDamage = 15;
				maxDamage = 30;
				break;
			case 12:
				hitPoints = 65;
				experienceNeeded = 125;
				minDamage = 19;
				maxDamage = 33;
				break;
			case 13:
				hitPoints = 70;
				experienceNeeded = 135;
				minDamage = 18;
				maxDamage = 35;
				break;
			case 14:
				hitPoints = 75;
				experienceNeeded = 145;
				minDamage = 19;
				maxDamage = 38;
				break;
			case 15:
				hitPoints = 80;
				experienceNeeded = -1;
				minDamage = 20;
				maxDamage = 40;
				break;
			}
		}
	}
}


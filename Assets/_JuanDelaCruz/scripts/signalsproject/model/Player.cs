using System;
using UnityEngine;

namespace JuanDelaCruz {
	
	public class Player : IPlayer {
		
		public string name { get; set; }
		public GENDER gender { get; set; }
		public int stage { get; set; }
		public int hitPoints { get; set; }
		public int damage { get; set; }
		public WEAPON_TYPE weapon { get; set; }
		public int level { get; set; }
		public int currentExperience { get; set; }
		public int experienceNeeded { get; set; }

		public Player() {
			name = "noName";
		}

		public void SavePlayer() {
			string serializedPlayer = JsonFx.Json.JsonWriter.Serialize(this);
			Debug.Log(name);
			PlayerPrefs.SetString("PLAYER", serializedPlayer);
			Debug.Log("New Player Created");
		}

		public void LoadPlayer() {
			string playerPrefs;
			Player temp = new Player();
			if(PlayerPrefs.HasKey("PLAYER")) {
				playerPrefs = PlayerPrefs.GetString("PLAYER");
				temp = JsonFx.Json.JsonReader.Deserialize<Player>(playerPrefs);
			} 


			name = temp.name;
			gender = temp.gender;
			stage = temp.stage;
			hitPoints = temp.hitPoints;
			damage = temp.damage;
			weapon = temp.weapon;
			level = temp.level;
			currentExperience = temp.currentExperience;
			experienceNeeded = temp.experienceNeeded;
		}
	}

}


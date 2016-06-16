using System;

namespace JuanDelaCruz {
	
	public interface IPlayer {
		
		string name { get; set; }
		int level { get; set; }
		int stage { get; set; }
		WEAPON_TYPE weapon { get; set; }
		int gold { get; set; }
		int currentExperience { get; set; }
		int experienceNeeded { get; set; }
		int hitPoints { get; set; }
		int minDamage { get; set; }
		int maxDamage { get; set; }
		int lives { get; set; }

		void SavePlayer();
		void LoadPlayer();
		void IncreaseExperience(int exp);
		void IncreaseGold(int gold);
		bool DecreaseGold(int gold);
		void ReplenishLives();
		bool ReduceLives(int val);
	}

}


using System;

namespace JuanDelaCruz {
	
	public interface IPlayer {
		
		string name { get; set; }
		GENDER gender { get; set; }
		int stage { get; set; }

		int hitPoints { get; set; }
		int minDamage { get; set; }
		int maxDamage { get; set; }
		WEAPON_TYPE weapon { get; set; }
		int level { get; set; }
		int currentExperience { get; set; }
		int experienceNeeded { get; set; }
		int gold { get; set; }

		void SavePlayer();
		void LoadPlayer();

	}

}


using System;

namespace JuanDelaCruz {
	
	public class Player : IPlayer {
		
		public string name { get; set; }
		public string gender { get; set; }
		public int stage { get; set; }
		public int hitPoints { get; set; }
		public int damage { get; set; }
		public WEAPON_TYPE weapon { get; set; }
		public int currentExperience { get; set; }
	}

}


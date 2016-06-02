using System;

namespace JuanDelaCruz {
	
	public interface IStage {
		
		int level { get; set; }
		Monster[] monsters { get; set; }

		void LoadStage(int level);
	}

}


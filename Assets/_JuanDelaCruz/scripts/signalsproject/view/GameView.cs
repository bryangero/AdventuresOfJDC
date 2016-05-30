using System;
using System.Collections;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace JuanDelaCruz {

	public class GameView : View {

		[Inject]
		public IStage stage { get; set; }


		public GameObject holder;
		public GameObject gameUI;
		public GameObject rewardUI;
		public GameObject shopUI;
		public GameObject getHelpUI;

		public GameUIView gameUIView;

		internal void init() {
			stage = new Stage(1);
			Debug.Log (stage.monsters[0].hitPoints);

		}

		public void EnableGame() {
			holder.SetActive(true);
		}

		public void DisableGame() {
			holder.SetActive(false);
		}

		public void DealEnemyDamage(int damage) {
			
		}

	}

}


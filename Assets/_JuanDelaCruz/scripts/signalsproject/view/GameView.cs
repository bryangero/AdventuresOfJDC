using System;
using System.Collections;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace JuanDelaCruz {

	public class GameView : View {

		[Inject]
		public IPlayer player { get; set; }

		[Inject]
		public IStage stage { get; set; }

		public int round;
		public bool isRoundEnd = false;

		public GameObject holder;
		public GameUIView gameUIView;
		public RewardUIView rewardUIView;
		public ShopUIView shopUIView;
		public GameObject getHelpUI;

		internal void init() {
			player = new Player();
			stage = new Stage(1);
			round = 0;
			gameUIView.init(stage.monsters[round]);
		}

		public void EnableGame() {
			holder.SetActive(true);
		}

		public void DisableGame() {
			holder.SetActive(false);
		}

		public void OnFinishedRound(bool isWin) {
			if (isWin == true) {
				rewardUIView.init(stage.monsters[round].goldReward, stage.monsters[round].expReward);
			} else {
			}
		}

		public void OnFinishReward() {
			round++;
			if (round >= stage.monsters.Length) {
				Debug.Log("END OF STAGE");
				return;
			}

			if (round <= 3) {
				isRoundEnd = false;
				gameUIView.init(stage.monsters[round]);
			} else {
				shopUIView.init();
				Debug.Log("SHOP/NFC");
			}
		}


		public void OnFinishShop() {
			isRoundEnd = false;				
			gameUIView.init(stage.monsters[round]);
		}
	}

}


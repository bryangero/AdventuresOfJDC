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

		public Signal returnToMapSignal = new Signal();

		public int round;
		public bool isRoundEnd = false;

		public GameObject holder;
		public GameUIView gameUIView;
		public RewardUIView rewardUIView;
		public ShopUIView shopUIView;
		public GameObject getHelpUI;

		public SpriteRenderer currentStage;
		public Sprite[] stageBGs;

		internal void init() {
			currentStage.sprite = stageBGs[stage.level - 1];
			isRoundEnd = false;
			round = 0;
			EnableGame();
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
				DisableGame();
				rewardUIView.init(stage.monsters[round].goldReward, stage.monsters[round].expReward);
			} else {
				DisableGame();
				returnToMapSignal.Dispatch();
			}
		}

		public void OnFinishReward() {
			round++;
			if (round >= stage.monsters.Length) {
				DisableGame();
				if (player.stage == stage.level) {
					player.stage++;
					player.SavePlayer();
					Debug.Log ("NEXT STAGE UNLOCKED");
				} else {
					Debug.Log ("FINISHED ALREADY");
				}
				returnToMapSignal.Dispatch();
				return;
			}
			if (round <= 3) {
				player.SavePlayer();
				isRoundEnd = false;
				gameUIView.init(stage.monsters[round]);
				EnableGame();
			} else {
				DisableGame();
				shopUIView.init();
			}
		}


		public void OnFinishShop() {
			player.SavePlayer();
			isRoundEnd = false;
			gameUIView.init(stage.monsters[round]);
			EnableGame();
		}
	}

}


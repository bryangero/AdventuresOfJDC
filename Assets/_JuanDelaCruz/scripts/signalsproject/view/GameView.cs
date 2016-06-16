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
		public Signal displayContinueSignal = new Signal();

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
			player.lives = 3;
			EnableGame();
			gameUIView.init(stage.monsters[round]);
		}

		public void RestartRound() {
			isRoundEnd = false;
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
				player.lives--;
				if (player.lives < 0) {
					DisableGame();
					returnToMapSignal.Dispatch();
				} else {
					displayContinueSignal.Dispatch();
				}
			}
		}

		public void OnFinishReward() {
			StartCoroutine(OnFinishRewardInOrder());
		}

		public IEnumerator OnFinishRewardInOrder() {
			yield return null;
			round++;
			if (round >= stage.monsters.Length) {
				DisableGame();
				if (player.stage == stage.level) {
					player.stage++;
					yield return StartCoroutine(SavePlayer());
				} else {
					rewardUIView.DisableRewardUI();
					shopUIView.DisableShopUI();
				}
				returnToMapSignal.Dispatch();
			} else {
				if (round <= 3) {
					yield return StartCoroutine(SavePlayer());
					rewardUIView.DisableRewardUI();
					isRoundEnd = false;
					gameUIView.init(stage.monsters[round]);
					EnableGame();
				} else {
					DisableGame();
					shopUIView.init();
				}
			}
		}


		public void OnFinishShop() {
			StartCoroutine (OnFinishShopInOrder());
		}

		private IEnumerator OnFinishShopInOrder() {
			yield return StartCoroutine(SavePlayer());
			rewardUIView.DisableRewardUI();
			shopUIView.DisableShopUI();
			isRoundEnd = false;
			gameUIView.init(stage.monsters[round]);
			EnableGame();
		}

		public IEnumerator SavePlayer() {
			if (GameSparksManager.instance.isAvailable) {
				bool isRunning = true;
				player.SavePlayer();
				new GameSparks.Api.Requests.LogEventRequest().SetEventKey("SET_PLAYER").
				SetEventAttribute("NAME", player.name).
				SetEventAttribute("LEVEL", player.level).
				SetEventAttribute("STAGE", player.stage).
				SetEventAttribute("WEAPON_TYPE", (int)player.weapon).
				SetEventAttribute("GOLD", player.gold).
				SetEventAttribute("CURRENT_EXP", player.currentExperience).Send((response) => {
					if (!response.HasErrors) {
						isRunning = false;
						Debug.Log("Player Saved To GameSparks...");
					} else {
						isRunning = false;
						Debug.Log("Error Saving Player Data...");
					}
				});
				while (isRunning == true) {
					yield return null;
				}
			} else {
				player.SavePlayer();
			}
			yield return null;
		}



	}

}


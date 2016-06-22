using System;
using System.Collections;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using GameSparks.Api;
using GameSparks.Api.Messages;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Core;

namespace JuanDelaCruz {

	public class GameView : View {

		[Inject]
		public IPlayer player { get; set; }

		public Player helper;
		public GameObject helperGo;

		[Inject]
		public IStage stage { get; set; }

		public Signal returnToMapSignal = new Signal();
		public Signal displayContinueSignal = new Signal();

		public int round;
		public bool isRoundEnd = false;
		public bool isSaving = false;

		public GameObject holder;
		public GameUIView gameUIView;
		public RewardUIView rewardUIView;
		public ShopUIView shopUIView;
		public NeedHelpUIView needHelpUIView;

		public SpriteRenderer currentStage;
		public Sprite[] stageBGs;

		internal void init() {
			rewardUIView.DisableRewardUI ();
			shopUIView.DisableShopUI ();
			needHelpUIView.DisableNeedHelpUI ();
			currentStage.sprite = stageBGs[stage.level - 1];
			isRoundEnd = false;
			round = 0;
			player.lives = 3;
			helper = null;
			helperGo.SetActive(false);
			EnableGame();
			gameUIView.init(stage.monsters[round]);
		}

		public void RestartRound() {
			helper = null;
			helperGo.SetActive(false);
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
				if (player.lives <= 0) {
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
					SavePlayer();
					while (isSaving == true) {
						yield return null;
					}
					rewardUIView.DisableRewardUI();
				} else {
					rewardUIView.DisableRewardUI();
					shopUIView.DisableShopUI();
				}
				returnToMapSignal.Dispatch();
			} else {
				if (round <= 3) {
					SavePlayer();
					while (isSaving == true) {
						yield return null;
					}
					rewardUIView.DisableRewardUI();
					isRoundEnd = false;
					gameUIView.init(stage.monsters[round]);
					EnableGame();
				} else {
					DisableGame();
					rewardUIView.DisableRewardUI();
					shopUIView.init();
				}
			}
		}


		public void OnFinishShop() {
			StartCoroutine(OnFinishShopInOrder());
		}

		private IEnumerator OnFinishShopInOrder() {
			SavePlayer();
			while (isSaving == true) {
				yield return null;
			}
			rewardUIView.DisableRewardUI();
			shopUIView.DisableShopUI();
			needHelpUIView.EnableNeedHelpUI();
		}


		public void OnFinishNeedHelp(Player player = null) {
			rewardUIView.DisableRewardUI();
			shopUIView.DisableShopUI();
			needHelpUIView.DisableNeedHelpUI();
			isRoundEnd = false;
			if (player == null) {
				gameUIView.init(stage.monsters[round]);
			} else {
				helperGo.SetActive(true);
				gameUIView.init(stage.monsters[round], player);
			}
			EnableGame();
		}

		public void SavePlayer() {
			isSaving = true;
			if (GameSparksManager.instance.isConnected) {
				player.SavePlayer();
				GameSparksManager.instance.GsLogEventResponseEvt += AttemptSavePlayer;
				GameSparksManager.instance.SavePlayer(player);
			} else {
				player.SavePlayer();
				isSaving = false;
			}
		}

		public void AttemptSavePlayer(LogEventResponse response) {
			GameSparksManager.instance.GsLogEventResponseEvt -= AttemptSavePlayer;
			if (!response.HasErrors) {
				isSaving = false;
				Debug.Log("Player Saved To GameSparks...");
			} else {
				Debug.Log("Error Saving Player Data...");
			}
		}

	}

}


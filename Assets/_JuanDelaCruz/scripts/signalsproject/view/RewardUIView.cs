using System;
using System.Collections;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace JuanDelaCruz {

	public class RewardUIView : View {

		[Inject]
		public IPlayer player {get;set;}

		[SerializeField] GameObject holder;
		public GameView gameView;
		public UILabel goldRewardLabel;
		public UILabel expRewardLabel;

		public UILabel playerLevelLabel;
		public UILabel playerGoldLabel;

		public void EnableRewardUI() {
			holder.SetActive(true);
		}

		public void DisableRewardUI() {
			holder.SetActive(false);
		}

		internal void init(int goldReward, int expReward) {
			EnableRewardUI();
			iTween.ValueTo(gameObject, iTween.Hash(
				"from", 0,
				"to", goldReward, 
				"onupdatetarget", gameObject,
				"onupdate", "UpdateGoldLabelValue",
				"time", 1));

			iTween.ValueTo(gameObject, iTween.Hash(
				"from", 0,
				"to", expReward, 
				"onupdatetarget", gameObject,
				"onupdate", "UpdateExperienceLabelValue",
				"time", 1));

			player.IncreaseExperience(expReward);
			player.IncreaseGold(goldReward);
			playerLevelLabel.text = "Player Level: " + player.level + "\nPlayer Current Exp: " + player.currentExperience;
			playerGoldLabel.text = "Player Gold: " + player.gold;
		}

		public void UpdateGoldLabelValue(int val) {
			goldRewardLabel.text = val.ToString();
		} 

		public void UpdateExperienceLabelValue(int val) {
			expRewardLabel.text = val.ToString();
		} 

		public void OnClickClaim() {
			gameView.OnFinishReward();
		}

	}

}


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

			player.currentExperience += expReward;
			player.gold += goldReward;
		}

		public void UpdateGoldLabelValue(int val) {
			goldRewardLabel.text = val.ToString();
		} 

		public void UpdateExperienceLabelValue(int val) {
			expRewardLabel.text = val.ToString();
		} 

		public void OnClickClaim() {
			gameView.OnFinishReward();
			DisableRewardUI();
		}

	}

}


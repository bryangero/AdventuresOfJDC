using System;
using System.Collections;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace JuanDelaCruz {

	public class RewardUIView : View {

		[SerializeField] GameObject holder;
		public Signal claimRewardSignal = new Signal();

		internal void init() {
		}

		public void EnableRewardUI() {
			holder.SetActive(true);
		}

		public void DisableRewardUI() {
			holder.SetActive(false);
		}

		public void OnClickClaim() {
			claimRewardSignal.Dispatch();
		}

	}

}


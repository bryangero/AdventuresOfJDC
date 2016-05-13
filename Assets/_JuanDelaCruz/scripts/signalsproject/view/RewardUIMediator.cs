/// Example mediator
/// =====================
/// Note how we no longer extend EventMediator, and inject Signals instead

using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace JuanDelaCruz {
	//Not extending EventMediator anymore
	public class RewardUIMediator : Mediator {
		[Inject]
		public RewardUIView view { get; set; }

		[Inject]
		public ShowWindowSignal showWindowSignal { get; set; }

		public override void OnRegister() {
			view.claimRewardSignal.AddListener(ClickClaim);
			view.init();
		}
		
		public override void OnRemove() {
			view.claimRewardSignal.RemoveListener(ClickClaim);
		}

		private void ClickClaim() {
			showWindowSignal.Dispatch(GAME_WINDOWS.SHOP);
		}
	}
}


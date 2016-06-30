/// Example mediator
/// =====================
/// Note how we no longer extend EventMediator, and inject Signals instead

using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace JuanDelaCruz {
	//Not extending EventMediator anymore
	public class CongratulationsUIMediator : Mediator {
		[Inject]
		public CongratulationsUIView view { get; set; }

		[Inject]
		public ShowWindowSignal showWindowSignal { get; set; }

		public override void OnRegister() {
			view.showWindowSignal.AddListener (OnViewShowWindow);
		}

		public override void OnRemove() {
			view.showWindowSignal.RemoveListener (OnViewShowWindow);
		}

		private void OnViewShowWindow(GAME_WINDOWS gameWindow) {
			showWindowSignal.Dispatch (gameWindow);
		}

	}
}


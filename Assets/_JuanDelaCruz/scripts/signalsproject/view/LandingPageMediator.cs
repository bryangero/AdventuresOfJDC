/// Example mediator
/// =====================
/// Note how we no longer extend EventMediator, and inject Signals instead

using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace JuanDelaCruz {
	//Not extending EventMediator anymore
	public class LandingPageMediator : Mediator {
		[Inject]
		public LandingPageView view{ get; set; }

		[Inject]
		public ShowWindowSignal showWindowSignal { get; set; }
		
		public override void OnRegister() {
			showWindowSignal.AddListener(OnShowWindow);
			view.clickNewGameSignal.AddListener(ClickNewGame);
		}
		
		public override void OnRemove() {
			showWindowSignal.RemoveListener(OnShowWindow);
			view.clickNewGameSignal.RemoveListener(ClickNewGame);
		}

		private void ClickNewGame() {
			showWindowSignal.Dispatch(GAME_WINDOWS.CHARACTER_SELECT);
		}

		private void OnShowWindow(GAME_WINDOWS gameWindow) {
			Debug.Log(name + " " + gameWindow);
		}

	}
}


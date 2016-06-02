/// Example mediator
/// =====================
/// Note how we no longer extend EventMediator, and inject Signals instead

using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace JuanDelaCruz {
	//Not extending EventMediator anymore
	public class GameMediator : Mediator {
		[Inject]
		public GameView view { get; set; }

		[Inject]
		public ShowWindowSignal showWindowSignal { get; set; }

		public override void OnRegister() {
			view.returnToMapSignal.AddListener(OnReturnToMapSignal);
		}
		
		public override void OnRemove() {
			view.returnToMapSignal.RemoveListener(OnReturnToMapSignal);
		}

		public void OnReturnToMapSignal() {
			showWindowSignal.Dispatch (GAME_WINDOWS.MAP);
		}


	}
}


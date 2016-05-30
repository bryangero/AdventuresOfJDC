/// Example mediator
/// =====================
/// Note how we no longer extend EventMediator, and inject Signals instead

using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace JuanDelaCruz {
	//Not extending EventMediator anymore
	public class GameUIMediator : Mediator {
		[Inject]
		public GameUIView view { get; set; }

		[Inject]
		public ShowWindowSignal showWindowSignal { get; set; }
		
		public override void OnRegister() {
			view.endBattleSignal.AddListener(EndBattleSignal);
		}
		
		public override void OnRemove() {
			view.endBattleSignal.RemoveListener(EndBattleSignal);
		}

		private void EndBattleSignal() {
			showWindowSignal.Dispatch(GAME_WINDOWS.REWARD);
		} 

	}
}


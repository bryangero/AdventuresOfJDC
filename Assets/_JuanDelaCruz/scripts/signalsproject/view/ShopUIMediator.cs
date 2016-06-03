/// Example mediator
/// =====================
/// Note how we no longer extend EventMediator, and inject Signals instead

using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace JuanDelaCruz {
	//Not extending EventMediator anymore
	public class ShopUIMediator : Mediator {
		[Inject]
		public ShopUIView view { get; set; }
		
		[Inject]
		public LoadDialogueBoxSignal loadDialogueBoxSignal { get; set; }

		public override void OnRegister() {
			view.notEnoughGold.AddListener (OnNotEnoughGold);
		}
		
		public override void OnRemove() {
			view.notEnoughGold.RemoveListener (OnNotEnoughGold);
		}

		public void OnNotEnoughGold() {
			loadDialogueBoxSignal.Dispatch (DIALOGUE_TYPE.OK, "Not enough gold.");
		}
		
	}
}


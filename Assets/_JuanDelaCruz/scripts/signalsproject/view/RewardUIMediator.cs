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
		}
		
		public override void OnRemove() {
		}

	}
}


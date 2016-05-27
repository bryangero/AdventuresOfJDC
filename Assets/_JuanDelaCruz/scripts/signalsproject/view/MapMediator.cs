/// Example mediator
/// =====================
/// Note how we no longer extend EventMediator, and inject Signals instead

using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace JuanDelaCruz {
	//Not extending EventMediator anymore
	public class MapMediator : Mediator {
		
		[Inject]
		public MapView view { get; set; }

		[Inject]
		public ShowWindowSignal showWindowSignal { get; set; }

		[Inject]
		public IPlayer player { get; set; }
		
		public override void OnRegister() {
			view.init();
		}
		
		public override void OnRemove() {
		}


	}
}


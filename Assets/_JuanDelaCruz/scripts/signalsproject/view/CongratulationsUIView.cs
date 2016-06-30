using System;
using System.Collections;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace JuanDelaCruz {

	public class CongratulationsUIView : View {


		[SerializeField] GameObject holder;

		public Signal<GAME_WINDOWS> showWindowSignal = new Signal<GAME_WINDOWS> ();

		public void EnableCongratulationsUI() {
			holder.SetActive(true);
		}

		public void DisableCongratulationsUI() {
			holder.SetActive(false);
		}

		internal void init() {
		}

		public void Close() {
			showWindowSignal.Dispatch (GAME_WINDOWS.MAP);
		}
			
	}

}


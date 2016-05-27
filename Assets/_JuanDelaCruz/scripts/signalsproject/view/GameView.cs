using System;
using System.Collections;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace JuanDelaCruz {

	public class GameView : View {

		[SerializeField] GameObject holder;

		internal void init() {
		}

		public void EnableGame() {
			holder.SetActive(true);
		}

		public void DisableGame() {
			holder.SetActive(false);
		}


	}

}


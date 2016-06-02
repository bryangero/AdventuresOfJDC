using System;
using System.Collections;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace JuanDelaCruz {

	public class MapView : View {

		[Inject]
		public IPlayer player { get; set; }

		public Signal<int> loadStage = new Signal<int>();


		[SerializeField] GameObject holder;

		internal void init() {
		}

		public void EnableMap() {
			holder.SetActive(true);
		}

		public void DisableMap() {
			holder.SetActive(false);
		}

		public void LoadStage(int stageId) {
			if (player.stage >= stageId) {
				loadStage.Dispatch (stageId);
			} else {
				Debug.Log("NOT YET UNLOCKED");	
			}
		}

	}

}


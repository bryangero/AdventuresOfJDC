using System;
using System.Collections;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace JuanDelaCruz {

	public class MapView : View {

		public Signal<int> loadStage = new Signal<int>();

		[SerializeField] GameObject holder;

		public void EnableMap() {
			holder.SetActive(true);
		}

		public void DisableMap() {
			holder.SetActive(false);
		}

		public void LoadStage(int stageId) {
			loadStage.Dispatch (stageId);
		}

	}

}


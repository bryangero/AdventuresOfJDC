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
			Debug.Log(stageId);	
		}

	}

}


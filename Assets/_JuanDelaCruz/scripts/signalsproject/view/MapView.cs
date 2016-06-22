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

		public UISprite[] stageSprites;

		public void EnableMap() {
			holder.SetActive(true);
			Debug.Log (player.stage);
			for(int i = 0; i < stageSprites.Length; i++) {
				if (Int32.Parse (stageSprites [i].name) > player.stage) {
					stageSprites [i].color = Color.gray;
				} else {
					stageSprites [i].color = Color.white;
				}
			}
		}

		public void DisableMap() {
			holder.SetActive(false);
		}

		public void LoadStage(int stageId) {
			loadStage.Dispatch (stageId);
		}

	}

}


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
		public Signal<GAME_WINDOWS> showWindowSignal = new Signal<GAME_WINDOWS> ();
		[SerializeField] GameObject holder;
		public UISprite[] stageSprites;
		public bool isActive;

		public void EnableMap() {
			StartCoroutine (WaitFrameEnd());
			holder.SetActive(true);
			for(int i = 0; i < stageSprites.Length; i++) {
				if (Int32.Parse (stageSprites [i].name) > player.stage) {
					stageSprites [i].color = Color.gray;
				} else {
					stageSprites [i].color = Color.white;
				}
			}
		}

		public IEnumerator WaitFrameEnd() {
			yield return null;
			isActive = true;
		}

		public void FixedUpdate() {
			if(Input.GetKeyUp(KeyCode.Escape) && isActive) {
				showWindowSignal.Dispatch(GAME_WINDOWS.LANDING_PAGE);
			}
		}

		public void DisableMap() {
			isActive = false;
			holder.SetActive(false);
		}

		public void LoadStage(int stageId) {
			loadStage.Dispatch (stageId);
		}

	}

}


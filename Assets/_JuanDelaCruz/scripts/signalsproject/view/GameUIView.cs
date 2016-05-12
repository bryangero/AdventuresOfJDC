using System;
using System.Collections;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace JuanDelaCruz {

	public class GameUIView : View {

		[SerializeField] GameObject holder;
		public Signal endBattleSignal = new Signal();

		internal void init() {
		}

		public void EnableGameUI() {
			holder.SetActive(true);
		}

		public void DisableGameUI() {
			holder.SetActive(false);
		}

		public void OnClickBattle() {
			Debug.Log("Clicked END BATTLE");
		}

	}

}


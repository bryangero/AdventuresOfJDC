using System;
using System.Collections;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace JuanDelaCruz {

	public class ShopUIView : View {

		[SerializeField] GameObject holder;
		public Signal endBattleSignal = new Signal();

		internal void init() {
		}

		public void EnableShopUI() {
			holder.SetActive(true);
		}

		public void DisableShopUI() {
			holder.SetActive(false);
		}

		public void OnClickBattle() {
		}

	}

}


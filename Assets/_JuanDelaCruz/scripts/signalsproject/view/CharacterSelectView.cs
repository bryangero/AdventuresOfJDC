using System;
using System.Collections;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace JuanDelaCruz {

	public class CharacterSelectView : View {

		[SerializeField] GameObject holder;
		public Signal clickSignal = new Signal();

		internal void init() {
		}

		public void EnableCharacterSelect() {
			holder.SetActive(true);
		}

		public void OnClickMale() {
			Debug.Log("Clicked Male");
		}

		public void OnClickFemale() {
			Debug.Log("Clicked Female");
		}

	}

}


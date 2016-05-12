using System;
using System.Collections;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace JuanDelaCruz {

	public class CharacterSelectView : View {

		[SerializeField] GameObject holder;
		public Signal<GENDER> clickGenderSignal = new Signal<GENDER>();

		internal void init() {
		}

		public void EnableCharacterSelect() {
			holder.SetActive(true);
		}

		public void DisableCharacterSelect() {
			holder.SetActive(false);
		}

		public void OnClickMale() {
			clickGenderSignal.Dispatch(GENDER.MALE);
			Debug.Log("Clicked Male");
		}

		public void OnClickFemale() {
			clickGenderSignal.Dispatch(GENDER.FEMALE);
			Debug.Log("Clicked Female");
		}

	}

}


using System;
using System.Collections;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace JuanDelaCruz {
	
	public class LandingPageView : View {

		public Signal clickNewGameSignal = new Signal();
		public Signal clickLoadGameSignal = new Signal();
		[SerializeField] private GameObject holder;
		[SerializeField] private Instructions instructions;

		public void DisableLandingPage() {
			holder.SetActive(false);
		}

		public void OnClickNewGame() {
			clickNewGameSignal.Dispatch();
		}

		public void OnClickLoadGame() {
			clickLoadGameSignal.Dispatch();
		}

		public void OnClickInstructions() {
			instructions.ShowInstruction();
//			Debug.Log("Clicked Instructions");
		}

		public void OnClickCredits() {
//			Debug.Log("Clicked Credits");
		}

		public void OnClickAudio() {
//			Debug.Log("Clicked Audio");
		}

	}

}


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
			AudioManager.instance.PlayButton ();
			clickNewGameSignal.Dispatch();
		}

		public void OnClickLoadGame() {
			AudioManager.instance.PlayButton ();
			clickLoadGameSignal.Dispatch();
		}

		public void OnClickInstructions() {
			AudioManager.instance.PlayButton ();
			instructions.ShowInstruction();
//			Debug.Log("Clicked Instructions");
		}

		public void OnClickCredits() {
			AudioManager.instance.PlayButton ();
//			Debug.Log("Clicked Credits");
		}

		public void OnClickAudio() {
			AudioManager.instance.PlayButton ();
//			Debug.Log("Clicked Audio");
		}

	}

}


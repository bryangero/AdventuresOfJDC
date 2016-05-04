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
		[SerializeField] private Instructions instructions;

		public void OnClickNewGame() {
			clickNewGameSignal.Dispatch();
			Debug.Log("Clicked New Game");
		}

		public void OnClickLoadGame() {
			Debug.Log("Clicked Load Game");
		}

		public void OnClickInstructions() {
			instructions.ShowInstruction();
			Debug.Log("Clicked Instructions");
		}

		public void OnClickCredits() {
			Debug.Log("Clicked Credits");
		}

		public void OnClickAudio() {
			Debug.Log("Clicked Audio");
		}

	}

}


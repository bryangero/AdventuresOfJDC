using System;
using System.Collections;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace JuanDelaCruz {

	public class CharacterSelectView : View {
		
		public Signal clickSignal = new Signal();
		[SerializeField] private Instructions instructions;


		internal void init() {
		}

		public void OnClickNewGame() {
			
			Debug.Log("Clicked New Game");
		}

		public void OnClickLoadGame() {
			Debug.Log("Clicked Load Game");
		}


	}

}


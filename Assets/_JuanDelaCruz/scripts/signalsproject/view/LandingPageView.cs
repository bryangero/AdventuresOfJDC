using System;
using System.Collections;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using GameSparks.Api;
using GameSparks.Api.Messages;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Core;

namespace JuanDelaCruz {
	
	public class LandingPageView : View {

		[Inject]
		public IPlayer player {get;set;}


		public Signal<DIALOGUE_TYPE, string> loadDialogueBoxSignal = new Signal<DIALOGUE_TYPE, string>();
		public Signal<GAME_WINDOWS> showWindowSignal = new Signal<GAME_WINDOWS> ();

		public Signal clickLoadGameSignal = new Signal();
		[SerializeField] private GameObject holder;
		[SerializeField] private Instructions instructions;

        [SerializeField]
        private Credits credits;

        [SerializeField] private GameObject enterNameGO;
		[SerializeField] private UILabel newName;

		public bool isActive = false;

		public void FixedUpdate() {
			if (Input.GetKeyUp (KeyCode.Escape) && isActive) {
				DialogueBoxView.OnClickYesEvent += OnEscYes;
				DialogueBoxView.OnClickNoEvent += OnEscNo;
				loadDialogueBoxSignal.Dispatch(DIALOGUE_TYPE.YES_NO, "Close Application?");
			} else if (Input.GetKeyUp (KeyCode.Escape) && isActive == false && enterNameGO.activeSelf == true){
				enterNameGO.SetActive (false);
				isActive = true;
			}
		}

		public void OnEscYes(){
			DialogueBoxView.OnClickYesEvent -= OnEscYes;
			DialogueBoxView.OnClickNoEvent -= OnEscNo;
			Application.Quit();
		}
		public void OnEscNo(){
			DialogueBoxView.OnClickYesEvent -= OnEscYes;
			DialogueBoxView.OnClickNoEvent -= OnEscNo;
		}

		public void EnableLandingPage() {
			StartCoroutine (WaitFrameEnd ());
			holder.SetActive(true);
		}
			
		public void DisableLandingPage() {
			isActive = false;
			enterNameGO.SetActive(false);
			holder.SetActive(false);
		}

		public IEnumerator WaitFrameEnd() {
			yield return null;	
			isActive = true;
		}

		public void OnClickOkNewName() {
			AudioManager.instance.PlayButton();
			if (GameSparksManager.instance.isConnected) {
				GameSparksManager.instance.GSRegistrationResponseEvt += AttemptRegistration;
				GameSparksManager.instance.RegisterPlayer(newName.text.ToUpper());
			} else {
				player.CreateNewPlayer(newName.text.ToUpper());
				player.SavePlayer();
				showWindowSignal.Dispatch(GAME_WINDOWS.MAP);
				if (PlayerPrefs.HasKey ("First")) {
					PlayerPrefs.SetInt ("First", 0);
					PlayerPrefs.Save ();
				}
			}
		}


		public void OnClickNewGame() {
			AudioManager.instance.PlayButton();
			if(GameSparksManager.instance.isConnected) {
				if(PlayerPrefs.HasKey("PLAYER")) {
					DialogueBoxView.OnClickYesEvent += OnClickYesOnline;
					DialogueBoxView.OnClickNoEvent += OnClickNo;
					loadDialogueBoxSignal.Dispatch(DIALOGUE_TYPE.YES_NO, "There is currently a saved game. Continuing will erase all saved data. Proceed?");
				} else {
					enterNameGO.SetActive(true);
					isActive = false;
				}
			} else {
				if(PlayerPrefs.HasKey("PLAYER")) {
					DialogueBoxView.OnClickYesEvent += OnClickYes;
					DialogueBoxView.OnClickNoEvent += OnClickNo;
					loadDialogueBoxSignal.Dispatch (DIALOGUE_TYPE.YES_NO, "There is currently a saved game. Continuing will erase all saved data. Proceed?");
				} else {
					enterNameGO.SetActive(true);
					isActive = false;
				}
			}
		}


		private void OnClickYes() {
			DialogueBoxView.OnClickYesEvent -= OnClickYes;
			DialogueBoxView.OnClickNoEvent -= OnClickNo;
			enterNameGO.SetActive(true);
			isActive = false;
		}

		private void OnClickNo() {
			DialogueBoxView.OnClickYesEvent -= OnClickYes;
			DialogueBoxView.OnClickNoEvent -= OnClickNo;
		}

		public void AttemptRegistration(RegistrationResponse response) {
			GameSparksManager.instance.GSRegistrationResponseEvt -= AttemptRegistration;
			if (!response.HasErrors) {
				player.CreateNewPlayer(newName.text.ToUpper());
				player.SavePlayer();
				GameSparksManager.instance.GsLogEventResponseEvt += AttemptSavePlayer;
				GameSparksManager.instance.SavePlayer(player);
				Debug.Log("Player Registered Successfully");
			} else {
				loadDialogueBoxSignal.Dispatch (DIALOGUE_TYPE.OK, "Player with that name already exists");
				Debug.Log("Error Registering Player");
			}
		}

		public void AttemptAuthentication(AuthenticationResponse response) {
			GameSparksManager.instance.GSAuthenticationResponseEvt -= AttemptAuthentication;
			if (!response.HasErrors) {
				if (PlayerPrefs.HasKey ("PLAYER")) {
					player.CreateNewPlayer(newName.text.ToUpper());
					player.SavePlayer();
					GameSparksManager.instance.GsLogEventResponseEvt += AttemptSavePlayer;
					GameSparksManager.instance.SavePlayer(player);
				} else {
					DialogueBoxView.OnClickYesEvent += OnClickYesOnlineAlreadyRegistered;
					DialogueBoxView.OnClickNoEvent += OnClickNo;
					loadDialogueBoxSignal.Dispatch(DIALOGUE_TYPE.YES_NO, "There is currently a saved game. Continuing will erase all saved data. Proceed?");
				}
				Debug.Log("Player Authenticated...");
			} else {
				Debug.Log("Error Authenticating Player...");
			}
		}

		public void AttemptSavePlayer(LogEventResponse response) {
			GameSparksManager.instance.GsLogEventResponseEvt -= AttemptSavePlayer;
			if (!response.HasErrors) {
				showWindowSignal.Dispatch(GAME_WINDOWS.MAP);
				if (PlayerPrefs.HasKey ("First")) {
					PlayerPrefs.SetInt ("First", 0);
					PlayerPrefs.Save ();
				}

				Debug.Log("Player Saved To GameSparks...");
			} else {
				Debug.Log("Error Saving Player Data...");
			}
		}

		private void OnClickYesOnline() {
			DialogueBoxView.OnClickYesEvent -= OnClickYesOnline;
			DialogueBoxView.OnClickNoEvent -= OnClickNo;
			enterNameGO.SetActive(true);
			isActive = false;
		}

		private void OnClickYesOnlineAlreadyRegistered() {
			DialogueBoxView.OnClickYesEvent -= OnClickYesOnlineAlreadyRegistered;
			DialogueBoxView.OnClickNoEvent -= OnClickNo;
			player = new Player();
			player.SavePlayer();
			GameSparksManager.instance.GsLogEventResponseEvt += AttemptSavePlayer;
			GameSparksManager.instance.SavePlayer(player);
		}

		public void OnClickLoadGame() {
			AudioManager.instance.PlayButton ();
			clickLoadGameSignal.Dispatch();
		}

		public void OnClickInstructions() {
			AudioManager.instance.PlayButton ();
			instructions.ShowInstruction();
		}

		public void OnClickCredits() {
			AudioManager.instance.PlayButton ();
            credits.ShowInstruction();
		}

		public void OnClickAudio() {
			AudioManager.instance.PlayButton ();
		}

	}

}


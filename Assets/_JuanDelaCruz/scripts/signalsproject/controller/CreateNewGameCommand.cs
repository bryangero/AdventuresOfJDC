using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;
using GameSparks.Api;
using GameSparks.Api.Messages;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Core;

namespace JuanDelaCruz {

	public class CreateNewGameCommand : Command {
		
		[Inject(ContextKeys.CONTEXT_VIEW)]
		public GameObject contextView { get; set; }

		[Inject]
		public IPlayer player { get; set; }

		[Inject]
		public ShowWindowSignal showWindowSignal { get; set; }

		[Inject]
		public LoadDialogueBoxSignal loadDialogueBoxSignal { get; set; }

		[Inject]
		public LoadEnterNameSignal loadEnterNameSignal { get; set; }

		public override void Execute() {
			if(GameSparksManager.instance.isConnected) {
				if(PlayerPrefs.HasKey("PLAYER")) {
					DialogueBoxView.OnClickYesEvent += OnClickYesOnline;
					DialogueBoxView.OnClickNoEvent += OnClickNo;
					loadDialogueBoxSignal.Dispatch(DIALOGUE_TYPE.YES_NO, "There is currently a saved game. Continuing will erase all saved data. Proceed?");
				} else {
					GameSparksManager.instance.GSRegistrationResponseEvt += AttemptRegistration;
					GameSparksManager.instance.RegisterPlayer();
				}
			} else {
				if(PlayerPrefs.HasKey("PLAYER")) {
					DialogueBoxView.OnClickYesEvent += OnClickYes;
					DialogueBoxView.OnClickNoEvent += OnClickNo;
					loadDialogueBoxSignal.Dispatch (DIALOGUE_TYPE.YES_NO, "There is currently a saved game. Continuing will erase all saved data. Proceed?");
				} else {
					player = new Player();
					player.SavePlayer();
//					showWindowSignal.Dispatch(GAME_WINDOWS.MAP);
				}
			}
		}

		private void OnClickYes() {
			DialogueBoxView.OnClickYesEvent -= OnClickYes;
			player = new Player();
			player.SavePlayer();
//			showWindowSignal.Dispatch(GAME_WINDOWS.MAP);
//			loadEnterNameSignal.Dispatch ();
		}

		private void OnClickNo() {
			DialogueBoxView.OnClickYesEvent -= OnClickNo;
		}

		public void AttemptRegistration(RegistrationResponse response) {
			GameSparksManager.instance.GSRegistrationResponseEvt -= AttemptRegistration;
			if (!response.HasErrors) {
				player = new Player();
				player.SavePlayer();
				GameSparksManager.instance.GsLogEventResponseEvt += AttemptSavePlayer;
				GameSparksManager.instance.SavePlayer(player);
				Debug.Log("Player Registered Successfully");
			} else {
				GameSparksManager.instance.GSAuthenticationResponseEvt += AttemptAuthentication;
				GameSparksManager.instance.AuthenticatePlayer();
				Debug.Log("Error Registering Player");
			}
		}

		public void AttemptAuthentication(AuthenticationResponse response) {
			GameSparksManager.instance.GSAuthenticationResponseEvt -= AttemptAuthentication;
			if (!response.HasErrors) {
				if (PlayerPrefs.HasKey ("PLAYER")) {
					player = new Player();
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
				Debug.Log("Player Saved To GameSparks...");
			} else {
				Debug.Log("Error Saving Player Data...");
			}
		}

		private void OnClickYesOnline() {
			DialogueBoxView.OnClickYesEvent -= OnClickYesOnline;
			GameSparksManager.instance.GSRegistrationResponseEvt += AttemptRegistration;
			GameSparksManager.instance.RegisterPlayer();
		}

		private void OnClickYesOnlineAlreadyRegistered() {
			DialogueBoxView.OnClickYesEvent -= OnClickYesOnlineAlreadyRegistered;
			player = new Player();
			player.SavePlayer();
			GameSparksManager.instance.GsLogEventResponseEvt += AttemptSavePlayer;
			GameSparksManager.instance.SavePlayer(player);
		}


	}

}


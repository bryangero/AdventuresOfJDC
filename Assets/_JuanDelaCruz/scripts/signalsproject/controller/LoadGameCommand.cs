using System;
using System.Collections;
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

	public class LoadGameCommand : Command {
		
		[Inject(ContextKeys.CONTEXT_VIEW)]
		public GameObject contextView { get; set; }

		[Inject]
		public IPlayer player { get; set; }

		[Inject]
		public ShowWindowSignal showWindowSignal { get; set; }

		[Inject]
		public LoadDialogueBoxSignal loadDialogueBoxSignal { get; set; }

		[Inject]
		public IRoutineRunner rr { get; set; }

		public override void Execute() {
			rr.StartCoroutine(ExecuteInOrder());
		}

		public IEnumerator ExecuteInOrder() {
			yield return null;
			if(GameSparksManager.instance.isConnected) {
				if(PlayerPrefs.HasKey("PLAYER")) {
					player.LoadPlayer();
					yield return null;
					GameSparksManager.instance.GSAuthenticationResponseEvt += AttemptAuthentication;
					GameSparksManager.instance.AuthenticatePlayer(player.name);
				} else {
					DialogueBoxView.OnClickOKEvent += OnClickOK;
					loadDialogueBoxSignal.Dispatch(DIALOGUE_TYPE.OK, "There is no saved game. Please select New Game.");
				}
			} else {
				if(PlayerPrefs.HasKey("PLAYER")) {
					player.LoadPlayer();
					yield return null;
					showWindowSignal.Dispatch(GAME_WINDOWS.MAP);
				} else {
					DialogueBoxView.OnClickOKEvent += OnClickOK;
					loadDialogueBoxSignal.Dispatch(DIALOGUE_TYPE.OK, "There is no saved game. Please select New Game.");
				}
			}
		}

		private void OnClickOK() {
			DialogueBoxView.OnClickYesEvent -= OnClickOK;
		}
			
		public void AttemptAuthentication(AuthenticationResponse response) {
			GameSparksManager.instance.GSAuthenticationResponseEvt -= AttemptAuthentication;
			if (!response.HasErrors) {
				if (PlayerPrefs.HasKey("PLAYER")) {
					player.LoadPlayer();
					showWindowSignal.Dispatch(GAME_WINDOWS.MAP);
				} else {
					GameSparksManager.instance.GsLogEventResponseEvt += AttemptLoadPlayer;
					GameSparksManager.instance.LoadPlayer();
				}
				Debug.Log("Player Authenticated...");
			} else {
				DialogueBoxView.OnClickOKEvent += OnClickOK;
				loadDialogueBoxSignal.Dispatch(DIALOGUE_TYPE.OK, "There is no saved game. Please select New Game.");
				Debug.Log("Error Authenticating Player...");
			}
		}

		public void AttemptLoadPlayer(LogEventResponse response) {
			GameSparksManager.instance.GsLogEventResponseEvt -= AttemptLoadPlayer;
			if (!response.HasErrors) {
				GSData data = response.ScriptData.GetGSData("player_Data");
				player.name = data.GetString("playerName").ToString();
				player.level = (int)data.GetInt("playerLevel");
				player.stage = (int)data.GetInt("playerStage");
				player.weapon =  (WEAPON_TYPE)data.GetInt("playerWeapon");
				player.gold = (int)data.GetInt("playerGold");
				player.currentExperience = (int)data.GetInt("playerCurrentExperiance");
				player.weaponsBought =  JsonFx.Json.JsonReader.Deserialize<bool[]>(data.GetString("playerWeaponsBought"));
				Debug.Log("Player Name: " + player.name);
				Debug.Log("Player Level: " + player.level);
				Debug.Log("Player Stage: " + player.stage);
				Debug.Log("Player Weapon: " + player.weapon);
				Debug.Log("Player Gold: " + player.gold);
				Debug.Log("Player Current Experience: " + player.currentExperience);
				for (int i = 0; i < player.weaponsBought.Length; i++) {
					Debug.Log("player.weaponsBought: " + player.weaponsBought[i]);
				}
				showWindowSignal.Dispatch(GAME_WINDOWS.MAP);
				Debug.Log("Received Player Data From GameSparks...");
			} else {
				Debug.Log("Error Loading Player Data...");
			}
		}
			
	}

}


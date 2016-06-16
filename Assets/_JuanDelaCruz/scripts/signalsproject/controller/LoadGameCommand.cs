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
		public IRoutineRunner rr { get; set; }

		public override void Execute() {
			rr.StartCoroutine(ExecuteInOrder());
		}

		public IEnumerator ExecuteInOrder() {
			yield return null;
			if (GameSparksManager.instance.isAvailable) {
				AuthenticatePlayer();
			} else {
				player.LoadPlayer();
				yield return null;
				showWindowSignal.Dispatch(GAME_WINDOWS.MAP);
			}

		}

		public void AuthenticatePlayer() {
			new GameSparks.Api.Requests.AuthenticationRequest().SetUserName(GameSparksManager.instance.DEVICE_ID).SetPassword("password").Send((response) => {
				if (!response.HasErrors) {
					Debug.Log("Player Authenticated...");
					LoadPlayer();
				} else {
					Debug.Log("Error Authenticating Player...");
				}
			});	
		}

		public void LoadPlayer() {
			new GameSparks.Api.Requests.LogEventRequest().SetEventKey("GET_PLAYER").Send((response) => {
				if (!response.HasErrors) {
					Debug.Log("Received Player Data From GameSparks...");
					GSData data = response.ScriptData.GetGSData("player_Data");
					Debug.Log("Player ID: " + data.GetString("playerID").ToString());
					Debug.Log("Player Name: " + data.GetString("playerName").ToString());
					Debug.Log("Player Level: " + data.GetInt("playerLevel").ToString());
					Debug.Log("Player Stage: " + data.GetInt("playerStage").ToString());
					Debug.Log("Player Weapon: " + data.GetInt("playerWeapon").ToString());
					Debug.Log("Player Gold: " + data.GetInt("playerGold").ToString());
					Debug.Log("Player Current Experience: " + data.GetInt("playerCurrentExperiance").ToString());
					player.name = data.GetString("playerName").ToString();
					player.level = (int)data.GetInt("playerLevel");
					player.stage = (int)data.GetInt("playerStage");
					player.weapon =  (WEAPON_TYPE)data.GetInt("playerWeapon");
					player.gold = (int)data.GetInt("playerGold");
					player.currentExperience = (int)data.GetInt("playerCurrentExperiance");
					showWindowSignal.Dispatch(GAME_WINDOWS.MAP);
				} else {
					Debug.Log("Error Loading Player Data...");
				}
			});
		}


	}

}


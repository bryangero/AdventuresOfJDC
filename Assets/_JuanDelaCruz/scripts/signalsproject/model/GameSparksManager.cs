using UnityEngine;
using System;
using System.Collections;
using GameSparks.Api;
using GameSparks.Api.Messages;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Core;

namespace JuanDelaCruz {
	public class GameSparksManager : MonoBehaviour {

		public bool isAvailable;
		public bool isConnected;
		public string DEVICE_ID;
		public bool isForcedOffline;
		public GameObject loading;
		public GameSparksUnity gsu;
		public string USER_ID;

		public delegate void GSAuthenticationResponse(AuthenticationResponse ar);
		public event GSAuthenticationResponse GSAuthenticationResponseEvt;

		public delegate void GSRegistrationResponse(RegistrationResponse rr);
		public event GSRegistrationResponse GSRegistrationResponseEvt;

		public delegate void GsLogEventResponse(LogEventResponse ler);
		public event GsLogEventResponse GsLogEventResponseEvt;

		/// <summary>The GameSparks Manager singleton</summary>
		public static GameSparksManager instance = null;

		private void Awake() {
			if (isForcedOffline) {
				gsu.enabled = false;
				isAvailable = false;
			} else {
				StartCoroutine(checkInternetConnection((isConnected)=> {
					this.isConnected = isConnected;
					gsu.enabled = isConnected;
					if(isConnected == false)
						loading.SetActive(false);
				}));
			}
			GS.GameSparksAvailable += HandleGameSparksAvailable;
			DEVICE_ID = SystemInfo.deviceUniqueIdentifier;
			if (instance == null) // check to see if the instance has a reference
			{
				instance = this; // if not, give it a reference to this class...
				DontDestroyOnLoad(this.gameObject); // and make this object persistent as we load new scenes
			} else // if we already have a reference then remove the extra manager from the scene
			{
				Destroy(this.gameObject);
			}
		}

		public IEnumerator checkInternetConnection(Action<bool> action) {
			WWW www = new WWW("http://google.com");
			loading.SetActive(true);
			yield return www;
			if (www.error != null) {
				action (false);
			} else {
				action (true);
			}
		} 

		private void HandleGameSparksAvailable (bool isAvailable) {
			if(isAvailable) {
				Debug.Log("GAMESPARKS AVAILABLE...");
				this.isAvailable = isAvailable;
			} else {
				Debug.Log("GAMESPARKS NOT AVAILABLE...");
			}
			loading.SetActive(false);
		}

		public void RegisterPlayer() {
			new GameSparks.Api.Requests.RegistrationRequest().SetDisplayName("Juan").SetPassword("password").SetUserName(GameSparksManager.instance.DEVICE_ID).Send((response) => {
				GSRegistrationResponseEvt(response);
			});
		}
			
		public void SavePlayer(IPlayer player) {
			new GameSparks.Api.Requests.LogEventRequest().SetEventKey("SET_PLAYER").
			SetEventAttribute("NAME", player.name).
			SetEventAttribute("LEVEL", player.level).
			SetEventAttribute("STAGE", player.stage).
			SetEventAttribute("WEAPON_TYPE", (int)player.weapon).
			SetEventAttribute("GOLD", player.gold).
			SetEventAttribute("CURRENT_EXP", player.currentExperience).
			SetEventAttribute("WEAPONS_BOUGHT", JsonFx.Json.JsonWriter.Serialize(player.weaponsBought)).Send((response) => {
				GsLogEventResponseEvt(response);
			});
		}

		public void AuthenticatePlayer() {
			new GameSparks.Api.Requests.AuthenticationRequest().SetUserName(DEVICE_ID).SetPassword("password").Send((response) => {
				GSAuthenticationResponseEvt(response);
			});	
		}

		public void LoadPlayer() {
			new GameSparks.Api.Requests.LogEventRequest().SetEventKey("GET_PLAYER").Send((response) => {
					GsLogEventResponseEvt(response);
			});
		}

		public void LoadPlayers() {
			new GameSparks.Api.Requests.LogEventRequest().SetEventKey("GET_PLAYERS").
																		SetEventAttribute("PLAYER_LEVEL", 1).
																		Send((response) => {
				GsLogEventResponseEvt(response);
			});
		}



	}
}
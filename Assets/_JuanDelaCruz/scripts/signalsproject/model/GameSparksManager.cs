using UnityEngine;
using System.Collections;
using GameSparks.Api;
using GameSparks.Api.Messages;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Core;

namespace JuanDelaCruz {
	public class GameSparksManager : MonoBehaviour {

		public bool isAvailable;
		public string DEVICE_ID;

		/// <summary>The GameSparks Manager singleton</summary>
		public static GameSparksManager instance = null;

		private void Awake() {
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

		private void HandleGameSparksAvailable (bool isAvailable) {
			if(isAvailable) {
				Debug.Log("GAMESPARKS AVAILABLE...");
//				new GameSparks.Api.Requests.DeviceAuthenticationRequest()
//					.SetDurable (true)
//					.Send ((response) => {
//						if(!response.HasErrors) {
//							Debug.Log("Device Authenticated with ID => "+response.UserId);
//						}
//					});
				this.isAvailable = isAvailable;
			} else {
				Debug.Log("GAMESPARKS NOT AVAILABLE...");
			}
		}

		public void SavePlayer() {
			new GameSparks.Api.Requests.LogEventRequest().SetEventKey("SET_PLAYER").
			SetEventAttribute("NAME", "Juan").
			SetEventAttribute("LEVEL", 1).
			SetEventAttribute("STAGE", 1).
			SetEventAttribute("WEAPON_TYPE", 0).
			SetEventAttribute("GOLD", 0).
			SetEventAttribute("CURRENT_EXP", 0).Send((response) => {
				if (!response.HasErrors) {
					Debug.Log("Player Saved To GameSparks...");
				} else {
					Debug.Log("Error Saving Player Data...");
				}
			});
		}

		public void AuthenticatePlayer() {
			new GameSparks.Api.Requests.AuthenticationRequest().SetUserName("Bryan2").SetPassword("test_password_123456").Send((response) => {
				if (!response.HasErrors) {
					Debug.Log("Player Authenticated...");
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
					print("Player ID: " + data.GetString("playerID"));
					print("Player Name: " + data.GetString("playerName"));
					print("Player Level: " + data.GetInt("playerLevel"));
					print("Player Stage: " + data.GetInt("playerStage"));
					print("Player Weapon: " + data.GetInt("playerWeapon"));
					print("Player Gold: " + data.GetInt("playerGold"));
					print("Player Current Experience: " + data.GetInt("playerCurrentExperiance"));

				} else {
					Debug.Log("Error Loading Player Data...");
				}
			});
		}

		public void LoadPlayers() {
			new GameSparks.Api.Requests.LogEventRequest().SetEventKey("GET_PLAYERS").
																		SetEventAttribute("PLAYER_LEVEL", 1).
																		Send((response) => {
				if (!response.HasErrors) {
					Debug.Log("Received Player Data From GameSparks...");
					GSData[] data = response.ScriptData.GetGSDataList("playerData").ToArray();
					Debug.Log(data.Length);

				} else {
					Debug.Log("Error Loading Player Data...");
				}
			});
		}



	}
}
using System;
using System.Collections;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace JuanDelaCruz {

	public class MapView : View {

		[Inject]
		public IPlayer player { get; set; }
		public Signal<int> loadStage = new Signal<int>();
		public Signal<GAME_WINDOWS> showWindowSignal = new Signal<GAME_WINDOWS> ();
		[SerializeField] GameObject holder;
        [SerializeField] GameObject mapCamera;
        public UISprite[] stageSprites;
		public bool isActive;
		public UITexture script;
		public Texture[] scriptsTextures;
		public GameObject instructions1;
		public GameObject instructions2;
		public GameObject instructions3;
		public void EnableMap() {
			StartCoroutine (WaitFrameEnd());
			holder.SetActive(true);
            mapCamera.SetActive(true);

            for (int i = 0; i < stageSprites.Length; i++) {
				if (Int32.Parse (stageSprites [i].name) > player.stage) {
					stageSprites [i].color = Color.gray;
				} else {
					stageSprites [i].color = Color.white;
				}
			}

		}

		int scriptIndex = 0;
		public void UpdateScriptTextures() {
			scriptIndex++;
			if (scriptIndex < scriptsTextures.Length) {
				script.mainTexture = scriptsTextures [scriptIndex];
			} else {
				script.gameObject.SetActive (false);
				instructions1.SetActive (true);
			}
		}

		public void ShowInstructions2() {
			instructions1.SetActive (false);
			instructions2.SetActive (true);
		}
		public void ShowInstructions3() {
			instructions2.SetActive (false);
			instructions3.SetActive (true);
		}
		public void CloseInstructions() {
			instructions3.SetActive (false);
		}

		public IEnumerator WaitFrameEnd() {
			yield return null;
			isActive = true;
			if (!PlayerPrefs.HasKey ("First")) {
				script.gameObject.SetActive (true);
				PlayerPrefs.SetInt ("First", 1);
			} else {
				if (PlayerPrefs.GetInt ("First") == 0) {
					script.gameObject.SetActive (true);
					PlayerPrefs.SetInt ("First", 1);
				}
			}
		}

		public void FixedUpdate() {
			if(Input.GetKeyUp(KeyCode.Escape) && isActive) {
				showWindowSignal.Dispatch(GAME_WINDOWS.LANDING_PAGE);
			}
		}

		public void DisableMap() {
			isActive = false;
			holder.SetActive(false);
            mapCamera.SetActive(false);
        }

        public void LoadStage(int stageId) {
			loadStage.Dispatch (stageId);
		}

	}

}


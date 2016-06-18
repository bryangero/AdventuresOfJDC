using UnityEngine;
using System.Collections;

namespace JuanDelaCruz {
	
	public class StageBtn : MonoBehaviour {

		public MapView mapView;

		public delegate void ClickStage(int stageId);
		public event ClickStage onClickStage;

		public int stageId;

		public void Awake() {
			mapView = GameObject.FindObjectOfType(typeof(MapView)) as MapView;
			onClickStage += mapView.LoadStage;
		}

		public void OnClickStageButton() {
			AudioManager.instance.PlayButton ();
			onClickStage(stageId);
		}

	}

}


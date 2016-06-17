using UnityEngine;
using System.Collections;

namespace JuanDelaCruz {

	public class PlayerHelper : MonoBehaviour {

		public delegate void ClickHelper(int helperId);
		public event ClickHelper onClickHelper;

		public NeedHelpUIView needHelpUIView;

		public int id;
		public UILabel levelLbl;
		public GameObject character;

		public void Awake() {
			onClickHelper += needHelpUIView.OnChosenHelper;
		}

		public void Init(int level) {
			levelLbl.text = "Level: " + level;
		}

		public void OnClickHelperButton() {
			onClickHelper(id);
		}

	}
}
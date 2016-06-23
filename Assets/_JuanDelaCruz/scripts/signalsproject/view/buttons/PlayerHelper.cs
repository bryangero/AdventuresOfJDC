using UnityEngine;
using System.Collections;

namespace JuanDelaCruz {

	public class PlayerHelper : MonoBehaviour {

		public delegate void ClickHelper(int helperId);
		public event ClickHelper onClickHelper;

		public NeedHelpUIView needHelpUIView;

		public int id;
		public UILabel playerNameLbl;
		public UILabel levelLbl;
		public UILabel weaponLbl;
		public GameObject character;

		public void Awake() {
			onClickHelper += needHelpUIView.OnChosenHelper;
		}

		public void Init(Player player) {
			playerNameLbl.text = player.name;
			levelLbl.text = "Level: " + player.level;
			switch (player.weapon) {
			case WEAPON_TYPE.SWORD:
				weaponLbl.text = "sword";
				break;
			case WEAPON_TYPE.SPEAR:
				weaponLbl.text = "spear";
				break;
			case WEAPON_TYPE.WHIP:
				weaponLbl.text = "whip";
				break;
			default:
				weaponLbl.text = "shield";
				break;
			}
		}

		public void OnClickHelperButton() {
			onClickHelper(id);
		}

	}
}
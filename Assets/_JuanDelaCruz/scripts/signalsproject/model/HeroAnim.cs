using UnityEngine;
using System.Collections;

namespace JuanDelaCruz {

	public class HeroAnim : MonoBehaviour {
		public GameUIView gameUIView;
		public Animator heroAnimator;
		public Vector3 currPosition;

		public Vector3 targetPosSword;
		public Vector3 targetPosSpear;
		public Vector3 targetPosWhip;
		public Vector3 targetPosShield;

		public WEAPON_TYPE weaponType;

		private void Awake() {
			//			currPosition = transform.localPosition;
		}

		public void PlayAttack(WEAPON_TYPE weaponType = WEAPON_TYPE.SWORD) {
			this.weaponType = weaponType;

			switch (weaponType) {
			case WEAPON_TYPE.SWORD:
				heroAnimator.SetTrigger ("sword");
				break;
			case WEAPON_TYPE.SPEAR:
				heroAnimator.SetTrigger ("spear");
				break;
			case WEAPON_TYPE.SHIELD:
				heroAnimator.SetTrigger ("shield");
				break;
			case WEAPON_TYPE.WHIP:
				heroAnimator.SetTrigger ("whip");
				break;
			default:
				heroAnimator.SetTrigger ("spear");
				break;
			}

		}

		public void OnFinishAttack() {
			gameUIView.OnHeroFinishAttack();
		}


	}
}
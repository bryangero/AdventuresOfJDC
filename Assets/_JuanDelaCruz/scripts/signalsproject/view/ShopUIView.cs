using System;
using System.Collections;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace JuanDelaCruz {

	public class ShopUIView : View {

		[Inject]
		public IPlayer player {get;set;}

		public Signal notEnoughGold =  new Signal();

		[SerializeField] GameObject holder;
		public GameObject isEquippedSprite;
		public GameView gameView;
		public UILabel goldLabel;


		internal void init() {
			EnableShopUI();
			if (player.weapon != WEAPON_TYPE.NONE) {
				isEquippedSprite.SetActive (true);
				switch (player.weapon) {
				case WEAPON_TYPE.SWORD:
					isEquippedSprite.transform.localPosition = new Vector3 (-500,-200,0);
					break;
				case WEAPON_TYPE.BOW:
					isEquippedSprite.transform.localPosition = new Vector3 (-250,-200,0);
					break;
				case WEAPON_TYPE.WHIP:
					isEquippedSprite.transform.localPosition = new Vector3 (0,-200,0);
					break;
				case WEAPON_TYPE.SPEAR:
					isEquippedSprite.transform.localPosition = new Vector3 (250,-200,0);
					break;
				case WEAPON_TYPE.SHIELD:
					isEquippedSprite.transform.localPosition = new Vector3 (500,-200,0);
					break;
				default:
					isEquippedSprite.SetActive (false);
					break;
				}
			}
			goldLabel.text = "Gold: " + player.gold;
		}

		public void EnableShopUI() {
			holder.SetActive(true);
		}

		public void DisableShopUI() {
			holder.SetActive(false);
		}

		public void BuySword() {
			if (player.DecreaseGold (200) == true) {
				player.weapon = WEAPON_TYPE.SWORD;
				Close();
			} else {
				notEnoughGold.Dispatch();
			}
		}

		public void BuyBow() {
			if (player.DecreaseGold (400) == true) {
				player.weapon = WEAPON_TYPE.BOW;
				Close();
			} else {
				notEnoughGold.Dispatch();
			}
		}

		public void BuyWhip() {
			if (player.DecreaseGold (800) == true) {
				player.weapon = WEAPON_TYPE.WHIP;
				Close();
			} else {
				notEnoughGold.Dispatch();
			}
		}

		public void BuySpear() {
			if (player.DecreaseGold (1600) == true) {
				player.weapon = WEAPON_TYPE.SPEAR;
				Close();
			} else {
				notEnoughGold.Dispatch();
			}
		}

		public void BuyShield() {
			if (player.DecreaseGold (3000) == true) {
				player.weapon = WEAPON_TYPE.SHIELD;
				Close();
			} else {
				notEnoughGold.Dispatch();
			}
		}

		public void Close() {
			gameView.OnFinishShop();
		}

	}

}


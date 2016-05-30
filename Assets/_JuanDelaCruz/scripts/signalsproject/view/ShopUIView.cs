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

		[SerializeField] GameObject holder;
		public GameView gameView;
		public UILabel goldLabel;


		internal void init() {
			EnableShopUI();
			goldLabel.text = "Gold: " + player.gold;
		}

		public void EnableShopUI() {
			holder.SetActive(true);
		}

		public void DisableShopUI() {
			holder.SetActive(false);
		}

		public void BuySword() {
			player.weapon = WEAPON_TYPE.SWORD;
			Close();
		}

		public void BuyBow() {
			player.weapon = WEAPON_TYPE.BOW;
			Close();
		}

		public void BuyWhip() {
			player.weapon = WEAPON_TYPE.WHIP;
			Close();
		}

		public void BuySpear() {
			player.weapon = WEAPON_TYPE.SPEAR;
			Close();
		}

		public void BuyShield() {
			player.weapon = WEAPON_TYPE.SHIELD;
			Close();
		}

		public void Close() {
			gameView.OnFinishShop();
			DisableShopUI();
		}

	}

}


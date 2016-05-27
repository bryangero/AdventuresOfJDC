/// The only change in StartCommand is that we extend Command, not EventCommand

using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;

namespace JuanDelaCruz {

	public class ShowWindowCommand : Command {
		
		[Inject(ContextKeys.CONTEXT_VIEW)]
		public GameObject contextView{get;set;}

		[Inject]
		public GAME_WINDOWS gameWindow {get;set;}
		
		public override void Execute() {
			switch(gameWindow) {
				case GAME_WINDOWS.CHARACTER_SELECT: 
					GameObject.FindObjectOfType<LandingPageView>().DisableLandingPage();
					GameObject.FindObjectOfType<GameUIView>().DisableGameUI();
					GameObject.FindObjectOfType<RewardUIView>().DisableRewardUI();
					GameObject.FindObjectOfType<CharacterSelectView>().EnableCharacterSelect();
					GameObject.FindObjectOfType<MapView>().DisableMap();
					break;
				case GAME_WINDOWS.GAME: 
					GameObject.FindObjectOfType<LandingPageView>().DisableLandingPage();
					GameObject.FindObjectOfType<CharacterSelectView>().DisableCharacterSelect();
					GameObject.FindObjectOfType<RewardUIView>().DisableRewardUI();
					GameObject.FindObjectOfType<GameUIView>().EnableGameUI();
					GameObject.FindObjectOfType<MapView>().DisableMap();
					break;
				case GAME_WINDOWS.REWARD: 
					GameObject.FindObjectOfType<LandingPageView>().DisableLandingPage();
					GameObject.FindObjectOfType<CharacterSelectView>().DisableCharacterSelect();
					GameObject.FindObjectOfType<GameUIView>().DisableGameUI();
					GameObject.FindObjectOfType<RewardUIView>().EnableRewardUI();
					GameObject.FindObjectOfType<MapView>().DisableMap();
					break;
				case GAME_WINDOWS.SHOP:
					GameObject.FindObjectOfType<LandingPageView>().DisableLandingPage();
					GameObject.FindObjectOfType<CharacterSelectView>().DisableCharacterSelect();
					GameObject.FindObjectOfType<GameUIView>().DisableGameUI();
					GameObject.FindObjectOfType<RewardUIView>().DisableRewardUI();
					GameObject.FindObjectOfType<ShopUIView>().EnableShopUI();
					GameObject.FindObjectOfType<MapView>().DisableMap();
					break;
			case GAME_WINDOWS.MAP:
					GameObject.FindObjectOfType<LandingPageView>().DisableLandingPage();
					GameObject.FindObjectOfType<CharacterSelectView>().DisableCharacterSelect();
					GameObject.FindObjectOfType<GameUIView>().DisableGameUI();
					GameObject.FindObjectOfType<RewardUIView>().DisableRewardUI();
					GameObject.FindObjectOfType<ShopUIView>().DisableShopUI();
					GameObject.FindObjectOfType<MapView>().EnableMap();
					break;
			}
		}

	}

}


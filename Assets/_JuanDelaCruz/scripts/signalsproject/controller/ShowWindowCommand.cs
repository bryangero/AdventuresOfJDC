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
//			Debug.Log ("LOADING " + gameWindow);
			switch(gameWindow) {
				case GAME_WINDOWS.LANDING_PAGE: 
					GameObject.FindObjectOfType<LandingPageView>().EnableLandingPage();
					GameObject.FindObjectOfType<GameUIView>().DisableGameUI();
					GameObject.FindObjectOfType<MapView>().DisableMap();
					break;
				case GAME_WINDOWS.CHARACTER_SELECT: 
					GameObject.FindObjectOfType<LandingPageView>().DisableLandingPage();
					GameObject.FindObjectOfType<GameUIView>().DisableGameUI();
					GameObject.FindObjectOfType<MapView>().DisableMap();
					break;
				case GAME_WINDOWS.GAME: 
					GameObject.FindObjectOfType<LandingPageView>().DisableLandingPage();
					GameObject.FindObjectOfType<GameUIView>().EnableGameUI();
					GameObject.FindObjectOfType<MapView>().DisableMap();
					break;
				case GAME_WINDOWS.REWARD: 
					GameObject.FindObjectOfType<LandingPageView>().DisableLandingPage();
					GameObject.FindObjectOfType<GameUIView>().DisableGameUI();
					GameObject.FindObjectOfType<MapView>().DisableMap();
					break;
				case GAME_WINDOWS.SHOP:
					GameObject.FindObjectOfType<LandingPageView>().DisableLandingPage();
					GameObject.FindObjectOfType<GameUIView>().DisableGameUI();
					GameObject.FindObjectOfType<MapView>().DisableMap();
					break;
				case GAME_WINDOWS.MAP:
					GameObject.FindObjectOfType<LandingPageView>().DisableLandingPage();
					GameObject.FindObjectOfType<GameUIView>().DisableGameUI();
					GameObject.FindObjectOfType<MapView>().EnableMap();
					break;
			}
		}

	}

}


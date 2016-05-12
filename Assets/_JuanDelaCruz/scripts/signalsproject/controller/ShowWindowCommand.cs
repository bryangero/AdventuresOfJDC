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
					GameObject.FindObjectOfType<CharacterSelectView>().EnableCharacterSelect();
					break;
				case GAME_WINDOWS.GAME: 
					GameObject.FindObjectOfType<LandingPageView>().DisableLandingPage();
					GameObject.FindObjectOfType<CharacterSelectView>().DisableCharacterSelect();
					GameObject.FindObjectOfType<GameUIView>().EnableGameUI();
					break;

			}
		}

	}

}


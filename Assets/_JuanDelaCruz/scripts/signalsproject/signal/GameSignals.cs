/// A Signal for Starting the Context
using System;
using strange.extensions.signal.impl;
using UnityEngine;

namespace JuanDelaCruz {

	public class StartSignal : Signal {}
	public class ShowWindowSignal : Signal<GAME_WINDOWS> {}
	public class CreateNewGameSignal : Signal {}
	public class LoadGameSignal : Signal {}

}


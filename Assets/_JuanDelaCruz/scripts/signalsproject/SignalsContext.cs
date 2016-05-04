/// If you're new to Strange, start with MyFirstProject.
/// If you're interested in how Signals work, return here once you understand the
/// rest of Strange. This example shows how Signals differ from the default
/// EventDispatcher.
/// All comments from MyFirstProjectContext have been removed and replaced by comments focusing
/// on the differences 

using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;

namespace JuanDelaCruz {

	public class SignalsContext : MVCSContext {

		public SignalsContext (MonoBehaviour view) : base(view) {
		}

		public SignalsContext (MonoBehaviour view, ContextStartupFlags flags) : base(view, flags) {
		}
		
		// Unbind the default EventCommandBinder and rebind the SignalCommandBinder
		protected override void addCoreComponents() {
			base.addCoreComponents();
			injectionBinder.Unbind<ICommandBinder>();
			injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
		}
		
		// Override Start so that we can fire the StartSignal 
		override public IContext Start() {
			base.Start();
			StartSignal startSignal= (StartSignal)injectionBinder.GetInstance<StartSignal>();
			startSignal.Dispatch();
			return this;
		}
		
		protected override void mapBindings() {
			injectionBinder.Bind<Player>().To<IPlayer>().ToSingleton();
			injectionBinder.Bind<ShowWindowSignal>().ToSingleton();
//			commandBinder.Bind<ShowWindowSignal>().To<showw
			mediationBinder.Bind<LandingPageView>().To<LandingPageMediator>();
			mediationBinder.Bind<CharacterSelectView>().To<CharacterSelectMediator>();
			//StartSignal is now fired instead of the START event.
			//Note how we've bound it "Once". This means that the mapping goes away as soon as the command fires.
			commandBinder.Bind<StartSignal>().To<StartCommand>().Once ();			
		}
	}
}


using System;
using System.Collections;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace JuanDelaCruz {

	public class DialogueBoxView : View {

		public delegate void OnClickOK();
		public static event OnClickOK OnClickOKEvent;

		public delegate void OnClickYes();
		public static event OnClickYes OnClickYesEvent;

		public delegate void OnClickNo();
		public static event OnClickNo OnClickNoEvent;

		[Inject]
		public IPlayer player { get; set; }

		[SerializeField] GameObject holder;

		public UILabel dialogueLabel;
		public GameObject yesNo;
		public GameObject ok;

		internal void init() {
		}

		public void EnableDialogue() {
			holder.SetActive(true);
		}

		public void DisableDialogue() {
			ok.SetActive(false);
			yesNo.SetActive(false);
			holder.SetActive(false);
		}

		public void OnReceiveDialogue(DIALOGUE_TYPE dialogueType, string dialogueText) {
			dialogueLabel.text = dialogueText;
			switch(dialogueType) {
			case DIALOGUE_TYPE.YES_NO:
				yesNo.SetActive(true);
				break;
			case DIALOGUE_TYPE.OK:
				ok.SetActive(true);
				break;
			case DIALOGUE_TYPE.CONTINUE:
				StartCoroutine ("Continue");
				yesNo.SetActive(true);
				break;
			}
			EnableDialogue();
		}

		private IEnumerator Continue() {
			int countDown = 10;
			while (countDown > 0) {
				dialogueLabel.text = "Continue?\n" + countDown + "\nLives: " + player.lives;
				countDown--;
				yield return new WaitForSeconds(1);
			}
			ClickNo();
		}

		public void ClickYes() {
			AudioManager.instance.PlayButton ();
			if(OnClickYesEvent != null) {
				StopCoroutine("Continue");
				OnClickYesEvent();
			}
			DisableDialogue();
		}

		public void ClickNo() {
			AudioManager.instance.PlayButton ();
			if(OnClickNoEvent != null) {
				StopCoroutine("Continue");
				OnClickNoEvent();
			}
			DisableDialogue();
		}

		public void ClickOK() {
			AudioManager.instance.PlayButton ();
			if(OnClickOKEvent != null) {
				OnClickOKEvent();
			}
			DisableDialogue();
		}
	}

}


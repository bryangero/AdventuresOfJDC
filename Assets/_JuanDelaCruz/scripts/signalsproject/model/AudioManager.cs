using UnityEngine;
using System.Collections;

namespace JuanDelaCruz {

public class AudioManager : MonoBehaviour {

		public AudioClip[] myAudioClips;
		public AudioSource myAudioSource;
		public AudioSource myAudioSourceHitPlayer;
		public AudioSource myAudioSourceHitEnemy;

		/// <summary>The GameSparks Manager singleton</summary>
		public static AudioManager instance = null;

		private void Awake() {
			if (instance == null) // check to see if the instance has a reference
			{
				instance = this; // if not, give it a reference to this class...
				DontDestroyOnLoad(this.gameObject); // and make this object persistent as we load new scenes
			} else // if we already have a reference then remove the extra manager from the scene
			{
				Destroy(this.gameObject);
			}
		}


		public void PlayButton() {
			myAudioSource.clip = myAudioClips[0];
			myAudioSource.Play ();
		}

		public void PlayAttackButton() {
			myAudioSource.clip = myAudioClips[1];
			myAudioSource.Play ();
		}

		public void PlayHitPlayer() {
			myAudioSourceHitPlayer.clip = myAudioClips[2];
			myAudioSourceHitPlayer.Play ();
		}

		public void PlayHitEnemy() {
			myAudioSourceHitEnemy.clip = myAudioClips[3];
			myAudioSourceHitEnemy.Play ();
		}

	}
}

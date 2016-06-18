using UnityEngine;
using System.Collections;

namespace JuanDelaCruz {

	public class EnemyAnim : MonoBehaviour {
		public EnemyDisplay enemyDisplay;
		public Vector3 currPosition;
		public Vector3 targetPos;
		private void Awake() {
//			currPosition = transform.localPosition;
		}

		public void OnFinishAttack() {
			enemyDisplay.OnFinishAttack ();
		}

		public void OnFinishDeath() {
			enemyDisplay.OnFinishDeath ();
		}

	}
}
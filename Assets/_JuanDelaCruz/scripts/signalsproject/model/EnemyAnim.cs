using UnityEngine;
using System.Collections;

namespace JuanDelaCruz {

	public class EnemyAnim : MonoBehaviour {
		public EnemyDisplay enemyDisplay;


		public void OnFinishAttack() {
			enemyDisplay.OnFinishAttack ();
		}

		public void OnFinishDeath() {
			enemyDisplay.OnFinishDeath ();
		}

	}
}
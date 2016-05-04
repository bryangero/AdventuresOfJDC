using UnityEngine;
using System.Collections;

namespace JuanDelaCruz {
	
	public class Instructions : MonoBehaviour {
		[SerializeField] private GameObject goInstruction;

		public void ShowInstruction() {
			goInstruction.SetActive(true);
		}

		public void HideInstruction() {
			goInstruction.SetActive(false);
		}

	}

}
using UnityEngine;
using System.Collections;

namespace JuanDelaCruz {
	
	public class Instructions : MonoBehaviour {
		[SerializeField] private GameObject goInstruction;
		[SerializeField] private GameObject goNonInstruction;

		public void ShowInstruction() {
			goInstruction.SetActive(true);
			goNonInstruction.SetActive(false);
		}

		public void HideInstruction() {
			goInstruction.SetActive(false);
			goNonInstruction.SetActive(true);
		}

	}

}
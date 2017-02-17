using UnityEngine;
using System.Collections;

namespace JuanDelaCruz {
	
	public class Credits : MonoBehaviour {
		[SerializeField] protected GameObject goInstruction;
		[SerializeField] protected GameObject goNonInstruction;

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
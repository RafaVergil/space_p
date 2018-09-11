using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

	public float delay = 5f;

	IEnumerator Start () {
		yield return new WaitForSeconds (delay);
		Destroy (this.gameObject);
	}
}


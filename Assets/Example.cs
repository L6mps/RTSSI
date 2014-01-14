using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour {
	void Update() {
		SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		if (Spawner.getControlledCannon () == transform.parent.name) {
						if (spriteRenderer.color != Color.white)
								spriteRenderer.color = Color.white;
				}
		else
			if (spriteRenderer.color != Color.grey)
						spriteRenderer.color = Color.grey;
	}
}
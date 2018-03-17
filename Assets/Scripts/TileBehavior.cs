using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class TileBehavior : MonoBehaviour {
	private int depth {
		get {
			return (int) (50f * (transform.position.x - transform.position.z) + 2 * transform.position.y);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int layerOrder = depth;
		foreach (Transform child in transform) {
			SpriteRenderer childRenderer = child.GetComponent<SpriteRenderer>();
			childRenderer.sortingOrder = layerOrder;
		}
	}

	void OnDrawGizmosSelected() {
		Gizmos.matrix = Matrix4x4.TRS(transform.localPosition, transform.localRotation, transform.localScale);
		Gizmos.color = new Color(1, 0.5f, 0.15f, 0.5f);
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(1f, 0.5f, 1f));

		GUIStyle style = new UnityEngine.GUIStyle();
		style.fontSize = 30;

		UnityEditor.Handles.Label(transform.position, depth.ToString(), style);
	}
}

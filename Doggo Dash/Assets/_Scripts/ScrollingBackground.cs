using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {


	public float backgroundSize;

	private Transform[] layers;
	private float viewZone = 10;
	private int leftIndex;
	private int rightIndex;

	private void Start(){
	//	cameraTransform = Camera.main.transform;
		layers = new Transform[transform.childCount];
		for (int i = 0; i < transform.childCount; i++)
			layers [i] = transform.GetChild (i);

		leftIndex = 0;
		rightIndex = layers.Length - 1;
	}
	private void Update(){
		if (Input.GetKeyDown (KeyCode.A))
			ScrollLeft ();
		if (Input.GetKeyDown (KeyCode.D))
			ScrollRight ();
	}
	private void ScrollLeft(){
		int lastRight = rightIndex;
		layers [rightIndex].position = Vector3.right * (layers [leftIndex].position.x - backgroundSize);
		leftIndex = rightIndex;
		rightIndex--;
		if (rightIndex < 0)
			rightIndex = layers.Length - 1;
	}
	private void ScrollRight(){
		int lastLeft = leftIndex;
		layers [leftIndex].position = Vector3.right * (layers [leftIndex].position.x + backgroundSize);
		rightIndex = leftIndex;
		leftIndex++;
		if (leftIndex == layers.Length)
			leftIndex = 0;
	}
}
using UnityEngine;
using System.Collections;

public class SlideDoor : DoorComponent {

	public Vector3 startLocation;
	public Vector3 endLocation;
	public float duration = 1;

	void Start(){
		startLocation = transform.localPosition;
	}

	void Update(){
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, (isActive) ? endLocation : startLocation, duration * Time.deltaTime);
	}
}

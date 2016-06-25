using UnityEngine;
using System.Collections;

public class SlideDoor : DoorComponent {

	public Vector3 startLocation;
	public Vector3 endLocation;
	public float duration = 1;

	void Update(){
		transform.position = Vector3.MoveTowards(transform.position, (isActive) ? endLocation : startLocation, duration * Time.deltaTime);
	}
}

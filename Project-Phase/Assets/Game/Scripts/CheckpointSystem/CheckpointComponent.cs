using UnityEngine;
using System.Collections;

public class CheckpointComponent : MonoBehaviour {

	public int OrderID;
	
	
	//When checkpoint activated call the event
	void Activated(){
        Events.OnCheckpointActivatedEvent(new Events.EventChecpointActivated(this.gameObject));
	}
	
	void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player"){
			Activated();
		}
    }
}

using UnityEngine;
using System.Collections;

public class TabletPickUp : InteractableLookAtComponent {

	public override void OnInteract(){
		Events.onTabletPickedUpEvent();
		Destroy(this.gameObject);
	}
}

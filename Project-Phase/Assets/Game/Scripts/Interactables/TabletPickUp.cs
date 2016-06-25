using UnityEngine;
using System.Collections;

public class TabletPickUp : InteractableLookAtComponent {

	public override void OnInteract() {
        if (Events.onTabletPickedUpEvent != null) Events.onTabletPickedUpEvent();
		Destroy(this.gameObject);
	}
}

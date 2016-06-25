using UnityEngine;
using System.Collections;

public class PlayerKillComponent : TriggerComponent {

	public override void TriggerEvent(GameObject collisionObj){

		if (collisionObj.tag == GameManager.Tags.PLAYER){
			Destroy(collisionObj);
			Events.onPlayerDeathEvent();
		}

	}

}

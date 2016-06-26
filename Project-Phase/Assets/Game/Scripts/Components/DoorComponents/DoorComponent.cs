using UnityEngine;
using System.Collections;

public abstract class DoorComponent : MonoBehaviour {

    public bool isActive = false;

    public virtual void OnActivate() {
        isActive = true;
    }

    public virtual void OnDeactivate() {
        isActive = false;
    }
}

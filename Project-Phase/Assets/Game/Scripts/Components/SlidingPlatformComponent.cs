using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class SlidingPlatformComponent : MonoBehaviour {

    public GameObject targetObject;
    public float maxSpeed = 2f;
    public float completeRange = 0.5f;
    public float dragMultiplier = 0.8f;
    private Vector3 directionToTarget;
    private bool isComplete = false;
    private Rigidbody body;
    private Vector3 startPosition;
    private float distanceToTarget;
    private float lastDistanceToTarget;


    void Awake() {
        body = GetComponent<Rigidbody>();
        startPosition = transform.position;
        directionToTarget = targetObject.transform.position - startPosition;
        distanceToTarget = directionToTarget.sqrMagnitude;
        lastDistanceToTarget = distanceToTarget;
    }

    void Start() {
        body.velocity = Vector3.zero;
    }

    void FixedUpdate() {
        directionToTarget = targetObject.transform.position - transform.position;
        distanceToTarget = directionToTarget.sqrMagnitude;
        if (!isComplete && distanceToTarget < completeRange * completeRange) {
            isComplete = true;
            body.velocity = Vector3.zero;
            body.isKinematic = true;
        }

        if (isComplete || distanceToTarget > lastDistanceToTarget) {
            body.velocity = Vector3.zero;
        } else {            
            //float speed = Vector3.Dot(body.velocity, movementVector);
            //body.velocity = Quaternion.AngleAxis(Vector3.Angle(body.velocity.normalized, movementVector.normalized), Vector3.up)* body.velocity;
            //if (speed > 1) body.velocity = movementVector.normalized * ((speed > maxSpeed) ? maxSpeed : speed);
            //else body.velocity = Vector3.zero;

            body.velocity = directionToTarget.normalized * body.velocity.magnitude;
        }
        lastDistanceToTarget = distanceToTarget;
    }
}
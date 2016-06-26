using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class SlidingPlatformComponent : MonoBehaviour {

    public GameObject targetObject;
    public float maxSpeed = 0.25f;
    public float completeRange = 0.5f;
    public float dragForce = 10f;
    private Vector3 movementVector;
    private bool isComplete = false;
    private Rigidbody body;
    private Vector3 startPosition;
    private float distanceToTarget;
    private float lastDistanceToTarget;


    void Awake() {
        body = GetComponent<Rigidbody>();
        startPosition = transform.position;
        movementVector = targetObject.transform.position - startPosition;
        distanceToTarget = movementVector.sqrMagnitude;
        lastDistanceToTarget = distanceToTarget;
    }

    void Start() {
        body.velocity = Vector3.zero;
    }

    void FixedUpdate() {
        Vector3 directionToTarget = targetObject.transform.position - transform.position;
        distanceToTarget = directionToTarget.sqrMagnitude;
        if (!isComplete && distanceToTarget < completeRange * completeRange) {
            isComplete = true;
            body.velocity = Vector3.zero;
            body.isKinematic = true;
        }

        if (isComplete || distanceToTarget > lastDistanceToTarget) {
            body.velocity = Vector3.zero;
        } else {
            float speed = Vector3.Dot(body.velocity, movementVector);       
            body.velocity = movementVector * ((speed > maxSpeed)? maxSpeed : speed);
        }
        lastDistanceToTarget = distanceToTarget;
    }
}

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour {

    /// <summary>Player powers, used by UsePower()</summary>
    public enum EPower {
        PUSH, PULL
    }

    [Header("Movement")]
    [Tooltip("How fast the player accelerates")]
    public float movementSpeed = 40f;
    public float maxSpeed = 6f;
    [Tooltip("Jump froce, ignoring mass")]
    public float jumpForce = 2f;
    [Tooltip("Delay between when the player can jump")]
    public float jumpDelay = 0.3f;

    [Header("Powers")]
    [Tooltip("Range of the player's power in units")]
    public float powerRange = 4f;
    [Tooltip("Delay between when the player can use their powers")]
    public float powerDelay = 0.5f;
    public float pushPower = 100f;
    public float pullPower = 120f;

    [Header("Interaction")]
    [Tooltip("How far away the player can interact with lookAt objects")]
    public float interactRange = 1.5f;

    [Header("Controls")]
    public MouseLook mouseLook = new MouseLook();

    // Internal forward speed
    private float _speed = 0;
    // Forward speed of the player
    public float speed {
        get { return _speed; }
    }
    // Internal lateral speed
    private float _speedLateral = 0;
    // Lateral speed of the player, where right is positive and left is negative
    public float speedLateral {
        get { return _speedLateral; }
    }

    // Whether a jump was just performed
    private bool isJumping = false;
    // Counter for jump delay
    private float jumpCounter = 0;
    // Whether powers are currently on cooldown and can't be used
    private bool powersOnCooldown = false;
    // Counter for power delay
    private float powerCounter = 0;
    // Whether the player is currently on the ground
    private bool onGround = false;

    // Surface vectors used for smooth movement over uneven terrain and slopes
    private Vector3 surfaceNormal;
    private Vector3 surfaceForwardVector;
    private Vector3 surfaceRightVector;

    private Animator animPlayerArm;
    private HUD playerHUD;
    private GameManager gameManager;

    // Cache of input values
    private Dictionary<InputMappings.EAction, float> InputValues = new Dictionary<InputMappings.EAction, float>() {
        {InputMappings.EAction.MOVE_FORWARD, 0},
        {InputMappings.EAction.MOVE_RIGHT, 0},
        {InputMappings.EAction.JUMP, 0},
        {InputMappings.EAction.PUSH, 0},
        {InputMappings.EAction.PULL, 0},
        {InputMappings.EAction.SWITCH_PHASE, 0},
        {InputMappings.EAction.INTERACT, 0},
        {InputMappings.EAction.RESTART, 0}
    };
    // Input Values last frame
    private Dictionary<InputMappings.EAction, float> LastInputValues;

    private CapsuleCollider bodyCollider;
    private Rigidbody body;


    void Awake() {
        gameManager = GameObject.FindGameObjectWithTag(GameManager.Tags.GAME_MANAGER).GetComponent<GameManager>();
        if (gameManager == null) {
            throw new UnityException("Scene needs a GameManager instance with tag: " + GameManager.Tags.GAME_MANAGER);
        }
        body = GetComponent<Rigidbody>();
        bodyCollider = GetComponent<CapsuleCollider>();
        animPlayerArm = GameObject.FindGameObjectWithTag(GameManager.Tags.PLAYER_ARM).GetComponent<Animator>();
        playerHUD = GameObject.FindGameObjectWithTag(GameManager.Tags.PLAYER_HUD).GetComponent<HUD>();

        // Defaults
        surfaceForwardVector = body.transform.forward;
        surfaceRightVector = body.transform.right;
        LastInputValues = InputValues;
    }

    void Start() {
        mouseLook.Init(transform, Camera.main.transform);
    }

	void Update () {
        mouseLook.LookRotation(transform, Camera.main.transform);
        HandleInput();
        
        // Interactable object polling
        playerHUD.displayText("");
        RaycastHit cameraHit;
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out cameraHit, interactRange);
        if (cameraHit.distance != 0) {
            LookAtComponent lookAtTarget = cameraHit.collider.GetComponentInParent<LookAtComponent>();
            if (lookAtTarget) {
                // If target is an instance of LookAtComponent, display info on the HUD
                playerHUD.displayText(lookAtTarget.infoText);
                // If Interact is pressed and the target is an InteractableLookAtComponent, interact with it
                if (InputValues[InputMappings.EAction.INTERACT] == 1) {
                    try {
                        InteractableLookAtComponent interactable = (InteractableLookAtComponent)lookAtTarget;
                        interactable.OnInteract();    
                    } catch (InvalidCastException) { /* Not an interactable */ }                    
                }
            }
        }

        // Update forward and lateral speed
        _speed = surfaceForwardVector.x * body.velocity.x +
                 surfaceForwardVector.y * body.velocity.y +
                 surfaceForwardVector.z * body.velocity.z;
        _speedLateral = surfaceRightVector.x * body.velocity.x +
                        surfaceRightVector.y * body.velocity.y +
                        surfaceRightVector.z * body.velocity.z;

        // Ground hit detection and surface vectors
        RaycastHit hit;
        // Raycast down from just above the player's feet
        Physics.Raycast(body.transform.position - body.transform.up * (bodyCollider.height / 2 - 0.05f), -body.transform.up, out hit, 0.25f);
        //Debug.DrawLine(body.transform.position - body.transform.up * (bodyCollider.height / 2 - 0.05f), body.transform.position - body.transform.up * (bodyCollider.height / 2 - 0.05f) - (body.transform.up * 0.25f));
        onGround = hit.distance != 0;
        if (onGround) {
            // Project directional vectors onto the surface
            surfaceNormal = hit.normal;
            surfaceForwardVector = Vector3.ProjectOnPlane(body.transform.forward, surfaceNormal);
            surfaceRightVector = Vector3.ProjectOnPlane(body.transform.right, surfaceNormal);
        } else {
            // If in air, use player directional vectors
            surfaceForwardVector = body.transform.forward;
            surfaceRightVector = body.transform.right;
        }
        //Debug.DrawLine(body.transform.position, body.transform.position + surfaceForwardVector * 2);
        //Debug.DrawLine(body.transform.position, body.transform.position + surfaceRightVector * 2);
        //Debug.DrawLine(Camera.main.transform.position, Camera.main.transform.position + Camera.main.transform.forward * powerRange);

        // Jump delay counter
        if (isJumping) {
            jumpCounter += Time.deltaTime;
            if (jumpCounter >= jumpDelay) {
                isJumping = false;
                jumpCounter = 0;
            }
        }
        // Power delay counter
        if (powersOnCooldown) {
            powerCounter += Time.deltaTime;
            if (powerCounter >= powerDelay) {
                powersOnCooldown = false;
                powerCounter = 0;
            }
        }

        LastInputValues = InputValues;
	}

    void FixedUpdate() {
        // Move forward/backward
        if (InputValues[InputMappings.EAction.MOVE_FORWARD] != 0 && Mathf.Abs(speed) < maxSpeed) {
            body.AddForce(
                body.transform.forward * movementSpeed * InputValues[InputMappings.EAction.MOVE_FORWARD], 
                ForceMode.Acceleration
            );
        }

        // Move right/left
        if (InputValues[InputMappings.EAction.MOVE_RIGHT] != 0 && Mathf.Abs(speedLateral) < maxSpeed) {
            body.AddForce(
                body.transform.right * movementSpeed * InputValues[InputMappings.EAction.MOVE_RIGHT], 
                ForceMode.Acceleration
            );
        }

        // Stop on no input when not in air
        if (!IsInAir()) {
            if (InputValues[InputMappings.EAction.MOVE_FORWARD] == 0) {
                body.velocity -= Vector3.Project(body.velocity, surfaceForwardVector);
            }
            if (InputValues[InputMappings.EAction.MOVE_RIGHT] == 0) {
                body.velocity -= Vector3.Project(body.velocity, surfaceRightVector);
            }
        }
    }

    /// <summary>
    /// Jumps if the player currently can
    /// </summary>
    public void Jump() {
        if (CanJump()) {
            body.AddForce(body.transform.up * jumpForce * body.mass, ForceMode.Impulse);
        }
    }

    public bool CanJump() {
        return !isJumping && !IsInAir();
    }

    public bool IsInAir() {
        return !onGround;
    }

    private void UsePower(EPower power) {
        if (powersOnCooldown) return;
        // Target interactable to be found using a ray
        InteractablePhasedObject target = null;
        RaycastHit hit;
        // Ray from the centre of the camera forward by powerRange
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, powerRange);
        // If the ray hit an InteractablePhasedObject and the object is enabled, powers can be used
        if (hit.rigidbody != null) target = hit.rigidbody.GetComponentInParent<InteractablePhasedObject>();

        Vector3 force = Vector3.zero;
        switch (power) {
            case EPower.PUSH:
                force = surfaceForwardVector * pushPower;
                if (animPlayerArm) animPlayerArm.SetTrigger("Push");
                break;
            case EPower.PULL:
                force = -surfaceForwardVector * pullPower;
                if (animPlayerArm) animPlayerArm.SetTrigger("Pull");
                break;
        }
        if (target != null && target.isEnabled) {
            target.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        }
        powersOnCooldown = true;
    }

    /// <summary>
    /// Gets input and stores it in InputValues and handles non-physics input
    /// </summary>
    private void HandleInput() {
        InputValues[InputMappings.EAction.MOVE_FORWARD] = InputMappings.GetInput(InputMappings.EAction.MOVE_FORWARD);
        InputValues[InputMappings.EAction.MOVE_RIGHT] = InputMappings.GetInput(InputMappings.EAction.MOVE_RIGHT);
        InputValues[InputMappings.EAction.JUMP] = InputMappings.GetInput(InputMappings.EAction.JUMP);
        InputValues[InputMappings.EAction.SWITCH_PHASE] = InputMappings.GetInput(InputMappings.EAction.SWITCH_PHASE);
        InputValues[InputMappings.EAction.PUSH] = InputMappings.GetInput(InputMappings.EAction.PUSH);
        InputValues[InputMappings.EAction.PULL] = InputMappings.GetInput(InputMappings.EAction.PULL);
        InputValues[InputMappings.EAction.INTERACT] = InputMappings.GetInput(InputMappings.EAction.INTERACT);

        if (InputValues[InputMappings.EAction.JUMP] == 1) {
            Jump();
        }

        if (InputValues[InputMappings.EAction.SWITCH_PHASE] == 1) {
            gameManager.SwitchPhase();
        }

        if (InputValues[InputMappings.EAction.RESTART] == 1) {
            gameManager.ReloadLevel();
        }

        // Powers
        if (InputValues[InputMappings.EAction.PUSH] == 1) {
            UsePower(EPower.PUSH);
        } else if (InputValues[InputMappings.EAction.PULL] == 1) {
            UsePower(EPower.PULL);
        }
    }
}

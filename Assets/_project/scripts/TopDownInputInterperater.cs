using UnityEngine;
using System.Collections;

public class TopDownInputInterperater : CharacterController {
	
	void Update () {

        Vector3 movementDelta = GetInputMovementDelta();
        UpdateRotation(movementDelta);
        movementDelta = MovementVectorPhysicsUpdate(movementDelta);
        transform.position += movementDelta;
	}

    // Return a normalized vector describing the desired direction of travel base on key input
    Vector3 GetInputMovementDelta() {
        if (!Input.anyKey) return Vector3.zero;
        // If in rts mode disregard key input
        if (ControlModeManager.mode == ControlMode.rts) return Vector3.zero;

        Vector3 delta = Vector3.zero;

        if (Input.GetKey(KeyAtlas.moveForward)) {
            delta += Vector3.forward;
        }
        if (Input.GetKey(KeyAtlas.moveLeft)) {
            delta += Vector3.left;
        }
        if (Input.GetKey(KeyAtlas.moveBackward)) {
            delta += Vector3.back;
        }
        if (Input.GetKey(KeyAtlas.moveRight)) {
            delta += Vector3.right;
        }
        return delta.normalized;
    }
}

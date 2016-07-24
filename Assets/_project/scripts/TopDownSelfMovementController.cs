using UnityEngine;
using System.Collections;

public class TopDownSelfMovementController : CharacterController {
    Vector3 selectedDestination;
    bool arrived = true;

    void Update() {
        // If mode switches to individual cancel move order and disregard all rts movements
        if (ControlModeManager.mode == ControlMode.individual) {
            arrived = true;
            return;
        }
        // If object has arrived do no movement
        if (arrived) return;
        // Move to selectedDestination
        Vector3 movementDelta = GetSelfMovementDelta();
        UpdateRotation(movementDelta);
        movementDelta = MovementVectorPhysicsUpdate(movementDelta);
        transform.position += movementDelta;
        // Check if we have arrived
        if (Vector3.Distance(transform.position, selectedDestination) < 2) arrived = true;
    }

    // Get a normalized delta from where we are to our selectedDestination
    Vector3 GetSelfMovementDelta() {
        Vector3 directionVector = selectedDestination - transform.position;
        directionVector.y = 0;
        return (directionVector).normalized;

    }

    // Public function to tell this Object to move to iputDestination
    public void MoveToTarget(Vector3 inputDestination) {
        selectedDestination = inputDestination;
        arrived = false;
    }
}

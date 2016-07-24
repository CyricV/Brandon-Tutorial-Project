using UnityEngine;
using System.Collections;

public class CameraLightController : CharacterController {
    public GameObject camera;

    void Update() {
        Vector3 movementDelta = GetInputMovementDelta();
        UpdateRotation(movementDelta);
        movementDelta = MovementVectorPhysicsUpdate(movementDelta);
        transform.position += movementDelta;
        if (ControlModeManager.mode == ControlMode.individual) {
            Vector3 offsetCameraPos = new Vector3(camera.transform.position.x, 1f, camera.transform.position.z);
            Vector3 destination = Vector3.Lerp(transform.position, offsetCameraPos, 0.1f);
            transform.position = destination;
        }
    }

    Vector3 GetInputMovementDelta() {
        if (!Input.anyKey) return Vector3.zero;
        if (ControlModeManager.mode == ControlMode.individual) return Vector3.zero;

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

using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {
    public float moveSpeed      = 0.5f;
    public float turnSpeed      = 10.0f;
    public float friction       = 5.0f;
    Vector3 velocity            = Vector3.zero;

    // Apply physics to the movement of a 'character'
    public Vector3 MovementVectorPhysicsUpdate (Vector3 inputVector) {
        Vector3 outputVector = Vector3.zero;
        velocity += inputVector * Time.deltaTime;
        //velocity *= friction; This intuitive method of representing friction is not the best way to do things due to how detaTime functions
        velocity -= velocity * friction * Time.deltaTime;
        outputVector = velocity;
        return outputVector * moveSpeed;
    }

    // Cause the character to rotate towards its intended direction of travel
    public void UpdateRotation(Vector3 inputVector) {
        if (inputVector.magnitude < 0.5) return;
        float yAngle = Mathf.Atan2(inputVector.x, inputVector.z);
        Quaternion targetRotation = Quaternion.Euler(0, Mathf.Rad2Deg * yAngle, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed*Time.deltaTime);
    }
}

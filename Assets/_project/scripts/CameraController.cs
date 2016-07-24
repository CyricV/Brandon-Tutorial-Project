using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public static CameraController main;
    public GameObject cameraTarget;
    public GameObject controlCameraTarget;
    public float cameraSpeed = 8.0f;
    Camera camera;

	void Awake () {
        main = this;
        camera = Camera.main;
	}

    void Update() {
        if(Input.GetMouseButtonDown(0)){
            clickToWorld();
        }

        Vector3 targetPos = new Vector3(0, 0, 0);
        if (ControlModeManager.mode == ControlMode.rts) {
            //Debug.Log("Modifier Pressed");
            targetPos = controlCameraTarget.transform.position + new Vector3(0, 4, 0);
        } else {
            targetPos = cameraTarget.transform.position;
        }
        Vector3 offsetPos = targetPos + new Vector3(0, 5, 0);
        Vector3 destination = Vector3.Lerp(transform.position, offsetPos, Time.deltaTime * cameraSpeed);
        transform.position = destination;
	}

    void clickToWorld() {
        Ray mouseRay = camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(mouseRay.origin, mouseRay.direction);
        RaycastHit hit;
        if (Physics.Raycast(mouseRay, out hit)) {
            cameraTarget.GetComponent<TopDownSelfMovementController>().MoveToTarget(hit.point);
        }
    }
}

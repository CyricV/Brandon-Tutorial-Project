using UnityEngine;
using System.Collections;

// Contains the present game mode and toggles on key press
public class ControlModeManager : MonoBehaviour {
    public static ControlMode mode = ControlMode.individual;
    bool toggleKeyUp = true;
	
	void Update () {
        if (mode == ControlMode.individual &&
            Input.GetKeyDown(KeyAtlas.toggle1) &&
            toggleKeyUp) {
            mode = ControlMode.rts;
            Debug.Log("RTS MODE");
            toggleKeyUp = false;
        }
        if (mode == ControlMode.rts &&
            Input.GetKeyDown(KeyAtlas.toggle1) &&
            toggleKeyUp) {
            mode = ControlMode.individual;
            Debug.Log("INDIVIDUAL MODE"); ;
            toggleKeyUp = false;
        }
        if (Input.GetKeyUp(KeyAtlas.toggle1)) {
            toggleKeyUp = true;
        }
	}
}

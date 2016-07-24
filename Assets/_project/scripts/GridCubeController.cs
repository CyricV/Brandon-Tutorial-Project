using UnityEngine;
using System.Collections;

public class GridCubeController : MonoBehaviour {
    public int xKillRange = 12;
    public int zKillRange = 12;
    TileGenerator.IntPair selfLocation = new TileGenerator.IntPair();

	void Start () {
        // Add x, y to Hash Set
        selfLocation.x = (int)transform.position.x;
        selfLocation.z = (int)transform.position.z;
        TileGenerator.gridCubeLocationManifestParty.Add(selfLocation);
	}

	void Update () {
        Vector3 cameraPos = CameraController.main.transform.position;
        Vector3 selfPos = transform.position;
        if (Mathf.Abs(cameraPos.z - selfPos.z) >= zKillRange ||
            Mathf.Abs(cameraPos.x - selfPos.x) >= xKillRange) {
            // Remove self from Hash Set
            TileGenerator.gridCubeLocationManifestParty.Remove(selfLocation);
            // Kill self
            GameObject.Destroy(this.gameObject); // the 'this' is implicite and refers to the script specifically.
        }
	}
    void PrintHashCount() {
        Debug.Log("Hash count: "+TileGenerator.gridCubeLocationManifestParty.Count);
    }
}

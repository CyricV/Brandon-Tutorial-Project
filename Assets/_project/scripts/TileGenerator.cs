using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileGenerator : MonoBehaviour {
    public int boardWidth = 10;
    public int boardHeight = 10;
    public struct IntPair{
        public int x;
        public int z;
        public IntPair(int x, int z) {
            this.x = x;
            this.z = z;
        }
    };
    public static HashSet<IntPair> gridCubeLocationManifestParty = new HashSet<IntPair>();

	void Start () {
        //for (int i = -boardWidth; i < boardWidth; i++) {
        //    for (int j = -boardHeight; j < boardHeight; j++) {
        //        GameObject gridCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //        gridCube.transform.position = new Vector3(i, j, 1);
        //        gridCube.AddComponent<GridCubeController>();
        //        string materialName;
        //        if ((i + j) % 2 == 0) {
        //            materialName = "matBlack";
        //        } else {
        //            materialName = "matWhite";
        //        }
        //        gridCube.GetComponent<MeshRenderer>().material = Resources.Load(materialName) as Material;
        //    }
        //}
        SpawnCubes();
	
	}
	
	void Update () {
	    SpawnCubes();
	}

    void SpawnCubes() {
        for (int i = (int)transform.position.x - boardWidth; i<transform.position.x + boardWidth; i++) {
            for (int j = (int)transform.position.z - boardHeight; j<transform.position.z + boardHeight; j++) {
                IntPair newCubeLoc = new IntPair(i,j);
                if (!gridCubeLocationManifestParty.Contains(newCubeLoc)) {
                    GameObject gridCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    gridCube.name = "Cube " + i + ", " + j;
                    gridCube.transform.position = new Vector3(i, -1, j);
                    gridCube.AddComponent<GridCubeController>();
                    string materialName;
                    if((i+j) % 2 == 0) {
                        materialName = "matBlack";
                    } else {
                        materialName = "matWhite";
                    }
                    gridCube.GetComponent<MeshRenderer>().material = Resources.Load(materialName) as Material;
                }
            }
        }
    }
}

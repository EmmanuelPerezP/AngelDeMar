using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpawnTileLeft : MonoBehaviour {

    public GameObject mariposa;
    public GameObject pezGlobo;
    //public GameObject ;


    // Use this for initialization
    void Start () {
        System.Random rnd = new System.Random(); // creates a number between 1 and 10
        int numbRand = rnd.Next(1, 10);

        if(numbRand < 3)
        {

        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

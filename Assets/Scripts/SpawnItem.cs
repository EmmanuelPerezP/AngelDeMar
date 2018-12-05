using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour {

    public GameObject mariposa;
    public GameObject pezGlobo;
    public GameObject powerUp;
    public GameObject powerUp2;

    //public GameObject ;


    // Use this for initialization
    void Start()
    {
        System.Random rnd = new System.Random(); // creates a number between 1 and 10
        int numbRand = rnd.Next(1, 100);

        if (numbRand <= 60)
        {
            GameObject objeto = Instantiate(mariposa);
            objeto.transform.parent = gameObject.transform;
            objeto.transform.localPosition = new Vector3(0f,1f);
        }
        else if (numbRand > 40 && numbRand <= 60)
        {
            //GameObject objeto = Instantiate(pezGlobo);
            //objeto.transform.parent = gameObject.transform;
            //objeto.transform.localPosition = new Vector3(-2f, 1f);
        }
        else if(numbRand >= 60 && numbRand <= 80)
        {
            GameObject objeto = Instantiate(powerUp);
            objeto.transform.parent = gameObject.transform;
            objeto.transform.localPosition = new Vector3(0f, 1f);
        }
        else if (numbRand >= 80 && numbRand <= 100)
        {
            GameObject objeto = Instantiate(powerUp2);
            objeto.transform.parent = gameObject.transform;
            objeto.transform.localPosition = new Vector3(0f, 1f);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}

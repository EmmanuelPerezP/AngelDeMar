using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    Rigidbody2D body;
    public int xForce = 3;
    public int yForce = 20;
    public int speed;
    private Queue<GameObject> niveles;
    public GameObject nivelPrefab;
    public float lastElementCoordOffset;
    private Vector3 cameraPosition;
    private System.Random randomGen; // creates a number between 1 and 12
    private int numeroRand;
    public float distanceOfNewLevel;
    public bool moveWithoutPlayer; // move withoutplayer debug mode
    public GameObject prefabBackground;
    public GameObject prefabForeground;
    public GameObject background1;
    public GameObject foreground;

    public GameObject prefabCollectible;


    // Use this for initialization
    void Start () {
        randomGen = new System.Random();
        numeroRand = randomGen.Next(0, 2);
        lastElementCoordOffset = 20f;
        body = GetComponent<Rigidbody2D>();
        niveles = new Queue<GameObject>();
        cameraPosition = Camera.main.gameObject.transform.position;
        float newObjectCoord = 117;
        System.Random rnd = new System.Random(); // creates a number between 1 and 12
        int numbRand = rnd.Next(0, 3); // creates a number between 1 and 12
        for (int i = 0; i < 9; i++)
        {
            int newRandNumber = rnd.Next(0, 3);
            while (numbRand == newRandNumber)
            {
                newRandNumber = rnd.Next(0, 3);
            }
            Vector3 pos = new Vector3(-5f, newObjectCoord, -4.95f);
            GameObject nivel = Instantiate(nivelPrefab, pos, Quaternion.identity);
            nivel.transform.GetChild(newRandNumber).gameObject.SetActive(true);
            niveles.Enqueue(nivel);
            numbRand = newRandNumber; //stores old random
            //numbRand = rnd.Next(0, 2); // creates a number between 0 and 2
            newObjectCoord += 4;
        }
    }

    // Update is called once per frame
    void Update () {
        // Camera Movement
        cameraPosition = Camera.main.gameObject.transform.position;
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        if ((go != null) || this.moveWithoutPlayer)
        {
            float step = 0.1f * Time.deltaTime * speed;
            cameraPosition.y += step;
            Camera.main.gameObject.transform.position = cameraPosition;
        }
        // Background Generation
        float gapsize = cameraPosition.y - background1.transform.position.y;
        if (gapsize >= 10f)
        {
            float y;
            y = background1.transform.position.y + 52f;

            Vector3 pos = new Vector3(-1f, y, 21f);
            background1 = Instantiate(prefabBackground, pos, Quaternion.identity);
            gapsize = cameraPosition.y - background1.transform.position.y;
        }

        // Foreground Generation
        gapsize = cameraPosition.y - foreground.transform.position.y;
        if (gapsize >= 16.6f)
        {
            float y;
            y = foreground.transform.position.y + 40.9f;

            Vector3 pos = new Vector3(-6.7f, y, 33f);
            foreground = Instantiate(prefabForeground, pos, Quaternion.identity);
            gapsize = cameraPosition.y - foreground.transform.position.y;
        }

        // Tile generation
         // creates a number between 1 and 2
        // si la distancia entre el offset y la camara es menor que la distancia del ultimo elemto se descola y se pone atras en la cola cambiando la coordenada
        float positionUltimoNivel = niveles.Peek().transform.position.y;
        float positionCameraLimit = cameraPosition.y - lastElementCoordOffset;

        if ( positionUltimoNivel < positionCameraLimit){
            int newRandNumber = randomGen.Next(0, 3);
            while(numeroRand == newRandNumber)
            {
                newRandNumber = randomGen.Next(0, 3);
            }
            Destroy(niveles.Dequeue());
            float y;
            y = cameraPosition.y + distanceOfNewLevel;
            // magic numbers are so beautiful
            Vector3 pos = new Vector3(-5f, y, -3f);
            GameObject nivel = Instantiate(nivelPrefab, pos, Quaternion.identity);
            nivel.transform.GetChild(newRandNumber).gameObject.SetActive(true);
            numeroRand = newRandNumber; //stores old random
            niveles.Enqueue(nivel);
        }


        //float goY = go.transform.position.y;
    }
}

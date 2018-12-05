using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Player : MonoBehaviour {

    Rigidbody2D body;
    public LayerMask tileLayer;
    public LayerMask bigFish;

    public int score = 0;
    public int xAir = 5;
    public Text scoreText;
    //public int xForce = 10;
    public int xForce = 3;
    public int yForce = 20;
    public CameraScript cameraScript;
    //public int yForce = 1800;
    private Animator anim;                  //Reference to the Animator component.
    private bool doubleJump;
    public Text jump;
    public AudioSource getItem;


    // Use this for initialization
    void Start()
    {
        doubleJump = false;
        score = 0;
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        scoreText.text = score.ToString();
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {

        //float x = Input.GetAxis("Fire1");
        bool jumpDown = Input.GetButtonDown("Jump");
        bool jumpHeld = Input.GetButton("Jump");
        bool jumpUp = Input.GetButtonUp("Jump");
        float horizontal = Input.GetAxis("Horizontal");
        //if (x > 0)
        //{
        //    body.AddForce(new Vector3(1, 20, 0));
        //}
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        Debug.DrawRay(position, direction, Color.green);

        if (jumpDown && IsGrounded() && !FishEated())
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            anim.SetBool("Flap", true);
            if (horizontal > 0)
            {
                body.velocity = new Vector3(xForce, yForce, 0);
                //body.AddForce(new Vector3(xForce, yForce, 0));
                //body.AddForce(new Vector3(0, 2000, 0));

            }
            else if (horizontal < 0)
            {
                body.velocity = new Vector3(-xForce, yForce, 0);
                //body.AddForce(new Vector3(-xForce, yForce, 0));
                //body.AddForce(new Vector3(0, 2000, 0));

            }
            else
            {
                body.velocity = new Vector3(0, yForce, 0);
                //body.AddForce(new Vector3(0, 2000, 0));

            }
        }
        else if (!FishEated())
        {
            if (doubleJump && jumpDown && !IsGrounded())
            {
                body.velocity = new Vector3(0, yForce-8, 0);
                doubleJump = false;
                jump.text = "";
            }
            if (horizontal > 0)
            {
                //body.AddForce(new Vector3(xAir, 0, 0));
                Vector3 v = body.velocity;
                v.x = xAir;
                body.velocity = v;
            }
            else if (horizontal < 0)
            {
                Vector3 v = body.velocity;
                v.x = -xAir;
                body.velocity = v;
                //body.velocity = new Vector3(-xAir, 0, 0);
                //body.AddForce(new Vector3(-xAir, 0, 0));
            }
        }
        else if (FishEated())
        {
            Dead();
        }

        //else if (jumpHeld)
        //{
        //    body.AddForce(new Vector3(1, 20, 0));
        //}
        //else if (jumpUp)
        //{
        //    body.AddForce(new Vector3(1, 20, 0));
        //}
        //else
        //{
        //    body.AddForce(new Vector3(1, 20, 0));
        //}

    }

    public void end()
    {
        anim.SetBool("Flap", false);
    }

    bool IsGrounded()
    {

        Vector2 position = transform.position;
        Vector2 position2 = transform.position;
        position2.x -= 1f;

        //position.x =+ 
        Vector2 direction = new Vector2(0, -2.0f); //Vector2.down;
        Vector2 direction2 = new Vector2(-1f, -2.0f); //Vector2.down;

        float distance = 2.0f;
        Debug.DrawRay(position, direction, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, tileLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(position, direction2, distance, tileLayer);

        if (hit.collider != null || hit2.collider!=null)
        {
            return true;
        }

        return false;
    }

    bool FishEated()
    {

        Vector2 position = transform.position;
        Vector2 direction = new Vector2(0, -2.0f); //Vector2.down;
        float distance = 2.0f;
        Debug.DrawRay(position, direction, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, bigFish);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("PickUpMariposa"))
        {
            other.gameObject.SetActive(false);
            this.score += 1;
            scoreText.text = "Puntaje: " + score.ToString();
            cameraScript.speed += 3; //C#
            getItem.Play();

        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Dead();
        }
        else if (other.gameObject.CompareTag("PowerUp1"))
        {
            //body.velocity = new Vector3(0, 3, 0);
            other.gameObject.SetActive(false);
            gameObject.transform.GetChild(0).gameObject.GetComponent<Light>().intensity += 1;
            this.score += 1;
            scoreText.text = "Puntaje: " + score.ToString();
            getItem.Play();
        }

        else if (other.gameObject.CompareTag("PowerUp2"))
        {
            //body.velocity = new Vector3(0, 3, 0);
            other.gameObject.SetActive(false);
            doubleJump = true;
            jump.text = "△";
            this.score += 1;
            scoreText.text = "Puntaje: " + score.ToString();
            getItem.Play();
        }
    }

    void Dead()
    {
        //animation.Play(animDie.name);
        //Destroy(this.gameObject);
        //SceneManager.LoadScene("SceneDeath");

    }
}

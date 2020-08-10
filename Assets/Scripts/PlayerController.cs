using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed;
    public float jumpHeight;
    private bool inAir;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        playerRb.freezeRotation = true;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        //player jumps when space key is pressed and not in the air
        if(Input.GetKeyDown(KeyCode.Space) && !inAir)
        {
            playerRb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            inAir = true;
        }

        //move player with left/right arrow or a/d keys
        Vector3 tempVect = new Vector3(h, 0, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        playerRb.MovePosition(transform.position + tempVect);


    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            inAir = false;
            gameManager.UpdateLives();
        }

        if(collision.gameObject.CompareTag("Crate"))
        {
            Vector3 normal = collision.contacts[0].normal;

            string side = collision.gameObject.GetComponent<CrateController>().getSide(normal);
            if(side == "top")
            {
                inAir = false;
            }
            else if (side == "bottom" && !inAir)
            {
                Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>() );
            }
        }
    }

    /*private void OnCollisionExit(Collision collision)
    {
        inAir = true;
    }*/
}

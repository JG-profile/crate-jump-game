using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour
{
    public float speed;
    private float yRange = -3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(gameObject.transform.position.y < yRange)
        {
            Destroy(gameObject);
        }
    }

    public string getSide(Vector3 normal)
    {
        if(normal == gameObject.transform.up)
        {
            return "top";
        }
        else if (normal == -gameObject.transform.up)
        {
            return "bottom";
        }
        else
        {
            return "";
        }
    }
}

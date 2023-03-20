using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float horizontalInput;
    public float speed=15.0f;
    public float xRange=15.0f;
    public GameObject food;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput=Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right*horizontalInput*speed*Time.deltaTime);
        if(transform.position.x<-xRange)
        {
            transform.position = new Vector3(-xRange,transform.position.y,transform.position.z);
        }else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(food, transform.position, transform.rotation);
        }
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControler : MonoBehaviour
{
    private float horizontalInput;
    public float speed=15.0f;
    public float xRange=15.0f;
    public GameObject food;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Player Controller (collision)   "+collision.gameObject.tag);
        //Debug.Log("Player Controller   "+gameObject.tag);
        HealthDown();
        Destroy(collision.gameObject);
    }
    public void HealthDown()
    {
        HealthManager.instance.DecreaseHealth();
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
            Instantiate(food, new Vector3(transform.position.x,0.5f,transform.position.z+1.5f), transform.rotation);
        }
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class flyout : MonoBehaviour
{
    public float speed = 15.0f;
    public float zRange = 20.0f;
    public int respawn=0;
    public float respawnPostionZAxis=17.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
        if(respawn!=1)
        {
            if(transform.position.z>zRange && zRange>=0)
            {
                Destroy(this.gameObject);
            }else if (transform.position.z < zRange && zRange < 0)
            {
                Destroy(this.gameObject);
            }
        }else if(respawn==1)
        {
            
            if (transform.position.z > zRange && zRange >= 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, respawnPostionZAxis);
            }
            else if (transform.position.z < zRange && zRange < 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, respawnPostionZAxis);
            }
        }
        
    }
}

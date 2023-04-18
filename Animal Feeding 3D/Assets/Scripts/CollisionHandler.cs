using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision Handler (collision)"+collision.gameObject.tag);
        //Debug.Log("Collision Handler (gameObj)"+gameObject.tag);
        ScoreManager.instance.IncreaseScore();
        Destroy(gameObject);
        Destroy(collision.gameObject);
    }
}

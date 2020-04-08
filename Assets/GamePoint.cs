using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with: " + collision.name);
        if(collision.gameObject.tag == "Player")
        {
            GameController.instance.ScorePoint();
            Destroy(gameObject);
        }
    }
}

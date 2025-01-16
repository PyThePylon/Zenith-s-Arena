using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private GameObject playerObject;
    private Transform playerTransform;
    public bool MoveTowardsPlayer = false;
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerTransform = playerObject.transform; 
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveTowardsPlayer)
        {
            MoveToPlayer();
        } else
        {
            EnemyBehavior();
        }
    }

    void EnemyBehavior()
    {

    }

    void MoveToPlayer()
    {
        //Enemy rotation
        Vector3 direction = playerTransform.position - transform.position;
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;


        Vector3 follow = playerTransform.position;
            //setting always the same Y position
            follow.y = this.transform.position.y;
            // remenber to use the new 'follow' position, not the Player.transform.position or else it'll move directly to the player
            this.transform.position = Vector3.MoveTowards(this.transform.position, follow, speed * Time.deltaTime);
        
    }
    void OnCollisionEnter(Collision collision) {
        Debug.Log("Collision Occurred");
        if(collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<Player>().DecrementLife();
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}

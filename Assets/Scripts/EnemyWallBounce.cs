using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWallBounce : MonoBehaviour
{
    bool move = true;

    public float moveSpeed = 5f;
    int randNum = -1;

    public Transform[] walls;
    Transform grabWall;

    Vector3 newDirect;

    void Update()
    {
        if (randNum == -1)
        {
            randNum = Random.Range(0, walls.Length);
            grabWall = walls[randNum].transform;
        }


        if (grabWall != null && move)
        {
            Vector3 direction = grabWall.position - transform.position;
            direction.Normalize();

            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            move = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            StartCoroutine(waitToTurn());

        }
    }

    IEnumerator waitToTurn()
    {

        yield return new WaitForSeconds(.1f);


        int holdRandNum = randNum;
        while (randNum == holdRandNum)
        {
            randNum = Random.Range(0, walls.Length);
            grabWall = walls[randNum].transform;
            Debug.Log(randNum);
        }

        grabWall = walls[randNum].transform;

        yield return new WaitForSeconds(.1f);

        move = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Player : MonoBehaviour
{
    public float speed = 10f;
    private int lives;
    public Rigidbody rb;
    public bool cubeOnGround = true;
    public TextMeshProUGUI livesText;
    public GameObject gameOverText;
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lives = 3;
        SetLivesText();
        gameOverText.SetActive(false);
    }

    void Update()
    {
        Move();
    }

    public void IncrementLife() {
        lives++;
        SetLivesText();
    }

    public void DecrementLife() {
        lives--;
       SetLivesText();
    }

    public int GetLives() {
        return lives;
    }

    void Move() { //Player Movement
        float horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(horizontalInput, 0, verticalInput);

        if(Input.GetButtonDown("Jump") && cubeOnGround)
        {
            rb.AddForce(new Vector3(0, 9, 0), ForceMode.Impulse);
            cubeOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision) //Jumping
    {
        if(collision.gameObject.tag == "Ground")
        {
            cubeOnGround = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HealthPot"))
        {
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("InvinciblePot"))
        {
            other.gameObject.SetActive(false);
        }
    }

    void SetLivesText() //Lives Counter
    {
        livesText.text = "Lives : " + lives.ToString();

        if (lives == 0)
        {
            gameOverText.SetActive(true);
        }
    }

    void GameOver()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    public float Speed;
    public Rigidbody rb;
    public float timeValue = 0f;
    public GameManager gamemanager;
    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7.2f, 7.2f), Mathf.Clamp(transform.position.y, -8f, 3.5f));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * Speed;
            thisAnimation.Play();
        }
            
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene("GameLose");

        }
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            SceneManager.LoadScene("GameLose");

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Points"))
        {
            gamemanager.Score++;
        }
    }
    
}

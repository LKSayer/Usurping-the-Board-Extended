using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    /*
    // Variables
    Rigidbody rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // Variables for Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Movement Script
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, 5f, rb.velocity.z);
        }
        if (Input.GetKey("up"))
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 5f);
        }
        if (Input.GetKey("right"))
        {
            rb.velocity = new Vector3(5f, rb.velocity.y, 0);
        }
        if (Input.GetKey("down"))
        {
            rb.velocity = new Vector3(0, rb.velocity.y, -5f);
        }
        if (Input.GetKey("left"))
        {
            rb.velocity = new Vector3(-5f, rb.velocity.y, 0);
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
    */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy "))
        {
          GetComponent<MeshRenderer>().enabled = false;
          GetComponent<Rigidbody>().isKinematic = true;
          GetComponent<CapsuleCollider>().enabled = false;
          Invoke(nameof(ReloadLevel), 1.3f);
        }

        if (collision.gameObject.CompareTag("King"))
        {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);      
        }
    }

    

    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    [SerializeField] AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpSound.Play();
    }

    void ReloadLevel()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }

    
}

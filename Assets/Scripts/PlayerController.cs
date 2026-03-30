using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 8f;
    private Rigidbody2D rb;
    private Animator anim; // Reference to the Animator component

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); // Initialize the Animator
    }

    void Update()
    {
        // Jump when the Space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // --- Animation handling section ---

        if (rb.velocity.y > 0.1f)
        {
            // If moving upwards, trigger Jump animation
            anim.SetBool("isJumping", true);
            anim.SetBool("isFalling", false);
        }
        else if (rb.velocity.y < -0.1f)
        {
            // If moving downwards, trigger Fall animation
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }
        else
        {
            // If on the ground, trigger Run animation
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }
    }
}
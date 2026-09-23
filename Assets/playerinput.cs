using UnityEngine;

public class playerinput : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float jump = 500.0f;
    public bool isgroun = false;
    private int jumpcount = 0;
    Rigidbody2D rb;
    Vector2 pb;
    private Animator animator;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && jumpcount < 2)
        {

            jumpcount++;
            rb.linearVelocity = Vector3.zero;
            rb.AddForce(new Vector2(0, jump));

        }
        else if(Input.GetMouseButtonUp(0) && rb.linearVelocity.y > 0)
        {

            rb.linearVelocity = rb.linearVelocity * 0.5f;
        }

        //animator.SetBool("isgroun", isgroun);

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isgroun = true;
            jumpcount = 0;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isgroun = false;
    }

}

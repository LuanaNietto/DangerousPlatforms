using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed;
    public float JumpForce;
    public bool isJumping;
    public bool isDupleJumping;

    [SerializeField]
    private Rigidbody2D rigi;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnAnimatorMove();
        Jump();
    }

    void OnAnimatorMove()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        if (Input.GetAxis("Horizontal") > 0f)
        {
            animator.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (Input.GetAxis("Horizontal") < 0f)
        {
            animator.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (Input.GetAxis("Horizontal") == 0f)
        {
            animator.SetBool("walk", false);
        }

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
           {
                rigi.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                isDupleJumping = true;
                animator.SetBool("jump", true);
            } else
            {
                if (isDupleJumping)
                {
                    rigi.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    isDupleJumping = false;
                }
            }            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isJumping = false;
            animator.SetBool("jump", false);
        }

        if (collision.gameObject.layer == 7)
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Saw")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isJumping = true;
        }
    }

   /* private void LateUpdate()
    {
        mainCamera.transform.position =
            new Vector3(transform.position.x,
                        transform.position.y,
                        mainCamera.transform.position.z);
    } */
}

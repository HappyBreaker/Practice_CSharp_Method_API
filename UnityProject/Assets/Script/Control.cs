using UnityEngine;

public class Control : MonoBehaviour
{
    [Header("移動速度")]
    [Range(1,100)]
    public float MoveSpeed = 1;
    [Header("跳躍高度")]
    [Range(1, 100)]
    public float jumphight = 1;

    private float x;


    private Rigidbody2D Rog;
    private Animator Ani;


    void Start()
    {
        Rog = GetComponent<Rigidbody2D>();
        Ani = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        move();
        jump();
    }

    private void move()
    {
        x = Input.GetAxis("Horizontal");

        Rog.velocity = new Vector2(x * MoveSpeed, Rog.velocity.y);

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
            transform.localEulerAngles = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }

        //Ani.SetBool("run", x != 0);
    }

    private void jump()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Rog.AddForce(new Vector2(0, jumphight));
        }

    }
}
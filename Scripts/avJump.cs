using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class avJump : MonoBehaviour
{
    public bool Ready;
    public float JumpHeight;
    public float JumpCount = 2;
    bool DirectionSwitchOnNextJump;
    int Direction;
    Rigidbody2D rigid;
    //Animator anim;
    public Text Debug;
    public Text Debug2;

    // Use this for initialization
    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        Direction = GameObject.Find("Player").GetComponent<avRun>().RunDirection;

    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetFloat("yVelocity", Mathf.Abs(rigid.velocity.y));
        if (Ready)
        {
            Touch t = new Touch();
            t.phase = TouchPhase.Canceled;
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    t = touch;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) || t.phase == TouchPhase.Began)
            {
                //if (rigid.velocity.y < 0.0000001)

                if (JumpCount > 0)
                {
                    if (DirectionSwitchOnNextJump)
                    {
                        //Direction = GameObject.Find("Player").GetComponent<avRun>().RunDirection;
                        //Direction -= 2 * Direction;
                        //GameObject.Find("Player").GetComponent<avRun>().RunDirection = Direction;
                        GameObject.Find("Player").GetComponent<avRun>().changeDirection();
                        DirectionSwitchOnNextJump = false;
                        Direction = GameObject.Find("Player").GetComponent<avRun>().RunDirection;
                    }
                    else
                    {
                        DirectionSwitchOnNextJump = true;
                    }
                    //Debug.Log("JUMP");
                    //this.GetComponent<AudioSource>().PlayOneShot(this.GetComponent<AudioSource>().clip);

                    rigid.AddForce(new Vector2(Direction, JumpHeight), ForceMode2D.Impulse);
                    JumpCount--;
                }
            }
        }
        Debug.text = "J:" + JumpCount.ToString() + ", D:" + Direction.ToString() + ", O:" + transform.rotation.y + ", O2:" + GameObject.Find("LeftArm").GetComponent<Transform>().position.z;
        Debug2.text = "V1:" + rigid.velocity.ToString() + ", V2:" + rigid.angularVelocity + ", I:" + rigid.inertia.ToString();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            JumpCount = 2;
            DirectionSwitchOnNextJump = false;
        }
        if (col.gameObject.tag == "Wall")
        {
            //rigid.AddForce(new Vector2(0, 0), ForceMode2D.Impulse);
            JumpCount += 1;
            DirectionSwitchOnNextJump = true;
        }
    }
}

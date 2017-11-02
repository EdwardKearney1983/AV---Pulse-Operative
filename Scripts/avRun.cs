using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avRun : MonoBehaviour {

    public float RunSpeed;
    public int RunDirection = -1; //-1 = move to the right, 1 = move to the left
    public bool Ready;
    Rigidbody2D rigid;

    // Use this for initialization
    void Start () {
        //transform.rotation = Quaternion.Euler(0, 360, 0);
        transform.rotation = Quaternion.Euler(0, ((RunDirection + 1) / 2) * 180, 0);
        RunSpeed = GameObject.Find("MainCamera").GetComponent<Tempo>().BPM /60f * 0.05f;
        //Debug.Log(GameObject.Find("MainCamera").GetComponent<Tempo>().BPM);
        rigid = this.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Ready)
        {
            this.transform.position -= new Vector3(RunSpeed * RunDirection, 0, 0);
            //rigid.AddForce(new Vector2(RunSpeed * RunDirection * 10, 0), ForceMode2D.Impulse);
        }
        
    }

    public void changeDirection()
    {
        RunDirection -= 2*RunDirection;
        //this.transform.rotation.y
        transform.rotation = Quaternion.Euler(0, ((RunDirection +1)/2) * 180, 0);
        GameObject.Find("LeftArm").GetComponent<Transform>().position = new Vector3(GameObject.Find("LeftArm").GetComponent<Transform>().position.x, GameObject.Find("LeftArm").GetComponent<Transform>().position.y, 0.01f + ((RunDirection + 1) / 2) * 0.49f);
    }
}

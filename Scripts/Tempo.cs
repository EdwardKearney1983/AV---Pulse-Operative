using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tempo : MonoBehaviour {

    public int BPM = 60;
    public float NotesPerBeat = 4;
    float AnimationSpeed;
    AudioSource music;
    Animator anim;
    Animator BGanim;
    Animator PlatformAnim;
    Animator Enemy1Anim;

    // Use this for initialization
    void Start () {
        AnimationSpeed = BPM / 60 / 2;
        //load objects (unanimated)
        anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
        anim.SetFloat("AnimationSpeed", AnimationSpeed);
        BGanim = GameObject.FindWithTag("Background").GetComponent<Animator>();
        BGanim.SetFloat("AnimationSpeed", AnimationSpeed);
        PlatformAnim = GameObject.FindWithTag("Platform").GetComponent<Animator>();
        PlatformAnim.SetFloat("AnimationSpeed", AnimationSpeed);
        Enemy1Anim = GameObject.FindWithTag("Enemy1").GetComponent<Animator>();
        Enemy1Anim.SetFloat("AnimationSpeed", AnimationSpeed);
        //play intro
        //start audio (start animation)
        music = GetComponent<AudioSource>();
        StartCoroutine(PlayMusic(1));
        //start movement (on right frame)
        //give player control
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator PlayMusic(float delay)
    {
        yield return new WaitForSeconds(delay);
        music.Play();
        anim.SetBool("Ready", true); //needs to loop through all animators
        GameObject.FindWithTag("Player").GetComponent<avRun>().Ready = true;
        GameObject.FindWithTag("Player").GetComponent<avJump>().Ready = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class IntroController : MonoBehaviour
{
    private Rigidbody2D myRB;
    private Animator myAnim;
    private bool flag, audioFlag, stand;
    private float timer;
    private float second;

    public AudioSource audioSource;
    public AudioClip clip_fall;
    public AudioClip clip_hit;
    public AudioClip clip_walk;
        

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        myRB = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip_fall;

        flag = false;
        audioFlag = false;
        timer = 2.2f;
        second = 1f;
        stand = false;

    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject.tag == "StartWalkController")
        {
            if (!stand)
            {
                audioSource.Stop();
                audioSource.clip = clip_hit;
                audioSource.Play();
                stand = !stand;
            }
            myAnim.SetBool("Floor", true);
            flag = true;
            
            justASecond();

        }

        if (other.gameObject.tag == "Next")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void Update()
    {
        if (!flag)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(clip_fall, 1);
            }
            
        }
        if (flag)
        {


            Wait();

            if (audioFlag)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = clip_walk;
                    audioSource.Play();
                }
            }
            
        }

        
            
             
    }
       
        

    private void Wait()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {

            audioFlag = true;
            transform.position = transform.position + new Vector3(.9f, 0f, 0f);
        }
            
            
    }

    

    private void justASecond()
    {
        second -= Time.deltaTime;

        if (second <= 0)
        {
            audioSource.Stop();
        }
    }
            

}

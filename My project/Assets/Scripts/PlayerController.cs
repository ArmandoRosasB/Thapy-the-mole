using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;
    private Animator myAnim;
    public AudioSource audiosource;
    public AudioClip clip;

    private bool flag;


    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = clip;
        flag = false;

    }

    // Update is called once per frame
    void Update()
    {
        myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        myRB.velocity *= speed;

        


        if (myRB.velocity.x != 0 ||  myRB.velocity.y != 0 )
        {

            if (!flag)
            {
                Debug.Log("Que suene ramonaaaaa");
                audiosource.Play();
                flag = true;
            
            }

        }
        
        else
        {
            flag = false;
            audiosource.Stop();

        }
        
        myAnim.SetFloat("MoveX", myRB.velocity.x);
        myAnim.SetFloat("MoveY", myRB.velocity.y);
        
        


        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnim.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));

        }



    }
}

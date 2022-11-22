using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    public float  speed;
    public float Maxspeed;
    private Vector3 direction;
    private int lane = 1;
    public float laneDistance = 2.5f;
    public float jumpForce;
    public float gravity = -20;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.IsGameStarted)
            return;
        
        animator.SetBool("IsGameStarted",true);

        if (speed < Maxspeed)
        {
            speed += 0.1f * Time.deltaTime;

        } 
        
        
         if (controller.isGrounded) {


            animator.SetBool("IsGrounded",controller.isGrounded);
            
             if (SwipeManager.swipeUp)
             {
                 jump();
             }
             

         }
        else
        {
            direction.y += gravity * Time.deltaTime;
        }

        direction.z = speed;

        if(SwipeManager.swipeDown)
        {
            StartCoroutine(Slide());
        }

        if (SwipeManager.swipeRight)
        {
            lane++;

            if (lane == 3)
            {
                lane = 2;
            }
                
        }

        if (SwipeManager.swipeLeft)
        {
            lane--;
            if (lane == -1)
                lane = 0;
        }
        Vector3 targetposition;
        targetposition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (lane == 0)
        {
            targetposition += Vector3.left * laneDistance;
        }
        else if (lane == 2)
        {
            targetposition += Vector3.right * laneDistance;
        }
       if(transform.position != targetposition)
        {
            Vector3 diff = targetposition - transform.position;
            Vector3 MovingDirection = diff.normalized * 25 * Time.deltaTime;
            if (MovingDirection.sqrMagnitude < diff.sqrMagnitude)
            {
                controller.Move(MovingDirection);
            }
            else
            {
                controller.Move(diff);

            }

        }
       
        
        controller.Move(direction * Time.deltaTime);
    }
   
    private void jump()
    {
        direction.y = jumpForce;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
       if(hit.transform.tag=="Obstacle")
        {
            PlayerManager.gameover = true;
            FindObjectOfType<AudioManager>().PlaySound("blast");
        }
    }
    private IEnumerator Slide()
    {
        animator.SetBool("IsSliding",true);
        controller.center = new Vector3(0,-0.5f,0);
        controller.height = 1;
       
        yield return new WaitForSeconds(1f);

        controller.center = new Vector3(0, 0, 0);
        controller.height = 2;
        animator.SetBool("IsSliding",false);

    }
}

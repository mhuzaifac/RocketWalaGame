using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{

    [SerializeField] private Transform cam;
    [SerializeField] private float forceMagnitude = 10f;
    [SerializeField] private float frictionMagnitude = 1.0f;
    [SerializeField] private float frictionCutoffVelocity = .1f;
    [SerializeField] private Transform startingPos;
    [SerializeField] private float fallingValue = -5f;
 

    private Rigidbody rb;




    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        InitilizeBall();
    }

    private void FixedUpdate()
    {
        if (transform.position.y < fallingValue)
        {
            FallState();
        }

        Movement();
        ApplyFriction();
    }
   

    private void ApplyFriction()
    {
        if (Mathf.Abs(rb.linearVelocity.magnitude) >= frictionCutoffVelocity)
        {
            Vector3 frictionDir = rb.linearVelocity;
            frictionDir.Normalize();
            rb.linearVelocity -= frictionDir * frictionMagnitude * Time.deltaTime;
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }
    }

    private void Movement()
    {

        if (Keyboard.current.aKey.isPressed)
        {
            //move ball in right dirnc of camera 
            ApplyForce(-cam.right);

        }
        else if (Keyboard.current.dKey.isPressed)
        {
            // move ball in left dirxn of camera
            ApplyForce(cam.right);


        }



        Vector3 dir = cam.forward;
        dir.y = 0;
        dir.Normalize();

        if (Keyboard.current.wKey.isPressed)
        {
            // move the ball in the dirxn of camera seeing
            ApplyForce(dir);
            

        }
        else if (Keyboard.current.sKey.isPressed)
        {
            //change camera position so it view the ball from behind 
            ApplyForce(-dir);
            


        }


    }

    private void ApplyForce(Vector3 forceDirxn)
    {
        Vector3 force = forceDirxn * forceMagnitude;
        rb.AddForce(force);
    }

    private void InitilizeBall()
    {
        rb.linearVelocity = Vector3.zero;
        transform.position = startingPos.position;
        transform.rotation = Quaternion.identity;

    }

    private void FallState()
    {
        rb.linearVelocity = Vector3.zero;
        GameManager.Instance.LoadCurrentLevel();
        
    }

    



}

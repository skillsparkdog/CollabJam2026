using UnityEngine;

public class walk : MonoBehaviour
{   public float speed;
    [Range(0f, 1f)]
public float groundDecay;
public Rigidbody2D body;
 public BoxCollider2D groundCheck;
 public LayerMask groundMask;
public bool grounded;

float xInput;
float yInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
    {
        
    }

    // Update is called once per frame
void Update()
    {
    GetInput();
    MoveWithInput();
    }

void FixedUpdate(){
    CheckGround();
    ApplyFriction();
}

void GetInput(){
    xInput = Input.GetAxisRaw("Horizontal");
    yInput = Input.GetAxisRaw("Vertical");
}
    
void MoveWithInput(){
    
if (Mathf.Abs(xInput) > 0) {
        
        body.linearVelocity = new UnityEngine.Vector2(xInput * speed, body.linearVelocityY);   
        }


if (Mathf.Abs(yInput) > 0 && grounded) {
        
       body.linearVelocity = new UnityEngine.Vector2(body.linearVelocityX, yInput * speed);     
        }
}
    

void CheckGround(){
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
}

void ApplyFriction(){
    
        if(grounded && xInput == 0 && yInput == 0) {
      body.linearVelocity *= groundDecay;
    }
}

}

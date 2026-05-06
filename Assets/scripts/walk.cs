using JetBrains.Annotations;
using UnityEngine;
public class walk : MonoBehaviour
{   public float groundSpeed;
    public float jumpSpeed;
    public float acceleration;
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
    HandleJump();
    }
void FixedUpdate(){
    CheckGround();
    ApplyFriction();
    MoveWithInput();
}
void GetInput(){
    xInput = Input.GetAxisRaw("Horizontal");
    yInput = Input.GetAxisRaw("Vertical");
}
    
void MoveWithInput(){
    
if (Mathf.Abs(xInput) > 0) {
        
     float increment = xInput * acceleration;
     float newSpeed = Mathf.Clamp(body.linearVelocityX * increment, -groundSpeed, +groundSpeed);
     body.linearVelocity = new UnityEngine.Vector2(xInput * groundSpeed, body.linearVelocityY);

        body.linearVelocity = new UnityEngine.Vector2(xInput * groundSpeed, body.linearVelocityY);   
        float direction = Mathf.Sign(xInput);
        transform.localScale = new UnityEngine.Vector3(direction, 1, 1);
        }

}
    
    void HandleJump() {
        if (Mathf.Abs(yInput) > 0 && grounded) {
        
       body.linearVelocity = new UnityEngine.Vector2(body.linearVelocityX, yInput * jumpSpeed);     
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

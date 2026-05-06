using UnityEngine;

public class tumble : MonoBehaviour
{
    public bool isTumbling;
    public BoxCollider2D groundCheck;
    public bool grounded;
    public LayerMask groundMask;
    float xInput;
    float yInput;
    public Rigidbody2D body;
    [Range(0, 10f)]
    float tumbleThreshold;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      GetTumbling();
      CheckGround();
   if (isTumbling && yInput > 0)      
{
    body.angularVelocity = 0f;
    // trigger getup animation

    }
 }
void CheckGround(){
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
}
void GetInput(){
    xInput = Input.GetAxisRaw("Horizontal");
    yInput = Input.GetAxisRaw("Vertical");
}

void GetSideways()
    {
    float angle = Mathf.Abs(body.rotation % 360);
    bool isSideways = angle > 45f && angle < 315f;

    if (isSideways || Mathf.Abs(body.angularVelocity) > tumbleThreshold)
    isTumbling = true;

}

void GetTumbling()
    {
        float angle = body.rotation % 360;
    if (angle < 0) angle += 360; // normalize negative angles

    bool isUpright = angle < 30f || angle > 330f;

    if (!isUpright)
    isTumbling = true;
}
}

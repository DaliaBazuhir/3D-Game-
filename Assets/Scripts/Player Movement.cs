/*using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] float speed = 3f;
   [SerializeField] float jump = 3f;
    private Rigidbody rigidBody;
    [Range(0,1)] float lerpConstant;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
   
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput * speed,rigidBody.linearVelocity.y);
        rigidBody.linearVelocity =  Vector2.Lerp(rigidBody.linearVelocity,movement,lerpConstant);
        if(Input.GetKeyDown(KeyCode.Space)){
            Jump();
        }
    }
    void Jump(){
        rigidBody.AddForce(new Vector2(0,jump));
    }
}
*/
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float jump = 3f;
    public Text coinText;
    public int coinsCount = 0;
    private Rigidbody rigidBody;
    [Range(0, 1)] float lerpConstant = 0.1f; // Set a default value

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
       // coinsCount = 0;
        ShowCountText();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        // Move in the X direction while keeping the Y velocity unchanged
        Vector3 movement = new Vector3(horizontalInput * speed, rigidBody.linearVelocity.y, 0);
        rigidBody.linearVelocity = Vector3.Lerp(rigidBody.linearVelocity, movement, lerpConstant);

        // Jumping logic
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rigidBody.linearVelocity.y) < 0.01f)
        {
            Jump();
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Coin"){
           Destroy(other.gameObject) ;
           coinsCount +=1;
           ShowCountText();
        }
    }

    void Jump()
    {
        rigidBody.AddForce(Vector3.up * jump, ForceMode.Impulse);
    }

    void ShowCountText(){
        coinText.text = "Coins : "+coinsCount.ToString();
    }

}

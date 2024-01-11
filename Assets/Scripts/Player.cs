using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    // Reference to attached Rigidbody2D
    Rigidbody2D rigidbody2D;
    // How much force to add when jumping
    public float jumpForce = 10.0f;
    // Boolean flag tracking whether GameObject is falling
    public bool isFalling = true;

    public static UnityEvent<Player> playerJumpEvent = new UnityEvent<Player>();

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.gravityScale = rigidbody2D.velocity.y > 0 ? 1 : 2f;

        if (!isFalling)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerJumpEvent.Invoke(this);
                rigidbody2D.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            }

            
        }

        if (!Input.GetKey(KeyCode.Space))
        {
            if (rigidbody2D.velocity.y > 0f){
                float y = rigidbody2D.velocity.y * 0.75f;
                rigidbody2D.velocity = Vector2.up * y;
            }
            
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isFalling = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isFalling = true;
        }
    }
}

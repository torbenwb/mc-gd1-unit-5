using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // control how fast the obstacle moves across the screen
    public Parallax.Layer layer;
    // 
    public float speedMod = 1.0f;
    public int damage = 1;

    // control how far the object should go before being destroyed offscreen.
    public float endRange = -12f;

    public bool hideOnCollect = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += Vector3.left * Parallax.GetSpeed(layer) * speedMod * Time.deltaTime;

        if (transform.position.x <= endRange){
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Health.TryDamageTarget(other.gameObject, damage)){
            if (hideOnCollect) gameObject.SetActive(false);
        }
    }
}

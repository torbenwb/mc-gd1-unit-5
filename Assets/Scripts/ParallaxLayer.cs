using UnityEngine;

public class Parallax
{
    public enum Layer
    {
        Foreground, Midground, Background
    }
    public static float speed = 2f;

    public static float GetSpeed(Layer layer)
    {
        switch (layer)
        {
            case Layer.Foreground:
            return speed * 2;
            case Layer.Midground:
            return speed * 0.5f;
            case Layer.Background:
            return speed * 0.1f;
            default:
            return speed * 1;
        }
    }
    
}

public class ParallaxLayer : MonoBehaviour
{
    public Transform[] tiles;

    public float left = -19f;
    public Vector3 right = new Vector3(19f, 0f, 0f);

    public Parallax.Layer layer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i].position += Vector3.left * Time.deltaTime * Parallax.GetSpeed(layer);

            if (tiles[i].position.x <= left)
            {
                tiles[i].position = right;
            }
        }
    }
}

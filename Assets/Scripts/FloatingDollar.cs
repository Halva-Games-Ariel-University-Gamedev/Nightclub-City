using UnityEngine;

public class FloatingDollar : MonoBehaviour
{
    public float floatSpeed = 2f;   
    public float lifetime = 0.1f;     
    public Vector3 offset = new Vector3(0, 1f, 0); 

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr == null)
        {
            Debug.LogWarning("FloatingDollar: No SpriteRenderer found!");
        }

        // Destroy the dollar after lifetime seconds
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Move the dollar upward
        transform.position += offset * floatSpeed * Time.deltaTime;

        // Fade out gradually
        if (sr != null)
        {
            Color c = sr.color;
            c.a -= Time.deltaTime / lifetime;
            sr.color = c;
        }
    }
}

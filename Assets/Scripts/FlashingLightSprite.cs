using UnityEngine;

public class FlashingLightSprite : MonoBehaviour
{
    public SpriteRenderer sr;
    public float flashSpeed = 5f;

    void Start()
    {
        if (sr == null)
            sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float alpha = (Mathf.Sin(Time.time * flashSpeed) + 1f) / 2f; // 0 → 1
        Color c = sr.color;
        c.a = alpha;
        sr.color = c;
    }
}

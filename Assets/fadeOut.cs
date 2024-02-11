using UnityEngine;

public class fadeOut : MonoBehaviour
{
    public float fadeDuration = 2.0f; // Duration of the fade in seconds

    private float alpha = 1.0f; // Current alpha value
    private Renderer rend; // Reference to the object's renderer

    void Start()
    {
        // Get the renderer component of the object
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        // Reduce the alpha value over time
        alpha -= Time.deltaTime / fadeDuration;

        // Clamp the alpha value to be between 0 and 1
        alpha = Mathf.Clamp01(alpha);

        // Set the alpha value in the object's material
        Color color = rend.material.color;
        color.a = alpha;
        rend.material.color = color;

        // Disable the object when the alpha value reaches 0
        if (alpha <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class LegacyTextGradientMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public Color color1 = Color.red;
    public Color color2 = Color.blue;

    private Text legacyText;
    private MeshFilter meshFilter;

    private void Start()
    {
        legacyText = GetComponent<Text>();
        meshFilter = GetComponent<MeshFilter>();
        
        if (meshFilter == null)
        {
            // If there is no MeshFilter, add one
            meshFilter = gameObject.AddComponent<MeshFilter>();
        }
    }

    private void Update()
    {
        // Move the text horizontally over time
        float offset = Mathf.Sin(Time.time * speed);
        transform.Translate(Vector3.right * offset * Time.deltaTime);

        // Update the color of each letter based on a gradient
        UpdateLetterColors(offset);
    }

    private void UpdateLetterColors(float offset)
    {
        Mesh textMesh = meshFilter.mesh;

        if (textMesh == null)
        {
            // Ensure that the Mesh component is initialized
            meshFilter.mesh = new Mesh();
            textMesh = meshFilter.mesh;
        }

        Color[] colors = textMesh.colors;

        for (int i = 0; i < colors.Length; i++)
        {
            // Calculate color interpolation based on the position of the letter
            float t = Mathf.InverseLerp(0, colors.Length, i);
            Color letterColor = Color.Lerp(color1, color2, t);

            // Update the color of the letter
            colors[i] = letterColor;
        }

        // Apply the modified colors to the text mesh
        textMesh.colors = colors;
    }
}
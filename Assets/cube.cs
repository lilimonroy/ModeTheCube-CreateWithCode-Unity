using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    public MeshRenderer Renderer;


    [Range(0, 1)] public float leapTime;

    public Color[] color;

    int colorIndex = 0;

    float time;

    void Start()
    {
        //color
        Renderer = GetComponent<MeshRenderer>();

        // transform.position = new Vector3(3, 4, 1);
        // transform.localScale = Vector3.one * 1.3f;

        // Material material = Renderer.material;

        //material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }

    void Update()
    {
        //  transform.Rotate(10.0f * Time.deltaTime, 0.0f, 0.0f);

        Renderer.material.color = Color.Lerp(Renderer.material.color, color[colorIndex], leapTime * Time.deltaTime);

        time = Mathf.Lerp(time, 1f, leapTime * Time.deltaTime);
        if (time > 0.9f)
        {
            time = 0;
            colorIndex++;
            colorIndex = (colorIndex >= color.Length) ? 0 : colorIndex;
        }
    }
}

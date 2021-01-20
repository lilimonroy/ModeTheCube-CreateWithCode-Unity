using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
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

        transform.position = new Vector3(-5, -2, 0);
        transform.localScale = Vector3.one * 1.5f;
        
       // Material material = Renderer.material;
        
        //material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }
    
    void Update()
    {
        transform.Rotate(-20.0f * Time.deltaTime * Random.Range(1, 3), 40.0f * Time.deltaTime, -20.0f * Time.deltaTime * Random.Range(1, 3));

        Renderer.material.color = Color.Lerp(Renderer.material.color, color[colorIndex], leapTime * Time.deltaTime);

        time = Mathf.Lerp(time, 1f, leapTime * Time.deltaTime);
        if(time > 0.5f)
        {
            time = 0;
            colorIndex++;
            colorIndex = (colorIndex >= color.Length) ? 0 : colorIndex;
        }    
    }
}

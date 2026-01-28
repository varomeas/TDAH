using UnityEditor.ShaderGraph;
using UnityEngine;

public class OutlineLightning : MonoBehaviour
{

    public Outline outline;
    public float speed = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float value = (Mathf.Sin(Time.time * speed) + 1.0f) / 2.0f;
        outline.OutlineWidth = value*10;

    }

    

    
}

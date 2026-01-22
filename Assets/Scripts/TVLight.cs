using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class TVLight : MonoBehaviour
{
    public RenderTexture tvTexture;
    public Light tvLight;
    [Range(0.1f, 2f)] public float intensity = 1f;
    [Range(1, 10)] public int updateFrequency = 5;

    private Texture2D tempTex;
    private Rect rect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tempTex = new Texture2D(1,1, TextureFormat.RGB24, false);
        rect = new Rect(0,0,1,1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.frameCount % updateFrequency ==  0 && tvTexture != null)
        {
            UpdateLightColor();
        }
    }

    void UpdateLightColor()
    {
        RenderTexture currentRT = RenderTexture.active;
        RenderTexture.active = tvTexture;

        tempTex.ReadPixels(new Rect(tvTexture.width / 2, tvTexture.height / 2, 1, 1), 0, 0);
        tempTex.Apply();

        RenderTexture.active = currentRT;

        Color pixelColor = tempTex.GetPixel(0,0);
        tvLight.color = pixelColor;
        tvLight.intensity = pixelColor.grayscale * intensity * 5f;
    }
}

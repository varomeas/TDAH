using System.Collections;
using UnityEngine;

public class Lumiere : MonoBehaviour
{
    public Light lumiereCuisine;
    private float intensiteInitiale;
    private bool isFlashing = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        intensiteInitiale = lumiereCuisine.intensity;
    }

    public void StartFlashing()
    {
        if (!isFlashing)
        {
            StartCoroutine(FlashRoutine());
        }
    }

    public void StopFlashing() { isFlashing = false; }

    IEnumerator FlashRoutine()
    {
        isFlashing = true;
        while (isFlashing)
        {
            lumiereCuisine.intensity = Random.Range(1f, 115f);
            yield return new WaitForSeconds(Random.Range(0.05f, 0.2f));
        }
        lumiereCuisine.intensity = intensiteInitiale;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

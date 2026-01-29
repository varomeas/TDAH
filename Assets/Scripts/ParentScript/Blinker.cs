using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Blinker : MonoBehaviour
{
    public float speed = 10f;
    public GameObject canvasesToShow;
    /*private Renderer targetRenderer;
    private Color originalColor;*/
    private Outline outline;
    
    private Coroutine blinkCoroutine;

    void Awake()
    {
        //targetRenderer = GetComponent<Renderer>();
        // On m�morise la couleur de base pour pouvoir y revenir
        /*if (targetRenderer != null)
            targetRenderer.material.EnableKeyword("_EMISSION");
            originalColor = targetRenderer.material.GetColor("_EmissionColor");*/

        outline = GetComponent<Outline>();
    }


    // C'est cette fonction que tu appelleras pour lancer le clignotement
    public void TriggerBlink()
    {
        if (blinkCoroutine == null) // évite de relancer si c'est déjà en cours
        {
            StartCoroutine(BlinkRoutine());
            canvasesToShow.SetActive(true);
        }
    }

    IEnumerator BlinkRoutine()
    {

        while (true)
        {
            // Ton oscillation pr�f�r�e entre 0 et 10
            float value = (Mathf.Sin(Time.time * speed) + 1f) / 2f;
            //targetRenderer.material.SetColor("_EmissionColor", Color.white * value);
            outline.OutlineWidth = value;
            yield return null;
        }

    }

    public void StopBlink()
    {
        StopCoroutine(BlinkRoutine());
        //if (targetRenderer != null)
        //    targetRenderer.material.SetColor("_EmissionColor", originalColor);
        outline.OutlineWidth = 0f;
        blinkCoroutine = null;
        canvasesToShow.SetActive(false);
        
    }
}

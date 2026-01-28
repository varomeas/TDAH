using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Blinker : MonoBehaviour
{
    public float speed = 10f;
    public float duration = 2f;
    /*private Renderer targetRenderer;
    private Color originalColor;*/
    private Outline outline;
    private bool isBlinking = true;

    void Awake()
    {
        /*targetRenderer = GetComponent<Renderer>();
        // On mémorise la couleur de base pour pouvoir y revenir
        if (targetRenderer != null)
            originalColor = targetRenderer.material.GetColor("_EmissionColor");*/
        outline = GetComponent<Outline>();
    }

    // C'est cette fonction que tu appelleras pour lancer le clignotement
    public void TriggerBlink()
    {
        if (!isBlinking) // Évite de relancer si c'est déjà en cours
        {
            StartCoroutine(BlinkRoutine());
        }
    }

    IEnumerator BlinkRoutine()
    {
        isBlinking = true;
        float timer = 0;

        while (timer < duration)
        {
            // Ton oscillation préférée entre 0 et 10
            float value = (Mathf.Sin(Time.time * speed) + 1f) / 2f * 10f;
            
            outline.OutlineWidth = value * 10;

            timer += Time.deltaTime;
            yield return null;
        }

        // Retour à l'état initial
        
        isBlinking = false;
    }
}

using UnityEngine;
using System.Collections;

public class AnimeBulle : MonoBehaviour
{
    public float duration = 0.2f;
    CanvasGroup cg;

    public void Awake()
    {
        cg = GetComponent<CanvasGroup>();
    }
    public void Show()
    {
        StartCoroutine(Animate());
    }
    IEnumerator Animate()
    {
        float t = 0;
        transform.localScale = Vector3.zero;
        cg.alpha = 0;

        while (t < duration)
        {
            t += Time.deltaTime;
            float p = t / duration;

            cg.alpha = p;
            transform.localScale = Vector3.one * Mathf.Lerp(0.8f, 1f, p);

            yield return null;

        }
        transform.localScale = Vector3.one;
        cg.alpha = 1;
    }
}

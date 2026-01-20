using System.Collections;
using UnityEngine;

public class Television : MonoBehaviour
{

    public AudioSource audiosource;
    public ForcedDrop forcedDropScript;

    public float volumeMax = 1.0f;
    public float dureeMonteeVolume = 2.0f;

    private float volumeInitial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (audiosource != null)
        {
            volumeInitial = audiosource.volume;
        }
    }

    public void StartAudioPic()
    {
        StartCoroutine(RoutineVolume());
    }

    IEnumerator RoutineVolume()
    {
        float temps = 0;

        while (temps < dureeMonteeVolume)
        {
            temps += Time.deltaTime;
            audiosource.volume = Mathf.Lerp(volumeInitial, volumeMax, temps / dureeMonteeVolume);
            yield return null;
        }

        if (forcedDropScript != null)
        {
            forcedDropScript.FaireTomber();
        }

        Debug.Log("Son trop fort, la fourchette tombe");

        yield return new WaitForSeconds(3f);
        audiosource.volume = volumeInitial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

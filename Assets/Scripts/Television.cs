using System.Collections;
using UnityEngine;

public class Television : MonoBehaviour
{

    public AudioSource audiosource;
    public ForcedDrop forcedDropScript;

    public float volumeMax = 100f;
    public float dureeMonteeVolume = 5.0f;

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
        Debug.Log("début montée du son, volume de départ : " +  volumeInitial);
        while (temps < dureeMonteeVolume)
        {
            temps += Time.deltaTime;
            audiosource.volume = Mathf.Lerp(volumeInitial, volumeMax, temps / dureeMonteeVolume);
            Debug.Log("Volume tv en cours : " + audiosource.volume);
            yield return null;
        }

        if (forcedDropScript != null)
        {
            forcedDropScript.FaireTomber();
        }

        Debug.Log("Son trop fort, la fourchette tombe");

        yield return new WaitForSeconds(3f);
        //audiosource.volume = volumeInitial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class MachineLaver : MonoBehaviour
{
    public Rigidbody assietteRB;
    public float tremblement = 2.5f;

    public AudioSource audio;
    public Animator machineAnimator;

    [Header("Paramètres audio")]
    public float volumeMax = 0.8f;
    public float dureeFadeIn = 5.0f;
    public float vibrationMax = 0.5f;

    public HapticImpulsePlayer leftController;
    public HapticImpulsePlayer rightController;

    private bool isRunning = false;

    public void ActiverPerturbation(bool state)
    {
        isRunning = state;
        Debug.Log("Machine activée");
        if (state)
        {
            machineAnimator.SetBool("Tourne", true);
            StartCoroutine(MonteePuissance());
        }
        else
        {
            machineAnimator.SetBool("Tourne", false);
            audio.Stop();
            StopAllCoroutines();
        }
    }

    IEnumerator MonteePuissance()
    {
        audio.volume = 0;
        audio.Play();

        float temps = 0;
        while (temps < dureeFadeIn)
        {
            temps += Time.deltaTime;

            float ratio = temps / dureeFadeIn;

            audio.volume = Mathf.Lerp(0, volumeMax, ratio);

            yield return null;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            Vector3 secousse = Random.insideUnitSphere * tremblement;
            assietteRB.AddForce(secousse, ForceMode.Acceleration);

            float intensiteActuelle = audio.volume/volumeMax;
            float vibrationForce = intensiteActuelle*vibrationMax;
            VibrerManette(leftController, vibrationForce);
            VibrerManette(rightController, vibrationForce);
        }
        
    }

    void VibrerManette(HapticImpulsePlayer controller, float amplitude)
    {
        if (controller != null && amplitude > 0.01f)
        {
            controller.SendHapticImpulse(amplitude, Time.deltaTime);
        }
    }

}

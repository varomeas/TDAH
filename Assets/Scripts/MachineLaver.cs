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

    [Header("Visuals des Mains")]
    public Transform mainDroite;
    public float tremblementMain = 0.05f;

    [Header("Paramètres audio")]
    public float volumeMax = 0.8f;
    public float dureeFadeIn = 5.0f;
    public float vibrationMax = 0.5f;

    public HapticImpulsePlayer leftController;
    public HapticImpulsePlayer rightController;

    private bool isRunning = false;
    private Vector3 posInitialeDroite;

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
        if (mainDroite) posInitialeDroite = mainDroite.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            Vector3 secousse = Random.insideUnitSphere * tremblement;
            assietteRB.AddForce(secousse, ForceMode.Acceleration);
            Debug.Log("Je runnn");
            float intensiteActuelle = audio.volume/volumeMax;
            float vibrationForce = intensiteActuelle*vibrationMax;
            VibrerManette(leftController, vibrationForce);
            VibrerManette(rightController, vibrationForce);

            TremblerMain(mainDroite, posInitialeDroite, intensiteActuelle);
            
        }
        
    }

    void TremblerMain(Transform mainTransform, Vector3 posInitiale, float ratio)
    {
        if (mainTransform != null)
        {
            Vector3 offset = Random.insideUnitSphere * (tremblementMain * ratio);
            mainTransform.localPosition = posInitiale + offset;
        }
    }

    void VibrerManette(HapticImpulsePlayer controller, float amplitude)
    {
        Debug.Log("je vibre");
        if (controller != null && amplitude > 0.01f)
        {
            controller.SendHapticImpulse(amplitude, Time.deltaTime);
        }
    }

}

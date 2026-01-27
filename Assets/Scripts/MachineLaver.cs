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
    public Transform mainGauche;
    public float tremblementMain = 0.05f;

    [Header("Paramètres audio et vibration")]
    public float volumeMax = 0.8f;
    public float dureeFadeIn = 5.0f;
    public float vibrationMax = 0.5f;

    public HapticImpulsePlayer leftController;
    public HapticImpulsePlayer rightController;

    private bool isRunning = false;
    private Vector3 posInitialeDroite;
    private Vector3 posInitialeGauche;

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
           FinirPerturbation();
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
        if(mainGauche) posInitialeGauche = mainGauche.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            Vector3 secousse = Random.insideUnitSphere * tremblement;
            assietteRB.AddForce(secousse, ForceMode.Acceleration);
            
            float intensiteActuelle = (volumeMax > 0) ? audio.volume / volumeMax : 0;
            float vibrationForce = intensiteActuelle*vibrationMax;
            VibrerManette(leftController, vibrationForce);
            VibrerManette(rightController, vibrationForce);

            TremblerMain(mainDroite, posInitialeDroite, intensiteActuelle);
            TremblerMain(mainGauche, posInitialeGauche, intensiteActuelle);
            
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
        
        if (controller != null && amplitude > 0.01f)
        {
            controller.SendHapticImpulse(amplitude, 0.1f);
        }
    }

    public void FinirPerturbation()
    {
        isRunning = false;
        machineAnimator.SetBool("Tourne", false);
        
        if (audio != null) audio.Stop();
        
        // IMPORTANT : On remet les mains à leur place exacte
        ResetMains();
        
        Debug.Log("Perturbation terminée et mains réinitialisées");
    }

    private void ResetMains()
    {
        if (mainDroite) mainDroite.localPosition = posInitialeDroite;
        if (mainGauche) mainGauche.localPosition = posInitialeGauche;
    }

}

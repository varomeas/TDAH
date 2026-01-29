using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Video;

public class ActionManager : MonoBehaviour
{

    [Header("Liste des objets dans l'ordre")]
    public List<Blinker> objectsToBlink;
    public Light lightToOff;
    public VideoPlayer videoController;
    public MachineLaver machineLaver;
    private int currentIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (objectsToBlink.Count > 0)
        {
            objectsToBlink[currentIndex].TriggerBlink();
        }   
    }

    public void ValidateCurrentStep(){
        if (currentIndex < objectsToBlink.Count)
        {
            // Stop le clignotement de l'objet courant
            objectsToBlink[currentIndex].StopBlink();
            switch (objectsToBlink[currentIndex].name)
            {
                case "Cube.011":
                    lightToOff.intensity = 0f;
                    break;

                case "tvOK":
                    videoController.Stop();
                    break;
                case "A0043.001":
                    machineLaver.ActiverPerturbation(false);
                    break;
                
            }
            currentIndex++;

            // Démarre le clignotement du prochain objet si disponible
            if (currentIndex < objectsToBlink.Count)
            {
                objectsToBlink[currentIndex].TriggerBlink();
            }
            else
            {
                Debug.Log("Tous les objets ont été validés.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

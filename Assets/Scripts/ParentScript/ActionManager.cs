using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ActionManager : MonoBehaviour
{

    [Header("Liste des objets dans l'ordre")]
    public List<Blinker> objectsToBlink;
    public List<Light> lightToOff;
    public VideoPlayer videoController;
    public Animator machineLaver;
    private int currentIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (objectsToBlink.Count > 0)
        {
            objectsToBlink[currentIndex].TriggerBlink();
            machineLaver.SetBool("Tourne", true);
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
                    lightToOff[0].intensity = 0f;
                    lightToOff[1].intensity = 0f;
                    lightToOff[2].intensity = 0f;

                    break;

                case "tvOK":
                    videoController.Stop();
                    break;
                case "A0043.001":
                    machineLaver.SetBool("Tourne", false);

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
                GameState.targetMenu = MenuState.End;
                SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

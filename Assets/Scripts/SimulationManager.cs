using System.Collections;
using TMPro;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    public MachineLaver scriptMachine;
    public Television scriptTelevision;
    public Lumiere scriptLumiere;


    public float tempsRestant = 60f;
    public bool isTimerRunning = false;
    public TextMeshProUGUI timerDisplay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isTimerRunning = true;
        StartCoroutine(SequenceDuRepas());
    }

    IEnumerator SequenceDuRepas()
    {
        // Etape 1 - Debut, plutot calme
        Debug.Log("Début : l'enfant doit commencer à trier.");
        yield return new WaitForSeconds(20f); //Attendre 10secondes

        // Etape 2 - Lumire qui clignote
        scriptLumiere.StartFlashing();
        yield return new WaitForSeconds(20f); //Attendre 10secondes

        // Etape 3 - Télé qui monte en volume + fourchette qui va tomber
        scriptTelevision.StartAudioPic();
        //faire tomber la fourchette
        yield return new WaitForSeconds(20f); //Attendre 10secondes

        // Etape 4 - La machine à laver s'emballe
        scriptMachine.ActiverPerturbation(true);
        yield return new WaitForSeconds(10f); //Attendre 10secondes
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            if (tempsRestant > 0)
            {
                tempsRestant -= Time.deltaTime;
                DisplayTime(tempsRestant);
            }
            else
            {
                Debug.Log("Temps écoulé!");
                tempsRestant = 0;
                isTimerRunning = false;
                FinirPartie();
            }
        }

    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60f);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60f);
        timerDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void FinirPartie()
    {
        Debug.Log("C'est la fin des petits poids............................");
        
    }
}

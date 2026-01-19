using System.Collections;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    public MachineLaver scriptMachine;
    public Television scriptTelevision;
    public Lumiere scriptLumiere;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SequenceDuRepas());
    }

    IEnumerator SequenceDuRepas()
    {
        // Etape 1 - Debut, plutot calme
        Debug.Log("Début : l'enfant doit commencer à trier.");
        yield return new WaitForSeconds(10f); //Attendre 10secondes

        // Etape 2 - Lumire qui clignote
        /*scriptLumiere.DemarrerClignotement();
        yield return new WaitForSeconds(15f);*/ //Attendre 10secondes

        // Etape 3 - Télé qui monte en volume + fourchette qui va tomber
        //scriptTelevion.LancerPicSonore();
        //faire tomber la fourchette
        //yield return new WaitForSeconds(5f); //Attendre 10secondes

        // Etape 4 - La machine à laver s'emballe
        /*scriptMachine.DemarrerVibration(0.8f)
        yield return new WaitForSeconds(10f); //Attendre 10secondes*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

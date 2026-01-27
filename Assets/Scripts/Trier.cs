using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Trier : MonoBehaviour
{
    public string targetTag;
    public int score = 0;
    public TextMeshProUGUI affichageScore;

    private HashSet<int> countedObjects = new HashSet<int>();

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag(targetTag))
        {
            int objectID = other.gameObject.GetInstanceID();
            if (!countedObjects.Contains(objectID))
            {
                // On l'ajoute à la liste pour ne plus le recompter
                countedObjects.Add(objectID);

                score++;
                Debug.Log($"Bien trié! Score {targetTag} : {score}");
                affichageScore.text = score.ToString();
            }   

            //other.gameObject.GetComponent<Rigidbody>().isKinematic = false; si je veux empecher l'objet de bouger après
        }
        else
        {
            Debug.Log("Mauvais aliment !");
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

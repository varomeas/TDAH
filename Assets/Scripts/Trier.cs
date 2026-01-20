using UnityEngine;

public class Trier : MonoBehaviour
{
    public string targetTag;
    public int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.CompareTag(targetTag))
        {
            score++;
            Debug.Log($"Bien trié! Score {targetTag} : {score}");

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

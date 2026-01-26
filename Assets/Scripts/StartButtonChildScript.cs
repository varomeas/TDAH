using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonChildScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        SceneManager.LoadScene("BasicScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

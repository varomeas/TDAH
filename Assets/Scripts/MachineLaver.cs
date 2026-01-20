using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class MachineLaver : MonoBehaviour
{
    public Rigidbody assietteRB;
    public float tremblement = 0.5f;

    public HapticImpulsePlayer leftController;
    public HapticImpulsePlayer rightController;

    private bool isRunning = false;

    public void ActiverPerturbation(bool state)
    {
        isRunning = state;
        Debug.Log("Machine activée");
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


            VibrerManette(leftController);
            VibrerManette(rightController);
        }
        
    }

    void VibrerManette(HapticImpulsePlayer controller)
    {
        if (controller != null)
        {
            controller.SendHapticImpulse(1f, Time.deltaTime);
        }
    }

}

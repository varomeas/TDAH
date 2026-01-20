using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ForcedDrop : MonoBehaviour
{
    [SerializeField] private XRInteractionManager interactionManager;

    [SerializeField] private XRInteractionGroup rightHandInteractor;


    public void FaireTomber()
    {
        Lacher(rightHandInteractor);
    }

    private void Lacher(XRInteractionGroup group)
    {
        if (group == null) return;

        var activeInteractor = group.activeInteractor;
        if (activeInteractor is IXRSelectInteractor selectInteractor)
        {
            if (selectInteractor.hasSelection)
            {
                var interactable = selectInteractor.firstInteractableSelected;
                interactionManager.CancelInteractableSelection(interactable);
                Debug.Log("Objet tombé");
            }
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

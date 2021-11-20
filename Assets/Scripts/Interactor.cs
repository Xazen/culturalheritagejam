using System;
using DefaultNamespace;
using DefaultNamespace.Interactable;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField]
    private float interactDistance = 3;

    [SerializeField] private GameObject indicator;
    private bool canInteract = false;
    private GameObject targetObject;

    private void Update()
    {
        if (canInteract && LookUp.PlayerInput.actions[InputActions.Action].WasPerformedThisFrame())
        {
            var interactable = targetObject.GetComponent<Interactable>() as IInteractable;
            interactable.Interact();
        }
    }

    private void FixedUpdate()
    {
        // Lift ray origin slightly off ground.
        var rayOrigin = transform.position;
        rayOrigin.y += 0.1f;

        RaycastHit hit;
        var fwd = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(rayOrigin, fwd * interactDistance, Color.red, 1);
        var hitSomething = Physics.Raycast(rayOrigin, fwd, out hit, interactDistance);
        if (hitSomething)
        {
            canInteract = hit.transform.gameObject.layer == Layers.Interactable; 
            if (canInteract)
            {
                targetObject = hit.transform.gameObject;
                print("There is something in front of the object!");
            }
        }
        else
        {
            canInteract = false;
        }
        
        indicator.SetActive(canInteract);
    }
}
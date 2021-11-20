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
            LookUp.PlayerInput.enabled = false;
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
                var hitObject = hit.transform.gameObject;
                var interactable = hitObject.GetComponent<Interactable>() as IInteractable;
                bool anyValidInteractables = interactable.IsAnyInteractable();
                canInteract = anyValidInteractables;

                if (anyValidInteractables)
                {
                    targetObject = hit.transform.gameObject;
                }
            }
        }
        else
        {
            canInteract = false;
        }
        
        indicator.SetActive(canInteract);
    }
}

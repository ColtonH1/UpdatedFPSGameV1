using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    bool isFocus = false;
    Transform player;
    public Transform interactionTransform; 

    bool hasInteracted = false;

    public virtual void Interact()//class to decide interaction
    {
        //this method is meant to be overwritten
        Debug.Log("Is interacting with " + transform);
    } 

    void Update()//will check if we can interact
    {
        if(isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position); //check if player is with radius
            if(distance <= radius)
            {
                Debug.Log("Interact");
                Interact();
                hasInteracted = true;
            }
        }
    } 

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}

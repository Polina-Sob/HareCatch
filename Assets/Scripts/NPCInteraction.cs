using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private DialoguePanel _dialoguePanel;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(mousePos);

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                _dialoguePanel.Open();
            }
        }
    }

    public void RemoveNPCFromWagon()
    {
        Destroy(gameObject);
    }
}


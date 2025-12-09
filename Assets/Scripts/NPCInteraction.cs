using UnityEngine;
using UnityEngine.EventSystems;

public class NPCInteraction : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(mousePos);

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                Debug.Log($"Диалог запущен кликом по {gameObject.name}.");
            }
        }
    }

    public void RemoveNPCFromWagon()
    {
        Debug.Log($"NPC: {gameObject.name} удален из сцены (из вагона)");
        Destroy(gameObject);
    }
}


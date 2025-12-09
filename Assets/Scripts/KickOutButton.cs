using UnityEngine;

public class KickOutButton : MonoBehaviour
{
    [SerializeField] private NPCInteraction _nPC;

    public void OnButtonClick()
    {
        _nPC.RemoveNPCFromWagon();
    }
}

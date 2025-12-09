using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private SatrtPanel _panel;

    [SerializeField] private Game _game;

    public void OnButtonClick()
    {
        _panel.Clouse();
        _game.Open();
    }
}

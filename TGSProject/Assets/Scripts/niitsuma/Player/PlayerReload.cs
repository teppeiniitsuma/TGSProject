using UnityEngine;

/// <summary>
/// チェックポイント的な奴
/// </summary>
public class PlayerReload : MonoBehaviour
{
    [SerializeField] private Transform _player;
    ReloadData _data = new ReloadData();

    public void LoadPositionRewriting(Transform t)
    {
        _data.loadPos = t.position;
    }
    public void Reload()
    {
        _player.position = _data.loadPos;
    }

}

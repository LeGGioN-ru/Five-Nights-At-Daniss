using UnityEngine;
using UnityEngine.Events;

public abstract class Room : MonoBehaviour
{
    [SerializeField] protected Sprite _noDanisPhoto;
    [SerializeField] protected Sprite _danisPhoto;
    [SerializeField] protected Room[] _linkeds;

    public UnityAction DanisMoved;

    protected bool _isDanisHere;

    public virtual Sprite GetCurrentPhoto()
    {
        if (_isDanisHere)
        {
            return _danisPhoto;
        }

        return _noDanisPhoto;
    }

    public void AddDanis()
    {
        _isDanisHere = true;
        DanisMoved?.Invoke();
    }

    public void MoveDanis(Room room)
    {
        _isDanisHere = false;
        room.AddDanis();
        DanisMoved?.Invoke();
    }

    public bool TryGetNextRoom(out Room room)
    {
        if (_linkeds.Length == 0)
        {
            room = null;
            return false;
        }

        room = _linkeds[Random.Range(0, _linkeds.Length)];

        return true;
    }
}

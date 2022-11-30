using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public abstract class Room : MonoBehaviour
{
    [SerializeField] protected Sprite _noDanisPhoto;
    [SerializeField] protected Sprite _danisPhoto;
    [SerializeField] protected Room[] _linkeds;

    public Sprite NoDanisPhoto => _noDanisPhoto;
    public Sprite DanisPhoto => _danisPhoto;

    public UnityAction DanisMoved;

    private List<bool> _danisesStatus = new List<bool>();

    protected bool IsDanisHere => _danisesStatus.FirstOrDefault(x => x == true);

    public int DanisCount => _danisesStatus.Count;

    public virtual Sprite GetCurrentPhoto()
    {
        if (IsDanisHere)
        {
            return _danisPhoto;
        }

        return _noDanisPhoto;
    }

    public void AddDanis()
    {
        _danisesStatus.Add(true);
        DanisMoved?.Invoke();
    }

    public void MoveDanis(Room nextRoom)
    {
        RemoveDanis();
        nextRoom.AddDanis();
    }

    private void RemoveDanis()
    {
        _danisesStatus.Remove(true);
        DanisMoved?.Invoke();
    }

    public bool TryGetNextRoom(out Room nextRoom)
    {
        if (_linkeds.Length == 0)
        {
            nextRoom = null;
            RemoveDanis();
            return false;
        }

        nextRoom = _linkeds[Random.Range(0, _linkeds.Length)];

        return true;
    }
}

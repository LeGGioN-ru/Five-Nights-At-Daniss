using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DanisCameraMover : MonoBehaviour
{
    [SerializeField] private Room _startRoom;
    [SerializeField] private float _moveDelay;

    public event UnityAction MoveEnd;

    private Room _currentRoom;

    private void Start()
    {
        _currentRoom = _startRoom;
        _startRoom.AddDanis();
        StartMove();
    }

    public void OnRunAway(Danis danis)
    {
        _currentRoom = _startRoom;
        _currentRoom.AddDanis();
        StartMove();

        danis.RanedAway -= OnRunAway;
    }

    private void StartMove()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        float passedTime = 0;

        while (passedTime < _moveDelay)
        {
            passedTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        EndMove();
    }

    private void EndMove()
    {
        if (_currentRoom.TryGetNextRoom(out Room room))
        {
            _currentRoom.MoveDanis(room);
            _currentRoom = room;
            StartMove();
            return;
        }

        _currentRoom.RemoveDanis();

        MoveEnd?.Invoke();
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DanisCameraMover : MonoBehaviour
{
    [SerializeField] private Room _startRoom;
    [SerializeField] private float _moveDelay;
    [SerializeField] private GameEnder _gameEnder;

    public event UnityAction<DanisCameraMover> MoveEnd;

    private Room _currentRoom;

    private void OnEnable()
    {
        _gameEnder.Ended += OnGameEnd;
    }

    private void OnDisable()
    {
        _gameEnder.Ended -= OnGameEnd;
    }

    private void Start()
    {
        ResetPosition();
    }

    public void ResetPosition()
    {
        _currentRoom = _startRoom;
        _startRoom.AddDanis();
        StartMove();
    }

    public void OnRunAway(Danis danis)
    {
        ResetPosition();

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

        MoveEnd?.Invoke(this);
    }

    private void OnGameEnd()
    {
        enabled = false;
    }
}

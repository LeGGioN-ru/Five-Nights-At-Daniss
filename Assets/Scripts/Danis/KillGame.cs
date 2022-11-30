using UnityEngine;

public class KillGame : MonoBehaviour
{
    [SerializeField] private DanisCameraMover[] _danisCameraMovers;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Danis[] _danisTypes;
    [SerializeField] private Door[] _doors;
    [SerializeField] private WallLight[] _wallLights;
    [SerializeField] private Table _table;
    [SerializeField] private JumpScare _jumpScare;
    [SerializeField] private PlayerLooker _playerLooker;
    [SerializeField] private GameEnder _gameEnder;
    [SerializeField] private Player _player;

    private Danis _danis;

    private void OnEnable()
    {
        foreach (var danisCameraMover in _danisCameraMovers)
        {
            danisCameraMover.MoveEnd += OnMoveEnded;
        }


        _gameEnder.Ended += OnGameEnd;
    }

    private void OnDisable()
    {
        foreach (var danisCameraMover in _danisCameraMovers)
        {
            danisCameraMover.MoveEnd -= OnMoveEnded;
        }
        _gameEnder.Ended -= OnGameEnd;
    }

    private void OnMoveEnded(DanisCameraMover mover)
    {
        int apptembsBeforeGoBack = 0;

        Danis randomDanis = _danisTypes[Random.Range(0, _danisTypes.Length)];
        var randomPointIndex = Random.Range(0, _spawnPoints.Length);

        while (_spawnPoints[randomPointIndex].GetComponentInChildren<Danis>() != null)
        {
            randomPointIndex = Random.Range(0, _spawnPoints.Length);
            apptembsBeforeGoBack++;

            if (apptembsBeforeGoBack >= 100)
            {
                mover.ResetPosition();
                return;
            }
        }

        bool isLeftSide = randomPointIndex == 0;

        _danis = Instantiate(randomDanis, _spawnPoints[randomPointIndex]);

        _danis.Init(isLeftSide, _doors, _wallLights, _table, _player);

        _danis.RanedAway += mover.OnRunAway;

        _jumpScare.Init(_danis);
        _playerLooker.SubscribeOnDanis(_danis);
    }

    private void OnGameEnd()
    {
        if (_danis != null)
        {
            Destroy(_danis);
        }
    }
}

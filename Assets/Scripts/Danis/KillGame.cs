using UnityEngine;

public class KillGame : MonoBehaviour
{
    [SerializeField] private DanisCameraMover _danisCameraMover;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Danis[] _danisTypes;
    [SerializeField] private Door[] _doors;
    [SerializeField] private WallLight[] _wallLights;

    private void OnEnable()
    {
        _danisCameraMover.MoveEnd += OnMoveEnded;
    }

    private void OnDisable()
    {
        _danisCameraMover.MoveEnd -= OnMoveEnded;
    }

    private void OnMoveEnded()
    {
        Danis randomDanis = _danisTypes[Random.Range(0, _danisTypes.Length)];
        var randomPointIndex = Random.Range(0, _spawnPoints.Length);

        bool isLeftSide = randomPointIndex == 0;

        var danis = Instantiate(randomDanis, _spawnPoints[randomPointIndex]);

        danis.Init(isLeftSide, _doors, _wallLights);

        danis.RanedAway += _danisCameraMover.OnRunAway;
    }
}

using IJunior.TypedScenes;
using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Video;

public class GameEnding : DialogueEvent
{
    [SerializeField] private TruckMover _truckMover;
    [SerializeField] private Animator _animatorTruck;
    [SerializeField] private Animator _animatorCar;
    [SerializeField] private float _newSpeed;
    [SerializeField] private DialogueShower _dialogShower;
    [SerializeField] private GameObject _video;
    [SerializeField] private VideoPlayer _vieoPlayer;
    [SerializeField] private PostProcessVolume _postProcess;
    [SerializeField] private float _durationPostProcessEnd;
    [SerializeField] private float _videoShowDelay;

    private float _passedTime;

    public override async void Happen()
    {
        StartCoroutine(SmoothWeight());
        _animatorCar.speed = _newSpeed;
        _animatorTruck.speed = _newSpeed;

        if (IsEndingGood())
        {
            return;
        }

        _truckMover.Happen();
        _dialogShower.gameObject.SetActive(false);
        await Task.Delay(Convert.ToInt32(_videoShowDelay * 1000));
        _video.SetActive(true);
        await Task.Delay(Convert.ToInt32(_vieoPlayer.clip.length * 1000));
        MainMenu.Load(new LevelConfiguration(false, false, 0));
    }

    private bool IsEndingGood()
    {
        var save = SaveChecker.TryGetSaveFile();

        foreach (var level in save.LevelConfigurations)
        {
            if (level.IsPuareCollect == false)
            {
                return false;
            }
        }

        return true;
    }

    private IEnumerator SmoothWeight()
    {
        while (_passedTime < _durationPostProcessEnd)
        {
            _passedTime += Time.deltaTime;
            _postProcess.weight = Mathf.Lerp(1, 0, _passedTime / _durationPostProcessEnd);
            yield return null;
        }
    }
}

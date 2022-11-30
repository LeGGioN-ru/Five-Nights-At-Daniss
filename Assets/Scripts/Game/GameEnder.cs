using IJunior.TypedScenes;
using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class GameEnder : MonoBehaviour
{
    [SerializeField] private float _gameDuration;
    [SerializeField] private int _levelNumber;
    [SerializeField] private PuarchikDetector _puarchik;
    [SerializeField] private AudioSource _sound;
    [SerializeField] private int _mainMenuLoadDelay;
    [SerializeField] private GameEndScreen _screen;
    [SerializeField] private AudioMixer _mainMixer;

    public int LevelNumber => _levelNumber;

    public event UnityAction Ended;
    public event UnityAction<int> TimeChanged;

    private int _previosHour;

    private void OnEnable()
    {
        TimeChanged?.Invoke(0);
        _screen.Ended += GoMainMenu;
    }

    private void OnDisable()
    {
        _screen.Ended -= GoMainMenu;
    }

    private void Start()
    {
        StartCoroutine(EndGame());
    }

    private IEnumerator EndGame()
    {
        float passedTime = 0;

        while (passedTime / 60 < _gameDuration)
        {
            if (Convert.ToInt32(passedTime / 60) != _previosHour)
            {
                _previosHour = Convert.ToInt32(passedTime / 60);
                TimeChanged?.Invoke(_previosHour);
            }

            passedTime += Time.deltaTime;
            yield return null;
        }

        _sound.Play();
        _mainMixer.SetFloat("Volume", -80);
        Ended?.Invoke();
    }

    private async void GoMainMenu()
    {
        await Task.Delay(_mainMenuLoadDelay);

        if (_levelNumber == 4)
        {
            var saveFile = SaveChecker.TryGetSaveFile();
            saveFile.SaveData(new LevelConfiguration(true, _puarchik.IsCollect, _levelNumber));
            EndRoom.Load();
            return;
        }

        MainMenu.Load(new LevelConfiguration(true, _puarchik.IsCollect, _levelNumber));
    }
}

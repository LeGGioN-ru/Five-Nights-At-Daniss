using IJunior.TypedScenes;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using DG.Tweening;

public class GoodEnding : DialogueEvent
{
    [SerializeField] private GameObject _videoGoodEnd;
    [SerializeField] private VideoPlayer _video;
    [SerializeField] private RawImage _videoImage;
    [SerializeField] private float _durationIncarnate;

    public override async void Happen()
    {
        _videoGoodEnd.SetActive(true);
        _videoImage.DOFade(1, _durationIncarnate);
        await Task.Delay(Convert.ToInt32(_video.clip.length * 1000));
        var save = SaveChecker.TryGetSaveFile();
        save.GotGoodEnd();
        save.SaveData();
        MainMenu.Load(new LevelConfiguration(true, true, 0));
    }
}

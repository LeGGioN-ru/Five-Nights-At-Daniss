using UnityEngine;

public class GoodEndChecker : MonoBehaviour
{
    [SerializeField] private GameObject _trophes;

    private void Start()
    {
        var save = SaveChecker.TryGetSaveFile();

        if (save.IsGoodEndGot)
        {
            _trophes.SetActive(true);
        }
    }
}

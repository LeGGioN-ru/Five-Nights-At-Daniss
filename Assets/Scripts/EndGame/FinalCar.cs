using IJunior.TypedScenes;
using UnityEngine;

public class FinalCar : MonoBehaviour
{
    [SerializeField] private GameObject _loadScreen;

    public void Drive()
    {
        _loadScreen.SetActive(true);
        EndGameDialog.Load();
    }
}

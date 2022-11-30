using UnityEngine;

public class FinalCarFinder : MonoBehaviour
{
    [SerializeField] private ObjectFinder _finder;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_finder.TryFindObject(out FinalCar car))
            {
                car.Drive();
            }
        }
    }
}

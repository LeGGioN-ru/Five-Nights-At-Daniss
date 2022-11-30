using UnityEngine;

public class ButtonFinder : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private ObjectFinder _finder;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_finder.TryFindObject(out WallButton button))
            {
                button.Clicked();
            }
        }
    }
}

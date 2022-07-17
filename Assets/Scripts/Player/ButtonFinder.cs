using UnityEngine;

public class ButtonFinder : MonoBehaviour
{
    [SerializeField] private float _distance;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            var hits = Physics.RaycastAll(ray, _distance);

            foreach (var item in hits)
            {
                if (item.collider.gameObject.TryGetComponent(out WallButton button))
                {
                    button.Clicked();
                }
            }
        }
    }
}

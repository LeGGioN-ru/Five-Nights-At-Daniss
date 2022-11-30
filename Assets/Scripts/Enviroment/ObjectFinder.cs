using UnityEngine;

public class ObjectFinder : MonoBehaviour
{
    [SerializeField] private float _distance;

    public bool TryFindObject<T>(out T finalType)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        var hits = Physics.RaycastAll(ray, _distance);

        foreach (var item in hits)
        {
            if (item.collider.gameObject.TryGetComponent(out T type))
            {
                finalType = type;
                return true;
            }
        }

        finalType = default(T);

        return false;
    }
}

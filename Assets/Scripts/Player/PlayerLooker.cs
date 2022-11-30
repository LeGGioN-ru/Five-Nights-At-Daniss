using System.Threading.Tasks;
using UnityEngine;

public class PlayerLooker : MonoBehaviour
{
    [SerializeField] private float _minVerticalPitch;
    [SerializeField] private float _maxVerticalPitch;

    private float _horizontalPitch;
    private float _verticalPitch;

    private void Update()
    {
        _horizontalPitch += Input.GetAxis(Axis.MouseAxis.MouseX);
        _verticalPitch -= Input.GetAxis(Axis.MouseAxis.MouseY);

        _verticalPitch = Mathf.Clamp(_verticalPitch, _minVerticalPitch, _maxVerticalPitch);

        transform.rotation = Quaternion.Euler(_verticalPitch, _horizontalPitch, 0);
    }

    public void SubscribeOnDanis(Danis danis)
    {
        danis.Attacked += OnDanisAttack;
    }

    private void OnDanisAttack(Danis danis)
    {
        enabled = false;
        danis.Attacked -= OnDanisAttack;
    }

    public void ResetRotation()
    {
        _horizontalPitch = 0;
        _verticalPitch = 0;

        transform.rotation = Quaternion.Euler(_verticalPitch, _horizontalPitch, 0);
    }
}

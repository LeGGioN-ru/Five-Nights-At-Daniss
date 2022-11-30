using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ButtonSelector))]
public class PuareAttackUI : MonoBehaviour
{
    [SerializeField] private ButtonSelector _kitchenSelector;
    [SerializeField] private GameObject _upButton;
    [SerializeField] private ButtonSelector _thisSelector;
    [SerializeField] private Image _puareStatus;
    [SerializeField] private PuareAttack _puareAttack;
    [SerializeField] private float _checkDelay;

    private void OnEnable()
    {
        _kitchenSelector.Selected += OnSelect;
        _kitchenSelector.DeSelected += OnDeselect;
        _thisSelector.DeSelected += OnDeselect;
        _puareAttack.PatienceChange += OnPatienceChanged;
    }

    private void OnDisable()
    {
        _kitchenSelector.Selected -= OnSelect;
        _kitchenSelector.DeSelected -= OnDeselect;
        _puareAttack.PatienceChange -= OnPatienceChanged;
        _thisSelector.DeSelected -= OnDeselect;
    }

    private void OnSelect()
    {
        _upButton.SetActive(true);
    }

    private void OnDeselect()
    {
        StartCoroutine(CheckWithDelay());
    }

    private IEnumerator CheckWithDelay()
    {
        float passedTime = 0;

        while (passedTime < _checkDelay)
        {
            passedTime += Time.deltaTime;
            yield return null;
        }

        if (_kitchenSelector.IsSelected == false && _thisSelector.IsSelected == false)
        {
            _upButton.SetActive(false);
        }
    }

    private void OnPatienceChanged(float value)
    {
        _puareStatus.fillAmount = value;
    }
}

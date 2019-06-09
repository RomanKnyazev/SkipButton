using UnityEngine;
using UnityEngine.UI;

public class ButtonFilling : MonoBehaviour
{
    [SerializeField] private Image _fillImage;
    [SerializeField] private KeyCode keyCode = KeyCode.X;
    [SerializeField] private float _fillingTime = 3.0f;
    [SerializeField] private Vector2 _startHolderScale;
    [SerializeField] private Vector2 _targetHoldercale = new Vector2(1.2f, 1.2f);
    
    private Button _holder;
    private Button _button;
    
    private RectTransform _rectTransform;

    private float _activeSpeed = .5f;
    private float _cooldownSpeed = .6f;
    private bool _functionTriggered;
    
    private void Start()
    {
        _button = GetComponent<Button>();
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        _fillImage.fillAmount +=
            ((Input.GetKey(keyCode) && !_functionTriggered) ? _activeSpeed : -_cooldownSpeed) * Time.deltaTime;

        _rectTransform.localScale = Vector2.Lerp(
            _startHolderScale,
            _targetHoldercale,
            _fillImage.fillAmount * _fillImage.fillAmount 
        );

        if (_functionTriggered || _fillImage.fillAmount != 1) return;
        _functionTriggered = true;
        _button.onClick.Invoke();
    }
}
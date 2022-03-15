using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inputs : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputHeight;
    [Space]
    [SerializeField] private TMP_InputField _inputUp;
    [SerializeField] private TMP_InputField _inputDown;
    [SerializeField] private TMP_InputField _inputLeft;
    [SerializeField] private TMP_InputField _inputRight;
    [Space]
    [SerializeField] private Button _start;
    
    [Header("Parameters")]
    [SerializeField] private Simulation _simulation;
    private readonly TextValidator _textValidator = new TextValidator();

    private void OnEnable()
    {
        _inputHeight.onValueChanged.AddListener(OnHeightChange);
        
        _inputUp.onValueChanged.AddListener(OnUpChange);
        _inputDown.onValueChanged.AddListener(OnDownChange);
        _inputLeft.onValueChanged.AddListener(OnLeftChange);
        _inputRight.onValueChanged.AddListener(OnRightChange);

        _start.onClick.AddListener(OnStartClick);
    }

    private void OnDisable()
    {
        _inputHeight.onValueChanged.RemoveListener(OnHeightChange);
        
        _inputUp.onValueChanged.RemoveListener(OnUpChange);
        _inputDown.onValueChanged.RemoveListener(OnDownChange);
        _inputLeft.onValueChanged.RemoveListener(OnLeftChange);
        _inputRight.onValueChanged.RemoveListener(OnRightChange);
        
        _start.onClick.RemoveListener(OnStartClick);
    }

    private void OnHeightChange(string text)
    {
        var input = TextValidator.ValidateToInt(text);

        if (input != "")
        {
            UpdateHeight(input);
        }
        else
        {
            _inputHeight.SetTextWithoutNotify("");
        }
    }

    private void OnUpChange(string text)
    {
        var input = TextValidator.ValidateToFloat(text);

        if (input != "")
        {
            UpdateUp(input);
        }
        else
        {
            _inputUp.SetTextWithoutNotify("");
        }
    }

    private void OnDownChange(string text)
    {
        var input = TextValidator.ValidateToFloat(text);
        
        if (input != "")
        {
            UpdateDown(input);
        }
        else
        {
            _inputDown.SetTextWithoutNotify("");
        }
    }

    private void OnLeftChange(string text)
    {
        var input = TextValidator.ValidateToFloat(text);
        
        if (input != "")
        {
            UpdateLeft(input);
        }
        else
        {
            _inputLeft.SetTextWithoutNotify("");
        }
    }

    private void OnRightChange(string text)
    {
        var input = TextValidator.ValidateToFloat(text);
        
        if (input != "")
        {
            UpdateRight(input);
        }
        else
        {
            _inputRight.SetTextWithoutNotify("");
        }
    }

    private void OnStartClick()
    {
        _simulation.StartSimulation();
    }

    private void UpdateHeight(string input)
    {
        var value = int.Parse(input);
        value = Mathf.Clamp(value, 1, 18);
        _inputHeight.SetTextWithoutNotify(value.ToString());
        _simulation.Height = value;
    }

    private void UpdateUp(string input)
    {
        if (_textValidator.TryMatchInteger(input, out var integer))
        {
            _inputUp.SetTextWithoutNotify(integer.ToString());
            _simulation.Up = integer;
        }
        else if (_textValidator.TryMatchFloat(input, out var floating))
        {
            _inputUp.SetTextWithoutNotify(floating.ToString());
            _simulation.Up = floating;
        }
        else
        {
            _inputUp.SetTextWithoutNotify(input);
        }
        
        _inputUp.stringPosition = _inputUp.text.Length;
    }

    private void UpdateDown(string input)
    {
        if (_textValidator.TryMatchInteger(input, out var integer))
        {
            _inputDown.SetTextWithoutNotify(integer.ToString());
            _simulation.Down = integer;
        }
        else if (_textValidator.TryMatchFloat(input, out var floating))
        {
            _inputDown.SetTextWithoutNotify(floating.ToString());
            _simulation.Down = floating;
        }
        else
        {
            _inputDown.SetTextWithoutNotify(input);
        }
        
        _inputDown.stringPosition = _inputDown.text.Length;
    }

    private void UpdateLeft(string input)
    {
        if (_textValidator.TryMatchInteger(input, out var integer))
        {
            _inputLeft.SetTextWithoutNotify(integer.ToString());
            _simulation.Left = integer;
        }
        else if (_textValidator.TryMatchFloat(input, out var floating))
        {
            _inputLeft.SetTextWithoutNotify(floating.ToString());
            _simulation.Left = floating;
        }
        else
        {
            _inputLeft.SetTextWithoutNotify(input);
        }
        
        _inputLeft.stringPosition = _inputLeft.text.Length;
    }

    private void UpdateRight(string input)
    {
        if (_textValidator.TryMatchInteger(input, out var integer))
        {
            _inputRight.SetTextWithoutNotify(integer.ToString());
            _simulation.Right = integer;
        }
        else if (_textValidator.TryMatchFloat(input, out var floating))
        {
            _inputRight.SetTextWithoutNotify(floating.ToString());
            _simulation.Right = floating;
        }
        else
        {
            _inputRight.SetTextWithoutNotify(input);
        }
        
        _inputRight.stringPosition = _inputRight.text.Length;
    }
}

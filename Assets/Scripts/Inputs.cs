using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inputs : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputTickTime;
    [Space]
    [SerializeField] private TMP_InputField _inputHeight;
    [Space]
    [SerializeField] private TMP_InputField _inputUp;
    [SerializeField] private TMP_InputField _inputDown;
    [SerializeField] private TMP_InputField _inputLeft;
    [SerializeField] private TMP_InputField _inputRight;
    [Space]
    [SerializeField] private Button _start;
    [SerializeField] private Button _stop;
    
    [Header("Parameters")]
    [SerializeField] private Simulation _simulation;
    private readonly TextValidator _textValidator = new TextValidator();

    private void Start()
    {
        _simulation.SetHeight(int.Parse(_inputHeight.text));

        _simulation.Up = float.Parse(_inputUp.text);
        _simulation.Down = float.Parse(_inputDown.text);
        _simulation.Left = float.Parse(_inputLeft.text);
        _simulation.Right = float.Parse(_inputRight.text);
    }

    private void OnEnable()
    {
        _inputTickTime.onValueChanged.AddListener(OnTickTimeChange);
        
        _inputHeight.onValueChanged.AddListener(OnHeightChange);
        
        _inputUp.onValueChanged.AddListener(OnUpChange);
        _inputDown.onValueChanged.AddListener(OnDownChange);
        _inputLeft.onValueChanged.AddListener(OnLeftChange);
        _inputRight.onValueChanged.AddListener(OnRightChange);

        _start.onClick.AddListener(OnStartClick);
        _stop.onClick.AddListener(OnStopClick);

        _simulation.ValuesChange += OnValuesChange;
    }

    private void OnDisable()
    {
        _inputTickTime.onValueChanged.RemoveListener(OnTickTimeChange);
        
        _inputHeight.onValueChanged.RemoveListener(OnHeightChange);
        
        _inputUp.onValueChanged.RemoveListener(OnUpChange);
        _inputDown.onValueChanged.RemoveListener(OnDownChange);
        _inputLeft.onValueChanged.RemoveListener(OnLeftChange);
        _inputRight.onValueChanged.RemoveListener(OnRightChange);
        
        _start.onClick.RemoveListener(OnStartClick);
        _stop.onClick.RemoveListener(OnStopClick);
        
        _simulation.ValuesChange += OnValuesChange;
    }

    private void OnHeightChange(string text)
    {
        var input = TextValidator.ValidateToInt(text);

        if (input != "")
        {
            _simulation.StopSimulation();
            UpdateHeight(input);
        }
        else
        {
            _inputHeight.SetTextWithoutNotify("");
        }
    }

    private void OnTickTimeChange(string text)
    {
        var input = TextValidator.ValidateToFloat(text);

        if (input != "")
        {
            UpdateSpeed(input);
        }
        else
        {
            _inputTickTime.SetTextWithoutNotify("");
        }
    }

    private void OnUpChange(string text)
    {
        var input = TextValidator.ValidateToFloat(text);

        if (input != "")
        {
            _simulation.StopSimulation();
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
            _simulation.StopSimulation();
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
            _simulation.StopSimulation();
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
            _simulation.StopSimulation();
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

    private void OnStopClick()
    {
        _simulation.StopSimulation();
    }

    private void OnValuesChange(float up, float down, float left, float right)
    {
        _inputUp.SetTextWithoutNotify($"{Math.Round(up, 2)}");
        _inputDown.SetTextWithoutNotify($"{Math.Round(down, 2)}");
        _inputLeft.SetTextWithoutNotify($"{Math.Round(left, 2)}");
        _inputRight.SetTextWithoutNotify($"{Math.Round(right, 2)}");
    }

    private void UpdateHeight(string input)
    {
        var value = int.Parse(input);
        value = Mathf.Clamp(value, 1, 18);
        _inputHeight.SetTextWithoutNotify(value.ToString());
        _simulation.SetHeight(value);
    }

    private void UpdateSpeed(string input)
    {
        if (_textValidator.TryMatchInteger(input, out var integer))
        {
            _inputTickTime.SetTextWithoutNotify(integer.ToString());
            _simulation.TickTime = integer;
        }
        else if (_textValidator.TryMatchFloat(input, out var floating))
        {
            _inputTickTime.SetTextWithoutNotify(floating.ToString());
            _simulation.TickTime = floating;
        }
        else
        {
            _inputTickTime.SetTextWithoutNotify(input);
        }
        
        _inputTickTime.stringPosition = _inputTickTime.text.Length;
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

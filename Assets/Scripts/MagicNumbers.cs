using TMPro;
using UnityEngine;

public class MagicNumbers : MonoBehaviour
{
    #region Variables

    [SerializeField] private int _max = 1000;
    [SerializeField] private int _min;
    [SerializeField] private TextMeshProUGUI _consoleText;
    private int _attempt;

    private int _guess;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        RestartGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _max = _guess;
            CalculateGuessAndLog();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _min = _guess;
            CalculateGuessAndLog();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            LogMessage($"Ура! Ваше число отгадано и равно {_guess}! Количество ходов: {_attempt}");

            RestartGame();
        }
    }

    #endregion

    #region Private methods

    private void CalculateGuessAndLog()
    {
        _guess = (_max + _min) / 2;
        _attempt++;
        LogMessage($"Ваше число равно: {_guess}?");
    }

    private void LogMessage(string message)
    {
        _consoleText.text += message + "\n";
    }

    private void RestartGame()
    {
        _max = 1000;
        _min = 0;
        _attempt = 0;

        LogMessage($"Привет! Вы играете в Magic Numbers. Загадайте число от {_min} до {_max}");

        CalculateGuessAndLog();
    }

    #endregion
}
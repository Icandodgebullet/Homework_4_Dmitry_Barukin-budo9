using TMPro;
using UnityEngine;

public class FunWithNumbers : MonoBehaviour
{
    #region Variables

    private const int _targetSum = 50;
    [SerializeField] private TextMeshProUGUI _messageText;
    [SerializeField] private TextMeshProUGUI _sumText;
    private int _moves;
    private int _sum;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        ResetGame();
    }

    private void Update()
    {
        for (int i = 1; i <= 9; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                AddToSum(i);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetGame();
        }
    }

    #endregion

    #region Private methods

    private void AddToSum(int number)
    {
        _sum += number;
        _moves++;
        _sumText.text = "Сумма: " + _sum;

        if (_sum >= _targetSum)
        {
            _messageText.text = "Игра окончена! Количество ходов: " + _moves;
            Invoke("ResetGame", 2f);
        }
    }

    private void ResetGame()
    {
        _sum = 0;
        _moves = 0;
        _sumText.text = "Сумма: " + _sum;
        _messageText.text = "Нажмите цифру:";
    }

    #endregion
}
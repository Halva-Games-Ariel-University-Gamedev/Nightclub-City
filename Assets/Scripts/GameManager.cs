using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int money = 0;
    public TextMeshProUGUI moneyText;
    public GameObject dollarPrefab;


    void Awake()
    {

        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        UpdateMoneyText();
    }

    public void AddMoney(int amount)
    {
        money += amount;
        UpdateMoneyText();
    }

    public void SpendMoney(int amount)
    {
        money -= amount;
        if (money < 0) money = 0;
        UpdateMoneyText();
    }

    void UpdateMoneyText()
    {
        moneyText.text = "CASH: $" + money;
    }
}

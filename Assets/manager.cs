using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class manager : MonoBehaviour
{
    private float money = 0;
    public TMP_Text moneyText;
    // Start is called before the first frame update
    void Start()
    {
        moneyText.text= money.ToString();
    }
    public void addMoney(float amount)
    {
        money += amount;
        moneyText.text = money.ToString();
    }

    public float getMoney()
    {
        return money;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

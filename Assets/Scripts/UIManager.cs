using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int money = 0, level = 1, money_to_upgrade = 20;
    private Text money_text, level_text, clicker_btn_text, upgrade_text;
    private Button upgrade_btn;
    public GameObject dollar;
    Color red_active, green_deactive, green_active;

    void Start()
    {
        ColorUtility.TryParseHtmlString("#00FF01", out green_active);
        ColorUtility.TryParseHtmlString("#008401", out green_deactive);
        ColorUtility.TryParseHtmlString("#FF0C00", out red_active);
        FindObjects();
    }

    void Update()
    {
        clicker_btn_text.text = "+" + level.ToString();
        ColorBlock colorBlock = upgrade_btn.colors;
        if (money >= money_to_upgrade)
        {
            colorBlock.normalColor = green_active;
            colorBlock.highlightedColor = green_active;
            colorBlock.selectedColor = green_active;
            colorBlock.pressedColor = green_deactive;
            colorBlock.disabledColor = green_deactive;
            upgrade_btn.colors = colorBlock;
        }
        else
        {
            colorBlock.normalColor = red_active;
            colorBlock.highlightedColor = red_active;
            colorBlock.selectedColor = red_active;
            colorBlock.pressedColor = red_active;
            colorBlock.disabledColor = red_active;
            upgrade_btn.colors = colorBlock;
        }
    }

    public void ClickerBtn()
    {
        money += level;
        money_text.text = money.ToString();
        Instantiate(dollar, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
    }

    public void UpgradeBtn()
    {
        if(money >= money_to_upgrade)
        {
            level++;
            level_text.text = "LV " + level;
            money -= money_to_upgrade;
            money_text.text = money.ToString();
            money_to_upgrade = money_to_upgrade + level * 10;
            upgrade_text.text = "UPGRADE    " + money_to_upgrade;
        }
    }

    public void FindObjects()
    {
        money_text = GameObject.Find("Money_text").GetComponent<Text>();
        level_text = GameObject.Find("Level_text").GetComponent<Text>();
        clicker_btn_text = GameObject.Find("Btn_clicker_text").GetComponent<Text>();
        upgrade_text = GameObject.Find("Btn_upgrade_text").GetComponent<Text>();
        upgrade_btn = GameObject.Find("Btn_upgrade").GetComponent<Button>();
    }
}

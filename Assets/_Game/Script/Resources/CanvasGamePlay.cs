using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasGamePlay : UICanvas
{
    [SerializeField] private TextMeshProUGUI coinText;
    JoystickControl joys;
    public override void Setup()
    {

        base.Setup();
        UpdateCoin(0);
    }
    public void UpdateCoin(int coin)
    {
        coinText.text = coin.ToString();
    }
    public void SettingButton()
    {
        UIManager.Instance.OpenUI<CanvasSetting>();
    }
}

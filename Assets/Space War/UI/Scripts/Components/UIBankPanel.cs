using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIBankPanel : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private TextMeshProUGUI BankValueText;

    #endregion

    #region LifeCircle

    private void Awake()
    {
        BankValueText.text =  ((int)GridWorld.Instance.BankValue).ToString();
    }

    #endregion

    #region PrivateMethods

    private void FixedUpdate()
    {
        BankValueText.text = ((int)GridWorld.Instance.BankValue).ToString();
    }

    #endregion
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class healthUI : MonoBehaviour
{
    TextMeshProUGUI hpText;
    
    void Awake()
    {
        hpText = GetComponent<TextMeshProUGUI>();
        playerHealth.healthChanged.AddListener(HealthChanged);
    }

    private void HealthChanged()
    {
        hpText.text = "HP:  "+ playerHealth.instance.currentHealth.ToString();
    }
}

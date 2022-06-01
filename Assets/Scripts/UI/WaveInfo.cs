using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveInfo : BaseUIBehaviour
{
    [SerializeField] private TextMeshProUGUI _waveText;

    public void SetWaveNumber(int number)
    {
        _waveText.text = number.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using Helpers;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private FloatVariable _elapsedTime;
    private TMP_Text _elapsedTimeText;

    
    // Start is called before the first frame update
    void Start()
    {
        _elapsedTimeText = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string formattedTime = FormattingHelper.FormatFloatToTime(_elapsedTime.Value);
        _elapsedTimeText.text = $"<mspace=0.6em>{formattedTime}";
    }
}

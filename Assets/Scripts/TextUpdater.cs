using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour {

    public Text text;
    public ListenableInt value;

    private void OnEnable() {
        text.text = value.Value.ToString();
        value.onChange += UpdateText; //référence vers une fonction
    }

    private void OnDisable() {
        value.onChange -= UpdateText;
    }

    private void UpdateText() {
        text.text = value.Value.ToString();
    }
}

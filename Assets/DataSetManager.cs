using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataSetManager : MonoBehaviour
{
    private List<string> _dataSets = new List<string>()
    {
        "Life Expectancy",
        "Child and Infant Mortality",
        "Maternal Mortality",
        "Global Health",
        "Causes of Death",
        "Burden of Disease",
        "Cancer",
        "Mental Health",
        "Suicide",
        "Coronavirus Pandemic (Covid-19)",
    };

    [SerializeField] private RectTransform _buttonContainer;
    [SerializeField] private GameObject _buttonPrefab;

    public void Search(string pattern)
    {
        for (int i = _buttonContainer.childCount - 1; i >= 0; i--)
        {
            Destroy(_buttonContainer.GetChild(i).gameObject);
        }

        var searchAlgorithm = new BoyerMoore(pattern, true);

        foreach (var dataSet in _dataSets)
        {
            var shiftValue = searchAlgorithm.Search(dataSet);
            
            if (shiftValue >= 0 && shiftValue <= 1)
            {
                Debug.Log($"{shiftValue} {dataSet}");
                var g = GameObject.Instantiate(_buttonPrefab, _buttonContainer);

                g.GetComponentInChildren<TextMeshProUGUI>().text = dataSet;
            }
        }
    }
}

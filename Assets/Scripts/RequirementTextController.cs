using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RequirementTextController : MonoBehaviour
{
    public void ChangeText(int requiredAmount)
    {
        GetComponent<TextMeshProUGUI>().SetText(requiredAmount.ToString());
    }
}

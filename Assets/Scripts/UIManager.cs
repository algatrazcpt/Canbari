using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerHealthController Player;
    [SerializeField] SpeedSkill _speedSkill;
    [SerializeField] GameObject _speedArea;

    [SerializeField] TeleportSkill _teleportSkill;
    [SerializeField] GameObject _teleportArea;

    [SerializeField] SeeRadiusSkill _seeRadiusSkill;
    [SerializeField] GameObject _seeRadiusArea;

    [SerializeField] RadiusSkill _radiusSkill;
    [SerializeField] GameObject _radiusArea;
    
    [SerializeField] TextMeshProUGUI _crystalCountText;

    
    void Update()
    {
        if(_speedSkill.isUsed){
            _speedArea.SetActive(true);
        }
        else
        {
            _speedArea.SetActive(false);
        }
        if (_teleportSkill.isUsed)
        {
            _teleportArea.SetActive(true);
        }
        else
        {
            _teleportArea.SetActive(false);
        }
        if (_seeRadiusSkill.isUsed)
        {
            _seeRadiusArea.SetActive(true);
        }
        else
        {
            _seeRadiusArea.SetActive(false);
        }
        if (_radiusSkill.isUsed)
        {
            _radiusArea.SetActive(true);
        }
        else
        {
            _radiusArea.SetActive(false);
        }
        _crystalCountText.text = Player.crystalCount + "/6";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] SpeedSkill _speedSkill;
    [SerializeField] GameObject _speedArea;
    [SerializeField] Image _speedIcon;
    [SerializeField] Image _speedFillArea;

    [SerializeField] TeleportSkill _teleportSkill;
    [SerializeField] GameObject _teleportArea;
    [SerializeField] Image _teleportIcon;
    [SerializeField] Image _teleportFillArea;

    [SerializeField] SeeRadiusSkill _seeRadiusSkill;
    [SerializeField] GameObject _seeRadiusArea;
    [SerializeField] Image _seeRadiusIcon;
    [SerializeField] Image _seeRadiusFillArea;

    [SerializeField] RadiusSkill _radiusSkill;
    [SerializeField] GameObject _radiusArea;
    [SerializeField] Image _radiusIcon;
    [SerializeField] Image _radiusFillArea;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
    }
}

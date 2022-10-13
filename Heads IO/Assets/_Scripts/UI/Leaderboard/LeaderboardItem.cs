using System;
using _Scripts.CommonCharacterComponents;
using TMPro;
using UnityEngine;

namespace _Scripts.UI.Leaderboard
{
    public class LeaderboardItem : MonoBehaviour
    {
        [SerializeField] private GameObject _selectBG;
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _pointsText;
        [SerializeField] private TMP_Text _number;

        private PointsStorage _pointsStorage;
        
        public void Init(bool isPlayerItem, PointsStorage pointsStorage)
        {
            _nameText.text = "Bot";
            _pointsText.text = pointsStorage.AmountPoints.ToString();

            if (isPlayerItem)
            {
                _selectBG.SetActive(true);
                _nameText.text = "Player";
            }

            _pointsStorage = pointsStorage;
            _pointsStorage.AmountPointsChanged += UpdateItem;
        }

        public void UpdateSiblingIndex(int index)
        {
            transform.SetSiblingIndex(index);
            _number.text = (index + 1).ToString();
        }

        private void UpdateItem()
        {
            _pointsText.text = _pointsStorage.AmountPoints.ToString();
        }

        private void OnDestroy()
        {
            _pointsStorage.AmountPointsChanged -= UpdateItem;
        }
    }
}

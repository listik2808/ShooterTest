using Scripts.Inventory;
using TMPro;
using UnityEngine;

namespace Scripts.UiPatron
{
    public class ShowPatrons : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textPatron;
        [SerializeField] private Bag _bag;

        private void OnEnable()
        {
            _bag.PatronChanged += SetImagePatron;
        }

        private void OnDisable()
        {
            _bag.PatronChanged -= SetImagePatron;
        }

        private void SetImagePatron()
        {
            _textPatron.text = _bag.Patron.ToString() + "/" + _bag.Patrons;
        }
    }
}
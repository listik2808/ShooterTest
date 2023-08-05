using UnityEngine;

namespace Scripts.Inventory
{
    public class Patron : MonoBehaviour
    {
        [SerializeField] private int _aboema;

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Bag bag))
            {
                bag.AddAboema(_aboema);
            }
        }
    }
}
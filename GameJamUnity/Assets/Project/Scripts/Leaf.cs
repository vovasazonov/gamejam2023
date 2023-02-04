using UnityEngine;

namespace Project.Scripts
{
    public class Leaf : MonoBehaviour
    {
        [SerializeField] private GameObject _bellWon;

        public void SetActiveBellWon()
        {
            _bellWon.SetActive(true);
        }
    }
}
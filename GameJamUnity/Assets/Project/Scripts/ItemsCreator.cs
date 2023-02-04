using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Project.Scripts
{
    public class ItemsCreator : MonoBehaviour
    {
        [SerializeField] private Transform _leftBottomCorner;
        [SerializeField] private Transform _leftUpperCorner;
        [SerializeField] private Transform _rightBottomCorner;
        [SerializeField] private Transform _rightUpperCorner;

        private List<ItemByPercent> _toInstantiate = new();

        public int TotalItems;
        public List<ItemByPercent> ItemsInfos;

        private void Awake()
        {
            float weight = 0;
            int instantiatedAmount = 0;
            
            foreach (var itemInfo in ItemsInfos)
            {
                weight += itemInfo.InstantiatePercent;
            }

            foreach (var itemsInfo in ItemsInfos)
            {
                for (int i = 0; i < itemsInfo.MustHaveInstantiateAmount; i++)
                {
                    _toInstantiate.Add(itemsInfo);
                }
            }
            
            while (_toInstantiate.Count < TotalItems)
            {
                float tempWeight = 0;
                var randomPercent = Random.Range(0, weight);

                foreach (var itemsInfo in ItemsInfos)
                {
                    tempWeight += itemsInfo.InstantiatePercent;

                    if (tempWeight > randomPercent)
                    {
                        _toInstantiate.Add(itemsInfo);
                        break;
                    }
                }
            }
            
            foreach (var toInstantiate in _toInstantiate)
            {
                var x = Random.Range(_leftBottomCorner.position.x, _rightBottomCorner.position.x);
                var y = Random.Range(_leftBottomCorner.position.y, _rightUpperCorner.position.y);

                var item = Instantiate(toInstantiate.Item);
                item.transform.position = new Vector3(x, y);
            }
        }
        
        [Serializable]
        public struct ItemByPercent
        {
            public Item Item;
            public int MustHaveInstantiateAmount;
            [Range(0, 1)] public float InstantiatePercent;
        }
    }
}
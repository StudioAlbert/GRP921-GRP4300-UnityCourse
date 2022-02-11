using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Events
{
    public class CollectibleManager : MonoBehaviour
    {
        [SerializeField] List<Collectible> _collectibles;
        [SerializeField] private Text _itemsCounter;
        [SerializeField] private UnityEvent OnCompleteEvent;

        private List<Collectible> _collectedItems;

        // Start is called before the first frame update
        void Start()
        {
            _collectedItems = new List<Collectible>(_collectibles);
            foreach (var item in _collectedItems)
            {
                item.OnPickup += Collect;
            }
        }

        // Update is called once per frame
        void Update()
        {
            _itemsCounter.text = (_collectibles.Count - _collectedItems.Count).ToString();
        }

        private void Collect(Collectible itemCollectd)
        {
            _collectedItems.Remove(itemCollectd);

            if (_collectedItems.Count <= 0)
            {
                Debug.Log("Game complete !");
                OnCompleteEvent?.Invoke();
            }
        }
    }
}
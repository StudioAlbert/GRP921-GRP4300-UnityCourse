using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YieldExample
{
    public class Element
    {
        int _i;
       
        public Element(int i)
        {
            _i = i;
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
        }

        public override string ToString()
        {
            return "TestClass - " + _i;
        }

    }
    
    public class YieldExample : MonoBehaviour
    {

        public void RunNoYieldExample()
        {
            foreach (var oneElement in GetAllElements())
            {
                Debug.Log(DateTime.Now + " --- " + oneElement);
            }
        }
        
        public void RunYieldExample()
        {
            foreach (var oneElement in GetAllYieldElements())
            {
                Debug.Log(DateTime.Now + " --- " + oneElement);
            }
        }

        private IEnumerable<object> GetAllElements()
        {
            List<Element> elements = new List<Element>();
            for (int i = 0; i < 10; i++)
            {
                elements.Add(new Element(i));
            }
            return elements;
        }

        private IEnumerable<object> GetAllYieldElements()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new Element(i);
            }
        }
    }
}
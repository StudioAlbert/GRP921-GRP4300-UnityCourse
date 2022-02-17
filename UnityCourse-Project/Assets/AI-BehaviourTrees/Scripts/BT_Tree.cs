using System;
using System.Collections;
using System.Collections.Generic;
using BehaviourTrees;
using UnityEngine;

namespace BehaviourTrees
{
    public class BT_Tree : BT_Node
    {
        public BT_Tree(String prefix)
        {
            _name = prefix + "_root";
        }
        public void PrintTree()
        {
            String treePrintout ="";
            
            // foreach (var child in Children)
            // {
            //     treePrintout += child.ToString();
            // }
            
            Debug.Log(this.ToString());
        }
    }

}
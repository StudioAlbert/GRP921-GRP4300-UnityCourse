using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreeGraph
{
    public class TreeGraphNode
    {

        private String _name;
        public List<TreeGraphNode> _children = new List<TreeGraphNode>();
        public List<TreeGraphNode> Children => _children;
        
        public TreeGraphNode(String name)
        {
            _name = name;
        }

        public void AddChild(TreeGraphNode node)
        {
            if(!_children.Contains(node))
                _children.Add(node);
        }

        public override string ToString()
        {
            return _name;
        }

        public void Process()
        {
            Debug.Log("Node processed : " + _name);
        }

    }
}

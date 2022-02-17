using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

namespace BehaviourTrees
{
    public class BT_Node
    {
        public enum NodeStatus {SUCCESS, RUNNING, FAILURE}

        public NodeStatus Status => _status;
        private NodeStatus _status;
        
        public int Level
        {
            get => _level;
            set => _level = value;
        }

        protected int _level;
        
        public List<BT_Node> Children => _children;
        protected List<BT_Node> _children = new List<BT_Node>();
       
        public BT_Node CurrentChild => _currentChild;
        private BT_Node _currentChild;
        
        public string Name => _name;
        protected String _name;

        protected BT_Node()
        {
            
        }
        public BT_Node(string name)
        {
            _name = name;
        }

        public void AddChild(BT_Node node)
        {
            node.Level = Level + 1;
            _children.Add(node);
        }
        public override string ToString()
        {
            String tree = new String('-', _level) + _name + "\n";

            foreach (var child in Children)
            {
                //tree += child._name 
                tree += child.ToString();
            }

            return tree;

        }

    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreeGraph
{
    public class TreeGraph
    {

        private TreeGraphNode _root = new TreeGraphNode("_root");

        public void AddChild(TreeGraphNode node)
        {
            _root.AddChild(node);
        }
        
        public void ProcessInBFSOrder()
        {

            Queue<TreeGraphNode> _tempQueue = new Queue<TreeGraphNode>();
            String treeTrace = "";
            
            // Load the first child ---------------------------------------
            _tempQueue.Enqueue(_root);

            do
            {
                TreeGraphNode tn = _tempQueue.Dequeue();

                // Here is process -------------------------------------
                tn.Process();
                treeTrace += tn.ToString() + "\n";
                //tn.Mark();

                foreach (var child in tn.Children)
                    _tempQueue.Enqueue(child);

            } while (_tempQueue.Count > 0);
                
            Debug.Log(treeTrace);

        }
        
        public void ProcessInDFSOrder()
        {

            Stack<TreeGraphNode> _tempQueue = new Stack<TreeGraphNode>();
            List<TreeGraphNode> _visited = new List<TreeGraphNode>();
            String treeTrace = "";
            
            // Load the first child ---------------------------------------
            _tempQueue.Push(_root);

            do
            {
                TreeGraphNode tn = _tempQueue.Pop();
                _visited.Add(tn);

                // Here is process -------------------------------------
                tn.Process();
                treeTrace += tn.ToString() + "\n";

                foreach (var child in tn.Children)
                {
                    if (!_visited.Contains(child))
                    {
                        _tempQueue.Push(child);
                    }
                }

            } while (_tempQueue.Count > 0);
                
            Debug.Log(treeTrace);

        }

    }
}

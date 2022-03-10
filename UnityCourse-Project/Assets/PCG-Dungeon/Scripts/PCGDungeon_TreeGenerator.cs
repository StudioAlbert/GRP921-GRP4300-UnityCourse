using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TreeGraph;

namespace PCGDungeon
{
    public class PCGDungeon_TreeGenerator : MonoBehaviour
    {
        
        private TreeGraph.TreeGraph _tree = new TreeGraph.TreeGraph();

        // Update is called once per frame
        private void Update()
        {

        }
        
        // Start is called before the first frame update
        private void Start()
        {
            // TreeGraphNode newNode = _availableNodes.Find(n => n.name == "Point 009");
            // if(newNode != null)
            //     _root = newNode;
            TreeGraphNode branchA = new TreeGraphNode("branch_A");
            TreeGraphNode branchB = new TreeGraphNode("branch_B");
            TreeGraphNode branchBb = new TreeGraphNode("branch_BB");
                
            branchA.AddChild(new TreeGraphNode("leaf_A_a"));
            branchA.AddChild(new TreeGraphNode("leaf_A_b"));
                
            branchBb.AddChild(new TreeGraphNode("leaf_BB_a"));
            branchBb.AddChild(new TreeGraphNode("leaf_BB_b"));
                
            branchB.AddChild(new TreeGraphNode("leaf_B_a"));
            branchB.AddChild(new TreeGraphNode("leaf_B_b"));
            branchB.AddChild(branchBb);
                
            _tree.AddChild(branchA);
            _tree.AddChild(branchB);

            // StartCoroutine(BFSOrder());
            // StartCoroutine(DFSOrder());
            
            _tree.ProcessInBFSOrder();
            _tree.ProcessInDFSOrder();

        }
        
        /*public void VisitInBFSOrder()
        {
            foreach (TreeGraphNode nodeToUnMark in _availableNodes)
            {
                nodeToUnMark.Unmark();
            }
            
            StopAllCoroutines();
            StartCoroutine(BFSOrder());
        }        
        
        public void VisitInDFSOrder()
        {
            foreach (TreeGraphNode nodeToUnMark in _availableNodes)
            {
                nodeToUnMark.Unmark();
            }
            
            StopAllCoroutines();
            StartCoroutine(BFSOrder());
        }
        
        private TreeGraphNode new TreeGraphNode(String name)
        {

            TreeGraphNode newNode;
            
            newNode = _availableNodes.Find(n => n.name == name);
            if (newNode != null)
                return newNode;
            else
                return new TreeGraphNode();
            
        }*/
    }
    
}

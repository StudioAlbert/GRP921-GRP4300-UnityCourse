using System.Collections;
using System.Collections.Generic;
using BehaviourTrees;
using UnityEngine;

public class Robber_0 : MonoBehaviour
{

    private BT_Tree StealingTree = new BT_Tree("Stealing");
    
    // Start is called before the first frame update
    void Start()
    {
        BT_Node Steal = new BT_Node("Steal something");
        BT_Node GoToDiamond = new BT_Node("Go to diamond");
        BT_Node GoBackToVan = new BT_Node("Go Back To Van");
        
        StealingTree.AddChild(Steal);
        Steal.AddChild(GoToDiamond);
        Steal.AddChild(GoBackToVan);
        
        BT_Node PizzaDinner = new BT_Node("It's Pizza Diner Time !!!");
        BT_Node OrderPizza = new BT_Node("Order Pizza");
        BT_Node PayDeliveryMan = new BT_Node("Pay");
        BT_Node EatIt = new BT_Node("Eat Pizza");
        
        StealingTree.AddChild(PizzaDinner);
        PizzaDinner.AddChild(OrderPizza);
        PizzaDinner.AddChild(PayDeliveryMan);
        PizzaDinner.AddChild(EatIt);
        
    }

    // Update is called once per frame
    void Update()
    {
        StealingTree.PrintTree();
    }
}

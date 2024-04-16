using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _240415_01.Models;
using _240415_01.Data;

namespace _240415_01.Repository
{
    public class OrderRepository
    {
        public void Save(Order order){
            DataSet.Orders.Add(order);
        }
        public Order Retrieve(int Id){
            foreach(var o in DataSet.Orders){
                if(o.Id == Id){
                    return o;
                }
            }
            return null;
        }
    }
}
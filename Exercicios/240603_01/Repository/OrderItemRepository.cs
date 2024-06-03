using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _240603_01.Models;
using _240603_01.Data;

namespace _240603_01.Repository
{
    public class OrderItemRepository
    {
        public void Save(OrderItem orderItem){
            DataSet.OrderItems.Add(orderItem);
        }
        public OrderItem Retrieve(int Id){
            foreach(var oi in DataSet.OrderItems){
                if(oi.Id == Id){
                    return oi;
                }
            }
            return null;
        }
    }
}
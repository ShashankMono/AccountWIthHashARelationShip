using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountAppWIthHasARelationship.Models
{
    internal class Transaction
    {
        public int Id { get; set; }
        public string Type {  get; set; }
        public double Amount {  get; set; }
        public DateTime DateAndTime { get; set; }

        public override string ToString()
        {
            return $"=================\n" +
                $"Transaction Id : {Id}\n" +
                $"Transaction Type : {Type}\n" +
                $"Transaction Amount : {Amount}\n" +
                $"Transaction Date and TIme: {DateAndTime}";
        }

    }
}

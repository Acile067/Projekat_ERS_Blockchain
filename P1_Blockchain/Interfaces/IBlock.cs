using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Blockchain
{
    public interface IBlock
    {
        string CalculateHash();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Blockchain.Miner
{
    public interface IMiner
    {
        void Register(SmartContract.SmartContract smartContract);
    }
}

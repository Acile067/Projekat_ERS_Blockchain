using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Blockchain.SmartContract
{
    public interface ISmartContract
    {
        void ReciveClientData(Client.IClient client);
    }
}

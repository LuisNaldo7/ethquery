
using System;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;

namespace EthqueryIndexer
{
    public sealed class Web3Service : IWeb3Service
    {
        private Web3 web3;

        public Web3Service()
        {
            this.web3 = new Web3(Environment.GetEnvironmentVariable("PROVIDER"));
        }
        
        public ulong GetBlockNumber()
        {
            return (ulong)this.web3.Eth.Blocks.GetBlockNumber.SendRequestAsync().Result.Value;
        }

        public BlockWithTransactions GetBlockWithTransactionsByNumber(ulong blockNumber)
        {
            BlockParameter param = new BlockParameter(blockNumber);
            return this.web3.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(param).Result;
        }

    }
}

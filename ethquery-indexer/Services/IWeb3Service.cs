using Nethereum.RPC.Eth.DTOs;

namespace EthqueryIndexer
{
    public interface IWeb3Service
    {
        ulong GetBlockNumber();
        BlockWithTransactions GetBlockWithTransactionsByNumber(ulong blockNumber);
    }
}
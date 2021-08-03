using System;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace EthqueryIndexer
{
    public class IndexerService : BackgroundService
    {
        private readonly IWeb3Service web3Service;
        private readonly DatabaseService db;
        private long blockNumberToProcess;

        public IndexerService(IWeb3Service web3Service)
        {
            this.web3Service = web3Service;

            this.db = new DatabaseService();
            this.blockNumberToProcess = db.GetBlockNumberToProcess();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    // TODO replace example implementation
                    Console.WriteLine(
                        "Block: " + blockNumberToProcess.ToString() +
                        " Miner: " + web3Service.GetBlockWithTransactionsByNumber((ulong)blockNumberToProcess).Miner
                    );

                    this.blockNumberToProcess += 1;
                    db.UpdateBlockNumberToProcess(this.blockNumberToProcess);
                    await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
        }

        public long GetBlockNumberToProcess()
        {
            return this.blockNumberToProcess;
        }

    }
}

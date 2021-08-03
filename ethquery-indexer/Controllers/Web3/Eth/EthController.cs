using System.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Nethereum.RPC.Eth.DTOs;

namespace EthqueryIndexer.Controllers
{
    [Route("api/Web3/[controller]")]
    [ApiController]
    public class EthController : ControllerBase
    {
        private readonly IWeb3Service web3Service;

        public EthController(IWeb3Service web3Service)
        { 
            this.web3Service = web3Service;
        }

        [HttpGet]
        [Route("BlockNumber")]
        public async Task<ActionResult<ulong>> GetBlockNumber()
        {
            return await Task.Run(() =>
            {
                return this.web3Service.GetBlockNumber();
            });

        }

        [HttpGet]
        [Route("BlockByNumber")]
        public async Task<ActionResult<BlockWithTransactions>> GetBlockByNumber([FromQuery(Name = "blockNumber")] ulong blockNumber)
        {
            return await Task.Run(() =>
            {
                return this.web3Service.GetBlockWithTransactionsByNumber(blockNumber);
            });

        }

    }
}
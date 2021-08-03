using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace EthqueryIndexer.Controllers
{

    [Route("api/Indexer/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IndexerService indexerService;

        public StatusController(IEnumerable<IHostedService> services)
        {
            this.indexerService = (IndexerService)services.FirstOrDefault(w => w.GetType() == typeof(IndexerService));
        }

        [HttpGet]
        [Route("BlockNumberToProcess")]
        public async Task<ActionResult<long>> Get()
        {
            return await Task.Run(() =>
            {
                return indexerService.GetBlockNumberToProcess();
            });

        }

    }
}






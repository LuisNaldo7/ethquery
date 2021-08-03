using System;

public class DatabaseService
{
    const string ERR_GET_BLOCK_NUMBER_TO_PROCESS = "Error receiving block number to process.";
    const string ERR_UPDATE_BLOCK_NUMBER_TO_PROCESS = "Error updating block number to process.";

    // TODO  remove
    private long blockNumberToProcess;

    public DatabaseService()
    {
        // TODO remove
        this.blockNumberToProcess = GetBlockNumberToProcess();
    }

    public long GetBlockNumberToProcess()
    {
        // TODO read block number to process from database
        try
        {
            return 4819749;
        }
        catch (Exception ex)
        {
            Helper.PrintErr(ERR_GET_BLOCK_NUMBER_TO_PROCESS, ex);
            return -1;
        }
    }

    public bool UpdateBlockNumberToProcess(long blockNumber)
    {
        // TODO update block number to process from database
        try
        {
            this.blockNumberToProcess = blockNumber;
            return true;
        }
        catch (Exception ex)
        {

            Helper.PrintErr(ERR_UPDATE_BLOCK_NUMBER_TO_PROCESS, ex);
            return false;
        }
    }

}

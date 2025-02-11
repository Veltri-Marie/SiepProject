using Microsoft.SemanticKernel;

public class JobSheetPlugin{

    [KernelFunction("getRandomNumber")]
    public async Task<int> GetRandomNumber()
    {
        return new Random().Next();
    }

    [KernelFunction("isGoodAnswer")]
    public async Task<bool> isGoodAnswer(string jobName)
    {
        return false;
    }




}
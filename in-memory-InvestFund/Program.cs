using in_memory_InvestFund;
using in_memory_InvestFund.DataBase;

using (var dbManager = new DbManager())
{
    //File.Create(DataBaseInvestFund.DataBaseConnectionString).Close();
    dbManager.Menu();
}
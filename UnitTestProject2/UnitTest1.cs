using System.Collections.Generic;
using System.Threading.Tasks;
using HorelBusinessService.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            APIСlient.Connect();
        }

        [TestMethod]
        public void TestMethodGetListService()
        {
            List<ServiceViewModel> listService = Task.Run(() => APIСlient.GetRequestData<List<ServiceViewModel>>("api/Service/GetList")).Result;
        }

        [TestMethod]
        public void TestMethodGetOrder()
        {
            OrderViewModel listService = Task.Run(() => APIСlient.GetRequestData<OrderViewModel>("api/Order/Get/47")).Result;
        }
    }
}

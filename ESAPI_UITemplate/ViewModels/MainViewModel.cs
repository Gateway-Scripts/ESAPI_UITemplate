using ESAPI_UITemplate.Models;
using ESAPI_UITemplate.Services;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESAPI_UITemplate.ViewModels
{
    public class MainViewModel:BindableBase
    {
        private EsapiWorker _esapiWorker;
        public List<StructureModel> Structures { get; private set; }
        public MainViewModel(EsapiWorker esapiWorker)
        {
            _esapiWorker = esapiWorker;
            Structures = new List<StructureModel>();
            GetStructuresFromStructureSet();
        }

        private void GetStructuresFromStructureSet()
        {
            Structures = AutoPlanningService.GetStructuresFromStructureSet();
        }
    }
}

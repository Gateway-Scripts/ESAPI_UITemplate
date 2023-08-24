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
        public string PatientId { get; set; }
        public string StructureSetId { get; set; }
        public MainViewModel(EsapiWorker esapiWorker)
        {
            _esapiWorker = esapiWorker;
            Structures = new List<StructureModel>();
            GetHeaderInfo();
            GetStructuresFromStructureSet();
        }
        /// <summary>
        /// You can either access ESAPI objects from inside the viewmodel
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void GetHeaderInfo()
        {
            _esapiWorker.Run(xapp =>
            {
                PatientId = AutoPlanningService.Patient.Id;
                StructureSetId = AutoPlanningService.StructureSet.Id;
            });
        }
        /// <summary>
        /// Or you can access ESAPI data through a separate service and keep all ESAPI calls in a designated area. 
        /// </summary>
        private void GetStructuresFromStructureSet()
        {
            Structures = AutoPlanningService.GetStructuresFromStructureSet();
        }
    }
}

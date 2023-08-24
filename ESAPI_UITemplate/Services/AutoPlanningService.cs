using ESAPI_UITemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.API;

namespace ESAPI_UITemplate.Services
{
    public static class AutoPlanningService
    {
        public static EsapiWorker EsapiWorker;
        public static bool SavedModifications;
        public static StructureSet StructureSet;

        internal static List<StructureModel> GetStructuresFromStructureSet()
        {
            List<StructureModel> structures = new List<StructureModel>();
            EsapiWorker.Run(xapp =>
            {
                foreach (var structure in StructureSet.Structures)
                {
                    structures.Add(new StructureModel
                    {
                        StructureId = structure.Id,
                        StructureCode = structure.StructureCode?.Code,
                        DicomType = structure.DicomType,
                        bIsEmpty = structure.IsEmpty
                    });
                }
            });
            return structures;
        }
    }
}

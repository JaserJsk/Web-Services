using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using RestServiceLibrary.Models;

namespace RestServiceLibrary.Interfaces
{
    [ServiceContract]
    public interface IEval
    {
        [OperationContract]
        [WebGet(UriTemplate = "eval")]
        List<Eval> GetEval();

        [OperationContract]
        [WebGet(UriTemplate = "eval/{id}")]
        Eval GetEvalById(string Id);

        [OperationContract]
        [WebGet(UriTemplate = "evals/{submitter}")]
        List<Eval> GetEvalsBySubmitter(string submitter);

        [OperationContract]
        [WebGet(UriTemplate = "evals")]
        List<Eval> GetAllEvals();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "evals")]
        void SubmitEval(Eval eval);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "eval/{id}")]
        void RemoveEval(string Id);
    }
}

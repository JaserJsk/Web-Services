using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace RestServiceLibrary
{
    [DataContract]
    public class Eval
    {
        [DataMember]
        public string Id;
        [DataMember]
        public string Submitter;
        [DataMember]
        public DateTime TimeSent;
        [DataMember]
        public string Comments;

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Id, Submitter, Comments, TimeSent);
        }
    }

    [ServiceContract]
    public interface IEvalService
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

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class EvalService : IEvalService
    {
        public int evalCount = 0;
        List<Eval> evals = new List<Eval>();

        #region GET
        public List<Eval> GetEval()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region GET BY ID
        public Eval GetEvalById(string Id)
        {
            var result = evals.First(x => x.Id.Equals(Id));

            return result;
        }
        #endregion

        #region GET BY SUBMITER
        public List<Eval> GetEvalsBySubmitter(string submitter)
        {
            if (submitter == null || submitter.Equals(""))
            {
                Console.WriteLine("parameter: {0}, evalcount: {1}", submitter, evals.Count);
                return evals;
            }
            else
            {
                Console.WriteLine("parameter: {0}, evalcount: {1}", submitter, evals.Count);
                return evals.FindAll(e => e.Submitter.ToLower().Equals(submitter.ToLower()));
            }
        }
        #endregion

        #region GET ALL
        public List<Eval> GetAllEvals()
        {
            return evals;
        }
        #endregion

        #region SUBMIT
        public void SubmitEval(Eval eval)
        {
            eval.Id = (++evalCount).ToString();
            if (eval.Submitter.Equals("Throw"))
                throw new FaultException("Error within SubmitEval");
            evals.Add(eval);
        }
        #endregion

        #region REMOVE
        public void RemoveEval(string Id)
        {
            Eval evalToRemove = evals.Find(e => e.Id.Equals(Id));
            evals.Remove(evalToRemove);
        }
        #endregion

    }
}

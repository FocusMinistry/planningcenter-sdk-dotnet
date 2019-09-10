using System.Net;

namespace PlanningCenter.Api.Models {
    public interface IPlanningCenterRestResponse {
        string RequestValue { get; set; }

        string JsonResponse { get; set; }

        HttpStatusCode StatusCode { get; set; }

        string ErrorMessage { get; set; }

        bool IsSuccessful { get; }
    }

    public interface IPlanningCenterRestResponse<T> : IPlanningCenterRestResponse {
        T Data { get; set; }
    }

    public class PlanningCenterRestResponse : IPlanningCenterRestResponse {
        public string RequestValue { get; set; }

        public string JsonResponse { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string ErrorMessage { get; set; }

        public bool IsSuccessful {
            get {
                return (int)StatusCode >= 200 && (int)StatusCode < 300;
            }
        }
    }

    public class PlanningCenterRestResponse<T> : PlanningCenterRestResponse, IPlanningCenterRestResponse<T> where T : new() {
        public T Data { get; set; }
    }
}
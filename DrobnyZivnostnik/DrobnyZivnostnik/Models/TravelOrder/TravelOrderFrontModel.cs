namespace DrobnyZivnostnik.Models.TravelOrder
{
    using System;
    using Annotations;

    class TravelOrderFrontModel
    {
        [AxiosTextKey("Axios.Models.TravelOrderFrontModel.TravelOrderFrontId")]
        public Guid TravelOrderFrontId { get; set; }

        [AxiosRequired]
        [AxiosTextKey("Axios.Models.TravelOrderFrontModel.StartPlace")]
        public string StartPlace { get; set; }

        [AxiosRequired]
        [AxiosTextKey("Axios.Models.TravelOrderFrontModel.StartDate")]
        public DateTime StartDate { get; set; }

        [AxiosRequired]
        [AxiosTextKey("Axios.Models.TravelOrderFrontModel.DepartmentTime")]
        public TimeSpan DepartmentTime { get; set; }

        [AxiosRequired]
        [AxiosTextKey("Axios.Models.TravelOrderFrontModel.PlaceOfMeeting")]
        public string PlaceOfMeeting { get; set; }

        [AxiosRequired]
        [AxiosTextKey("Axios.Models.TravelOrderFrontModel.MeetingPurpose")]
        public string MeetingPurpose { get; set; }

        [AxiosTextKey("Axios.Models.TravelOrderFrontModel.TravelLength")]
        public TimeSpan TravelLength { get; set; }

        [AxiosRequired]
        [AxiosTextKey("Axios.Models.TravelOrderFrontModel.EndPlace")]
        public string EndPlace { get; set; }

        [AxiosTextKey("Axios.Models.TravelOrderFrontModel.EndDate")]
        public DateTime EndDate { get; set; }

        [AxiosTextKey("Axios.Models.TravelOrderFrontModel.ArrivalTime")]
        public TimeSpan ArrivalTime { get; set; }

        [AxiosTextKey("Axios.Models.TravelOrderFrontModel.Active")]
        public bool Active { get; set; }

        [AxiosTextKey("Axios.Models.UserModel.Deleted")]
        public bool Deleted { get; set; }
    }
}
